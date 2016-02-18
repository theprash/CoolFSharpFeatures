// Immutable by default

// Usually use constants
let a = 1
let a = 2 // compile error

// Explicitly mutable
let mutable b = 1
b <- 2
b

// Efficient immutable data structures

[ 1; 2; 3 ] // List

set [ 1; 2; 3 ] // Set

Map.ofList [ "a", 1
             "b", 2
             "c", 3 ] // Map

type MyCoolRecord = {coolString : string; coolInt : int}
{coolString = "hi!"; coolInt = 7} // Record

(12, "hi") // Tuple

// Helps avoid mutable refs by tupling `out` parameters
let (quotient, remainder) = System.Math.DivRem(10, 3)
