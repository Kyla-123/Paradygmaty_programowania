open System
open System.Collections.Generic

// Klasa BankAccount
type BankAccount(accountNumber: string, initialBalance: decimal) =
    // Saldo jest zmienne
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    /// Metoda wpłaty – dodaje kwotę do salda
    member this.Deposit(amount: decimal) =
        if amount > 0m then
            balance <- balance + amount
            printfn "Wpłacono %.2f na konto %s." amount accountNumber
        else
            printfn "Kwota wpłaty musi być dodatnia."

    /// Metoda wypłaty – odejmuje kwotę, jeśli środki są wystarczające
    member this.Withdraw(amount: decimal) =
        if amount <= 0m then
            printfn "Kwota wypłaty musi być dodatnia."
        elif amount > balance then
            printfn "Niewystarczające środki na koncie %s." accountNumber
        else
            balance <- balance - amount
            printfn "Wypłacono %.2f z konta %s." amount accountNumber

    member this.GetInfo() =
        sprintf "Konto: %s | Saldo: %.2f" accountNumber balance

// Klasa Bank
type Bank() =
    // Używamy słownika do przechowywania kont według numeru
    let accounts = new Dictionary<string, BankAccount>()

    /// Tworzy nowe konto
    member this.CreateAccount(accountNumber: string, initialBalance: decimal) =
        if accounts.ContainsKey(accountNumber) then
            printfn "Konto o numerze %s już istnieje." accountNumber
        else
            let account = new BankAccount(accountNumber, initialBalance)
            accounts.Add(accountNumber, account)
            printfn "Utworzono konto %s z saldem %.2f." accountNumber initialBalance

    /// Pobiera konto po numerze
    member this.GetAccount(accountNumber: string) =
        match accounts.TryGetValue(accountNumber) with
        | (true, account) -> Some account
        | _ -> 
            printfn "Nie znaleziono konta o numerze %s." accountNumber
            None

    /// Usuwa konto
    member this.DeleteAccount(accountNumber: string) =
        if accounts.Remove(accountNumber) then
            printfn "Usunięto konto %s." accountNumber
        else
            printfn "Nie znaleziono konta o numerze %s." accountNumber

    /// Wyświetla informacje o wszystkich kontach
    member this.ListAccounts() =
        if accounts.Count = 0 then
            printfn "Brak kont w banku."
        else
            printfn "Lista kont:"
            for kvp in accounts do
                printfn "%s" (kvp.Value.GetInfo())

[<EntryPoint>]
let main argv =
    let bank = new Bank()

    let rec menu () =
        printfn "\n==== System Bankowy ===="
        printfn "1. Utwórz konto"
        printfn "2. Wpłata"
        printfn "3. Wypłata"
        printfn "4. Informacje o koncie"
        printfn "5. Usuń konto"
        printfn "6. Lista kont"
        printfn "0. Wyjście"
        printf "Wybierz opcję: "
        let choice = Console.ReadLine()
        match choice with
        | "1" ->
            printf "Podaj numer konta: "
            let accNumber = Console.ReadLine()
            printf "Podaj początkowe saldo: "
            let initialBalance =
                match Decimal.TryParse(Console.ReadLine()) with
                | (true, b) -> b
                | _ -> 0m
            bank.CreateAccount(accNumber, initialBalance)
            menu()
        | "2" ->
            printf "Podaj numer konta: "
            let accNumber = Console.ReadLine()
            match bank.GetAccount(accNumber) with
            | Some account ->
                printf "Podaj kwotę wpłaty: "
                let amount =
                    match Decimal.TryParse(Console.ReadLine()) with
                    | (true, a) -> a
                    | _ -> 0m
                account.Deposit(amount)
            | None -> ()
            menu()
        | "3" ->
            printf "Podaj numer konta: "
            let accNumber = Console.ReadLine()
            match bank.GetAccount(accNumber) with
            | Some account ->
                printf "Podaj kwotę wypłaty: "
                let amount =
                    match Decimal.TryParse(Console.ReadLine()) with
                    | (true, a) -> a
                    | _ -> 0m
                account.Withdraw(amount)
            | None -> ()
            menu()
        | "4" ->
            printf "Podaj numer konta: "
            let accNumber = Console.ReadLine()
            match bank.GetAccount(accNumber) with
            | Some account -> printfn "%s" (account.GetInfo())
            | None -> ()
            menu()
        | "5" ->
            printf "Podaj numer konta do usunięcia: "
            let accNumber = Console.ReadLine()
            bank.DeleteAccount(accNumber)
            menu()
        | "6" ->
            bank.ListAccounts()
            menu()
        | "0" ->
            printfn "Koniec programu."
            0
        | _ ->
            printfn "Nieprawidłowy wybór, spróbuj ponownie."
            menu()
    menu()
