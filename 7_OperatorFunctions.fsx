// Operators are functions

let (---) a b = a - (3 * b)

5 --- 1

// Infix to prefix with round brackets

(---) 5 1

// Therefore we can curry (automatic partial function application)

let add1 x = (+) 1 x  // equivalent
let add1' = (+) 1     // functions

[1..4] |> List.map ((+) 1)

// Pipe operator is just a function

let (|>) x f = f x

[true; true] |> List.map not
//              ^^^^^^^^^^^^
//              This must be a function List<bool> -> List<bool>
//              because it's translated to:
(List.map not) [true; true]
// List.map is curried from 2 inputs to 1, so it's equivalent to:
List.map not [true; true]

// Most operators are inlined for performance (and sometimes to make them extra generic)

let inline (+++) a b = a + (3 * b)
//  ^^^^^^
// This means code is transformed at the call site at compile time
