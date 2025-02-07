  /// 9. Porównuje dwie listy liczb całkowitych – dla każdej pary zwraca true, gdy element z pierwszej listy jest większy,
    ///    false – gdy z drugiej. Rzuca wyjątek, jeśli listy mają różne długości.
    let compareLists (ll1: LinkedList<int>) (ll2: LinkedList<int>) : bool list =
        let rec loop l1 l2 acc =
            match l1, l2 with
            | Empty, Empty -> List.rev acc
            | Node(v1, next1), Node(v2, next2) ->
                let res = if v1 > v2 then true else false
                loop next1 next2 (res :: acc)
            | _ -> failwith "Listy mają różną długość!"
        loop ll1 ll2 []