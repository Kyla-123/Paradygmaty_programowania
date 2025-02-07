 /// 5. Sprawdza, czy dany element występuje w liście
    let rec exists (elem: 'T) (ll: LinkedList<'T>) : bool =
        match ll with
        | Empty -> false
        | Node(value, next) ->
            if value = elem then true
            else exists elem next