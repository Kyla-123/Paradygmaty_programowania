open System

[<EntryPoint>]
let main argv =
    // Prośba o wprowadzenie tekstu
    printf "Podaj tekst: "
    let text = Console.ReadLine()

    // Rozdzielamy tekst na słowa
    let words = text.Split([|' '; '\t'; '\n'; '\r'|], System.StringSplitOptions.RemoveEmptyEntries)

    if words.Length = 0 then
        printfn "Nie wprowadzono słów."
    else
        // Znajdujemy słowo o maksymalnej długości
        let longest = words |> Array.maxBy (fun word -> word.Length)
        printfn "Najdłuższe słowo: %s" longest
        printfn "Długość: %d" longest.Length

    0
