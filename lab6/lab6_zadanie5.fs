open System

[<EntryPoint>]
let main argv =
    // Prośba o wprowadzenie tekstu
    printf "Podaj tekst: "
    let text = Console.ReadLine()

    // Pobranie słowa, które należy wyszukać
    printf "Podaj słowo do wyszukania: "
    let searchWord = Console.ReadLine()

    // Pobranie słowa zastępczego
    printf "Podaj słowo zastępcze: "
    let replacement = Console.ReadLine()

    // Zamiana wszystkich wystąpień szukanego słowa na słowo zastępcze
    let newText = text.Replace(searchWord, replacement)
    printfn "Zmodyfikowany tekst: %s" newText

    0
