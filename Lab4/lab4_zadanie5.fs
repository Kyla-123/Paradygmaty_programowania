// Rekurencyjna wersja obliczania n-tego wyrazu ciągu Fibonacciego
let rec fibonacci n =
    if n <= 1 then
        n
    else
        fibonacci (n - 1) + fibonacci (n - 2)
// Zadanie 5: Gra "Kółko i Krzyżyk" z komputerem
open System

type Player = X | O
type Cell = Empty | Occupied of Player

let emptyBoard = [ for _ in 1..9 -> Empty ]

// Funkcja do wyświetlania planszy
let printBoard (board: Cell list) =
    board |> List.chunkBySize 3 |> List.iter (fun row ->
        row |> List.iter (fun cell ->
            match cell with
            | Empty -> printf " . "
            | Occupied X -> printf " X "
            | Occupied O -> printf " O ")
        printfn "")

// Funkcja do wykonania ruchu
let makeMove (board: Cell list) (position: int) (player: Player) =
    if board.[position] = Empty then
        let newBoard = board |> List.mapi (fun idx cell -> if idx = position then Occupied player else cell)
        newBoard
    else
        printfn "Cell already occupied!"
        board

// Funkcja do sprawdzania zwycięzcy
let checkWinner (board: Cell list) =
    let winningCombinations = [
        [0; 1; 2]; [3; 4; 5]; [6; 7; 8];  // rows
        [0; 3; 6]; [1; 4; 7]; [2; 5; 8];  // columns
        [0; 4; 8]; [2; 4; 6]              // diagonals
    ]
    winningCombinations |> List.tryFind (fun indices ->
        match board.[indices.[0]] with
        | Occupied p when indices |> List.forall (fun i -> board.[i] = Occupied p) -> true
        | _ -> false)

// Funkcja do wyboru losowego ruchu przez komputer
let randomMove (board: Cell list) =
    let emptyCells = board |> List.mapi (fun idx cell -> if cell = Empty then Some idx else None) |> List.choose id
    if emptyCells.Length > 0 then
        let rand = Random()
        let randomIndex = rand.Next(emptyCells.Length)
        emptyCells.[randomIndex]
    else
        -1 // Jeśli brak pustych komórek, zwróci -1

// Główna funkcja programu
let main() =
    let mutable board = emptyBoard
    let mutable currentPlayer = X

    let rec gameLoop () =
        printBoard board
        if currentPlayer = X then
            printfn "Player %A's turn (Enter position 0-8):" currentPlayer
            let position = Console.ReadLine() |> int
            board <- makeMove board position currentPlayer
        else
            printfn "Computer's turn (choosing position for Player %A)..." currentPlayer
            let position = randomMove board
            printfn "Computer chose position %d" position
            board <- makeMove board position currentPlayer

        match checkWinner board with
        | Some p -> 
            printBoard board
            printfn "Player %A wins!" p
        | None when List.exists ((=) Empty) board -> 
            currentPlayer <- if currentPlayer = X then O else X
            gameLoop ()
        | None -> 
            printBoard board
            printfn "It's a draw!"

    gameLoop()

// Uruchomienie programu
main()
