
    /// 12. Dzieli listę na dwie części: elementy spełniające warunek oraz pozostałe
    let partition (predicate: 'T -> bool) (ll: LinkedList<'T>) : LinkedList<'T> * LinkedList<'T> =
        let rec loop node (yes, no) =
            match node with
            | Empty -> (reverse yes, reverse no)
            | Node(value, next) ->
                if predicate value then
                    loop next (Node(value, yes), no)
                else
                    loop next (yes, Node(value, no))
        loop ll (Empty, Empty)