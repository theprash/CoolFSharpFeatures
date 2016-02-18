let add a b = a + b

// Partial application
let addThree x = add 3 x

// Currying (automatic partial application)
let addThree' = add 3

addThree' 1

// Every function can be thought of as having one parameter and returning either the next function
// to call or the final value.

let f a b c d = a + b + c + d

f 1 2 3 4         // <- how you normally write it
((((f 1) 2) 3) 4) // <- an equivalent model

// Convert this to a concise curried version:
[1 .. 4] |> fun list -> List.map (fun x -> add 3 x) list
