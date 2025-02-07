open System

// Zadanie 2: Sprawdzenie palindromu
let checkPalindrome () =
    printf "\nPodaj tekst do sprawdzenia palindromu: "
    let text = Console.ReadLine()
    // Usuwamy spacje i zmieniamy na małe litery dla ujednolicenia
    let processed = text.Replace(" ", "").ToLower()
    let reversed = new string(Array.rev (processed.ToCharArray()))
    if processed = reversed then
        printfn "Tekst jest palindromem."
    else
        printfn "Tekst nie jest palindromem."