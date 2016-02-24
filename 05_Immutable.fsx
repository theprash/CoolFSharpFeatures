// Immutable by default
// --------------------

// Constants are normal
let a = 1
let a = 2 // compile error

// You can make things mutable explicitly
let mutable b = 1
b <- 2
b


// Efficient immutable data structures
// -----------------------------------

// List
[ 1; 2; 3 ]

// Set
set [ 1; 2; 3 ]

// Map
Map.ofList [ "a", 1
             "b", 2
             "c", 3 ]

// Record

type MyCoolRecord = { coolString : string
                      coolInt : int }

{ coolString = "hi!"
  coolInt = 7 }

// Tuple
(12, "hi")

// Tuples help avoid mutable refs by tupling `out` parameters

let (quotient, remainder) = System.Math.DivRem(10, 3) // DivRem is automatically "tuple-ised"
