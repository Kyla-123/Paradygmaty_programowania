  /// 10. Zwraca listę elementów, które spełniają określony warunek
    let filter (predicate: 'T -> bool) (ll: LinkedList<'T>) : LinkedList<'T> =
        let rec loop node =
            match node with
            | Empty -> Empty
            | Node(value, next) ->
                if predicate value then
                    Node(value, loop next)
                else
                    loop next
        loop ll