 /// 3. Znajduje minimalny i maksymalny element w liście liczb całkowitych
    let minMax (ll: LinkedList<int>) : (int * int) =
        match ll with
        | Empty -> failwith "Lista jest pusta."
        | Node(head, tail) ->
            let rec loop currentMin currentMax node =
                match node with
                | Empty -> (currentMin, currentMax)
                | Node(value, next) ->
                    let newMin = if value < currentMin then value else currentMin
                    let newMax = if value > currentMax then value else currentMax
                    loop newMin newMax next
            loop head head tail