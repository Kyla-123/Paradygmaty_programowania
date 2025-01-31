// Definicja drzewa binarnego
type 'a BinaryTree =
    | Empty
    | Node of 'a * 'a BinaryTree * 'a BinaryTree

// Rekurencyjna funkcja do wyszukiwania elementu w drzewie binarnym
let rec search tree value =
    match tree with
    | Empty -> false
    | Node (v, left, right) ->
        if v = value then true
        else search left value || search right value
