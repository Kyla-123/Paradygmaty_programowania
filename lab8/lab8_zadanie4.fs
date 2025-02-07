  /// 4. Odwraca kolejność elementów listy
    let reverse (ll: LinkedList<'T>) : LinkedList<'T> =
        let rec loop acc node =
            match node with
            | Empty -> acc
            | Node(value, next) -> loop (Node(value, acc)) next
        loop Empty ll