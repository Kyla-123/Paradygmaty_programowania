/// 11. Usuwa duplikaty z listy (dla typów, które implementują equality)
    let removeDuplicates (ll: LinkedList<'T>) : LinkedList<'T> when 'T : equality =
        let rec loop seen node =
            match node with
            | Empty -> Empty
            | Node(value, next) ->
                if List.contains value seen then
                    loop seen next
                else
                    Node(value, loop (value :: seen) next)
        loop [] ll