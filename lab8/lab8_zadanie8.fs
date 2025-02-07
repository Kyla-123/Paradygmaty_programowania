 /// 8. Łączy dwie listy łączone w jedną
    let rec merge (ll1: LinkedList<'T>) (ll2: LinkedList<'T>) : LinkedList<'T> =
        match ll1 with
        | Empty -> ll2
        | Node(value, next) -> Node(value, merge next ll2)