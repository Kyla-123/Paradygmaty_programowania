open System

[<EntryPoint>]
let main argv =
    // Prośba o wprowadzenie słów oddzielonych spacjami
    printf "Podaj słowa oddzielone spacjami: "
    let input = Console.ReadLine()

    // Rozdzielamy słowa i usuwamy puste wpisy
    let words = input.Split([|' '|], System.StringSplitOptions.RemoveEmptyEntries)
    
    // Usuwamy duplikaty
    let uniqueWords = words |> Array.distinct

    // Wyświetlamy listę unikalnych słów
    printfn "Lista unikalnych słów: %A" uniqueWords

    0
