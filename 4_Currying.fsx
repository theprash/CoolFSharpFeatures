let add a b = a + b

// Partial application
let addThree x = add 3 x

// Currying
let addThree' = add 3

addThree' 1

// Convert this to a concise curried version:
[1 .. 4]
|> fun list -> List.map (fun x -> add 3 x) list