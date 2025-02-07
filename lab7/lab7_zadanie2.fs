open System

/// Definicja własnej listy łączonej
type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

/// Typ wynikowy dla funkcji wyszukiwania indeksu elementu
type IndexResult =
    | Found of int
    | NotFound

module LinkedList =

    /// 1. Tworzy listę łączoną na podstawie zwykłej listy
    let fromList (lst: 'T list) : LinkedList<'T> =
        let rec loop l =
            match l with
            | [] -> Empty
            | head :: tail -> Node(head, loop tail)
        loop lst

    /// Zamienia listę łączoną na zwykłą (przydatne przy wyświetlaniu)
    let toList (ll: LinkedList<'T>) : 'T list =
        let rec loop acc node =
            match node with
            | Empty -> List.rev acc
            | Node(value, next) -> loop (value :: acc) next
        loop [] ll

    /// Wyświetla elementy listy łączonej
    let rec print (ll: LinkedList<'T>) =
        match ll with
        | Empty -> ()
        | Node(value, next) ->
            printf "%A " value
            print next
