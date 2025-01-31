// Rekurencyjna wersja obliczania n-tego wyrazu ciągu Fibonacciego
let rec fibonacci n =
    if n <= 1 then
        n
    else
        fibonacci (n - 1) + fibonacci (n - 2)
