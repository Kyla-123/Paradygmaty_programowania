// Iteracyjna wersja wyszukiwania w drzewie binarnym z użyciem stosu
let searchIterative tree value =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: rest -> loop rest
        | Node (v, left, right) :: rest ->
            if v = value then true
            else loop (left :: right :: rest)
    loop [tree]
