// Active Patterns: define your own patterns to match on!

// A complete active pattern.

let (|Even|Odd|) input =
    if input % 2 = 0 then Even
    else Odd

match 0 with
| Even -> "Even!"
| Odd -> "Odd!"
  // No need for a catch-all case. The compiler knows all cases are covered.

// A partial active pattern.

let (|MultipleOf|_|) n input =
    if input % n = 0 then
        Some input
    else
        None  // Note that this returns an Option

match 3 with
| MultipleOf 2 x -> "Yes! " + (string x)
| _ -> "Nope." // Match

match 15 with
| MultipleOf 3 (MultipleOf 5 x) -> "Yes, " + (string x) // Match
| _ -> "Nope."

// Match a string that parses to integer.

let (|Integer|_|) str =
    match System.Int32.TryParse str with // the `out` parameter gets automatically tuple-ised!
    | true, i -> Some i
    | false, _ -> None

match "123" with
| Integer i -> i // Match
| _ -> 0

match "ab85" with
| Integer i -> i
| _ -> 0 // Match

// A parameterised Active pattern
// Match string that matches a regex pattern, and return the match groups.
// (Taken from https://msdn.microsoft.com/en-us/library/dd233248.aspx)

open System.Text.RegularExpressions

let (|ParseRegex|_|) regex str =
    let m = Regex(regex).Match(str)
    if m.Success then Some (List.tail [ for x in m.Groups -> x.Value ])
    else None

// An example of its usage to parse date strings.

let parseDate str =
    match str with
    | ParseRegex "^(\d{1,2})/(\d{1,2})/(\d{4})$" [Integer d; Integer m; Integer y] ->
        System.DateTime(y, m, d)

    | ParseRegex "^(\d{1,4})-(\d{1,2})-(\d{2})$" [Integer y; Integer m; Integer d] ->
        System.DateTime(y, m, d)

    | _ ->
        System.DateTime(1, 1, 1)

parseDate "22/12/2008" |> string
parseDate "1/1/2009" |> string
parseDate "2008-1-15" |> string
parseDate "1995-12-28" |> string
parseDate "1995-12-2X" |> string
