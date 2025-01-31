// Zadanie 3: Analiza tekstu
open System
open System.Linq

// Funkcja analizująca tekst
let analyzeText (text: string) =
    let words = text.Split([|' '; '\n'; '\t'|], StringSplitOptions.RemoveEmptyEntries)
    let wordCount = words.Length
    let charCount = text.Replace(" ", "").Length
    let mostFrequentWord = 
        words
        |> Seq.groupBy id
        |> Seq.map (fun (word, group) -> (word, Seq.length group))
        |> Seq.maxBy snd
        |> fst

    wordCount, charCount, mostFrequentWord

// Główna funkcja programu
let main() =
    printfn "Enter text:"
    let text = Console.ReadLine()

    let wordCount, charCount, mostFrequentWord = analyzeText text

    printfn "Word count: %d" wordCount
    printfn "Character count (without spaces): %d" charCount
    printfn "Most frequent word: %s" mostFrequentWord

// Uruchomienie programu
main()
