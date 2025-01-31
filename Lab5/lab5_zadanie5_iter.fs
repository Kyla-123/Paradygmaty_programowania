// Iteracyjna wersja QuickSort z użyciem stosu
let quickSortIterative lst =
    let rec loop stack =
        match stack with
        | [] -> []
        | [] :: rest -> loop rest
        | pivot :: tail :: rest ->
            let left = List.filter (fun x -> x < pivot) tail
            let right = List.filter (fun x -> x >= pivot) tail
            loop (left :: right :: rest)
    loop [lst]
