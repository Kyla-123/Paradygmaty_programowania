/// 6. Znajduje indeks danego elementu – wynik jako Found(index) lub NotFound
    let indexOf (elem: 'T) (ll: LinkedList<'T>) : IndexResult =
        let rec loop idx node =
            match node with
            | Empty -> NotFound
            | Node(value, next) ->
                if value = elem then Found(idx)
                else loop (idx + 1) next
        loop 0 ll
