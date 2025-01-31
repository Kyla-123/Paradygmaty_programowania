// Funkcja rekurencyjna generująca wszystkie permutacje listy
let rec permutations lst =
    match lst with
    | [] -> [[]]  // Jedyna permutacja pustej listy to lista pusta
    | head :: tail ->
        let perms = permutations tail
        perms |> List.collect (fun perm ->
            [ for i in 0..List.length perm do
                yield List.take i perm @ head :: List.skip i perm ])
