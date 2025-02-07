 /// 2. Sumuje elementy listy zawierającej liczby całkowite
    let rec sum (ll: LinkedList<int>) : int =
        match ll with
        | Empty -> 0
        | Node(value, next) -> value + sum next
 /// 2. Sumuje elementy listy zawierającej liczby całkowite
    let rec sum (ll: LinkedList<int>) : int =
        match ll with
        | Empty -> 0
        | Node(value, next) -> value + sum next
