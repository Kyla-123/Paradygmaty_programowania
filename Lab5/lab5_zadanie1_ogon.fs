// Zoptymalizowana wersja z ogonową rekurencją
let fibonacciTailRecursive n =
    let rec aux a b n =
        if n = 0 then a
        else aux b (a + b) (n - 1)
    aux 0 1 n
