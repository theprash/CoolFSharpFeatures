// Match on lists and their values

match [ 1; 2; 3 ] with
| [ _; _; 1 ] -> "Nope"
| [ a; b; 3 ] -> "Yep. Oh, and the first two items are " + (string a) + " and " + (string b)
  // a and b are new variables being bound here to any value in that list position.
| _ -> "No matches"

// Pattern matching is a way to take some input, and pick a path of execution that depends on its
// shape or its value or parts of its shape or parts of its value, while also binding parts of its
// value to names for further processing.

// Match on empty list or the head of a list

match [ 1; 2; 3 ] with
| [] -> "Empty"
| head :: tail -> "Head is " + (string head) + ", and tail is " + (string tail)

// Patterns can be nested.

match [ [ 1; 2; 3 ]; [ 4; 5; 6] ] with // A list of lists.
| [ a :: _ ; _ ] -> string a
| _ -> "No matches"

// Use a `when` clause with an arbitrary bool expression
match [ 1; 2; 3 ] with
| a :: _ when a > 1 -> "Match"
| _ -> "No matches"

// Match on records

type MyCoolRecord = { name: string; age: int }

match { name = "Gandalf"; age = 1000 } with
| { name = "Gandalf"; age = a } -> string a
| _ -> "No matches"

// Match on discriminated union cases

type DU =
    | Case1
    | Case2 of string

match Case2 ":D" with
| Case1   -> ":("
| Case2 x -> x

// Match on tuples

match 5, "hi", [1; 2; 3] with // a 3-tuple
| 0, _, _ -> "Nope"
| _, _, (a :: _) -> string a
| _ -> "No matches"


// FizzBuzz : Print the numbers from 1 to 100,
// but for multiples of three print “Fizz” instead of the number,
// for the multiples of five print “Buzz”,
// and for numbers which are multiples of both three and five print “FizzBuzz”.

let fizzBuzz input =
    let factor x = (input % x) = 0

    match factor 3, factor 5 with
    | false, false -> string input
    | f3, f5 -> (if f3 then "Fizz" else "") +
                (if f5 then "Buzz" else "")

List.map fizzBuzz [1..100]
