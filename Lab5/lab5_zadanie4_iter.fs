// Iteracyjne rozwiązanie problemu wież Hanoi
let hanoiIterative n source target auxiliary =
    let mutable stack = []
    let mutable moves = 0
    for i in 1..n do
        stack <- (i, source, target, auxiliary) :: stack
    while stack.Length > 0 do
        let (n, source, target, auxiliary) = stack.Head
        stack <- stack.Tail
        if n = 1 then
            printfn "Move disk from %s to %s" source target
        else
            stack <- (n - 1, source, auxiliary, target) :: stack
            printfn "Move disk from %s to %s" source target
            stack <- (n - 1, auxiliary, target, source) :: stack
