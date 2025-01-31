// Rekurencyjna wersja algorytmu QuickSort
let rec quickSort lst =
    match lst with
    | [] -> []
    | pivot :: tail ->
        let left = List.filter (fun x -> x < pivot) tail
        let right = List.filter (fun x -> x >= pivot) tail
        quickSort left @ [pivot] @ quickSort right
