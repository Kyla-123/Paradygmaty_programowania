 /// 7. Zlicza wystąpienia danego elementu w liście
    let rec countOccurrence (elem: 'T) (ll: LinkedList<'T>) : int =
        match ll with
        | Empty -> 0
        | Node(value, next) ->
            let countRest = countOccurrence elem next
            if value = elem then 1 + countRest else countRest