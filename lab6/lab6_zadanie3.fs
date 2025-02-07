open System

[<EntryPoint>]
let main argv =
    printfn "Wprowadź wpisy w formacie 'imię; nazwisko; wiek'."
    printfn "Aby zakończyć, naciśnij Enter na pustej linii."

    // Funkcja rekurencyjna do wczytywania wpisów
    let rec readEntries () =
        let line = Console.ReadLine()
        if System.String.IsNullOrWhiteSpace(line) then []
        else line :: readEntries ()
    
    let entries = readEntries ()

    // Przetwarzamy każdy wpis
    for entry in entries do
        let parts = entry.Split([|';'|], System.StringSplitOptions.RemoveEmptyEntries)
        if parts.Length >= 3 then
            let imie = parts.[0].Trim()
            let nazwisko = parts.[1].Trim()
            let wiek = parts.[2].Trim()
            printfn "%s, %s (%s lat)" nazwisko imie wiek
        else
            printfn "Nieprawidłowy format wpisu: %s" entry

    0
