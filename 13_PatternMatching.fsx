// FizzBuzz : Print the numbers from 1 to 100,
// but for multiples of three print “Fizz” instead of the number,
// for the multiples of five print “Buzz”,
// and for numbers which are multiples of both three and five print “FizzBuzz”.

let fb n =
    match (n % 3), (n % 5) with
    | 0, 0 -> "FizzBuzz" // Match on literal value
    | 0, _ -> "Fizz"     // Match on wildcard `_`
    | _, 0 -> "Buzz"
    | _ -> string n

List.map fb [1..100]

// Match on lists

let input = [ [ "a"; "b"; "c" ]; [] ]

match input with
| [ [ x; y; z ]; _ ]                -> (x, y, z) |> string
| [ x; y ]                          -> y |> string
| [ _; [] ]                         -> "second empty"
| (x :: y :: _) as firstList :: _   -> (x, y, firstList) |> string
| [ [ x; y ]; [] ]                  -> "two items in first list"
| ( x :: _ ) :: _ when x.Length = 1 -> "first string is one character long"
| _                                 -> "No matches"

// Match on records

type MyCoolRecord = { name: string; age: int }

match { name = "Gandalf"; age = 200 } with
| { name = n; age = a } when a < 100 -> n.ToString() + " is less than 100 years old."
| { name = n } -> n.ToString() + " is at least 100 years old."

// Match on discriminated union cases

type DU = Case1 | Case2 of string

match Case2 ":D" with
| Case1 -> ":("
| Case2 x -> x
