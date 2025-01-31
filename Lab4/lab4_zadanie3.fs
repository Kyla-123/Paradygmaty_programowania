// Zadanie 4: Aplikacja bankowa
open System

type Account = { AccountNumber: string; mutable Balance: float }

let accounts = System.Collections.Generic.Dictionary<string, Account>()

// Funkcja do tworzenia konta
let createAccount accountNumber =
    let account = { AccountNumber = accountNumber; Balance = 0.0 }
    accounts.[accountNumber] <- account
    printfn "Account created successfully!"

// Funkcja do wpłacania środków na konto
let deposit accountNumber amount =
    match accounts.TryGetValue(accountNumber) with
    | true, account -> 
        account.Balance <- account.Balance + amount
        printfn "Deposited %.2f. New balance: %.2f" amount account.Balance
    | _ -> printfn "Account not found."

// Funkcja do wypłacania środków z konta
let withdraw accountNumber amount =
    match accounts.TryGetValue(accountNumber) with
    | true, account when account.Balance >= amount ->
        account.Balance <- account.Balance - amount
        printfn "Withdrew %.2f. New balance: %.2f" amount account.Balance
    | true, _ -> printfn "Insufficient funds."
    | _ -> printfn "Account not found."

// Funkcja do wyświetlania salda konta
let showBalance accountNumber =
    match accounts.TryGetValue(accountNumber) with
    | true, account -> printfn "Balance: %.2f" account.Balance
    | _ -> printfn "Account not found."

// Funkcja do wyświetlania menu
let displayMenu () =
    printfn "\nMenu:"
    printfn "1. Create Account"
    printfn "2. Deposit Money"
    printfn "3. Withdraw Money"
    printfn "4. Show Balance"
    printfn "5. Exit"
    printf "Choose an option: "

// Główna funkcja programu
let main() =
    let mutable running = true

    while running do
        displayMenu ()
        let choice = Console.ReadLine() |> int
        match choice with
        | 1 ->
            printf "Enter account number: "
            let accountNumber = Console.ReadLine()
            createAccount accountNumber
        | 2 ->
            printf "Enter account number: "
            let accountNumber = Console.ReadLine()
            printf "Enter amount to deposit: "
            let amount = Console.ReadLine() |> float
            deposit accountNumber amount
        | 3 ->
            printf "Enter account number: "
            let accountNumber = Console.ReadLine()
            printf "Enter amount to withdraw: "
            let amount = Console.ReadLine() |> float
            withdraw accountNumber amount
        | 4 ->
            printf "Enter account number: "
            let accountNumber = Console.ReadLine()
            showBalance accountNumber
        | 5 ->
            printfn "Exiting program."
            running <- false
        | _ ->
            printfn "Invalid option, please try again."

// Uruchomienie programu
main()
