// Zadanie 2: Konwersja walut
open System

let exchangeRates = 
    [
        ("USD", 1.0); ("EUR", 0.9); ("GBP", 0.75); ("PLN", 4.5)
    ] |> Map.ofList

let convertCurrency amount sourceCurrency targetCurrency =
    match exchangeRates.TryFind sourceCurrency, exchangeRates.TryFind targetCurrency with
    | Some(sourceRate), Some(targetRate) ->
        amount * targetRate / sourceRate
    | _ -> failwith "Invalid currency"

let main() =
    printfn "Enter amount:"
    let amount = Console.ReadLine() |> float

    printfn "Enter source currency (e.g., USD, EUR, GBP):"
    let sourceCurrency = Console.ReadLine()

    printfn "Enter target currency (e.g., USD, EUR, GBP):"
    let targetCurrency = Console.ReadLine()

    try
        let convertedAmount = convertCurrency amount sourceCurrency targetCurrency
        printfn "Converted amount: %.2f" convertedAmount
    with
    | ex -> printfn "Error: %s" ex.Message

main()
