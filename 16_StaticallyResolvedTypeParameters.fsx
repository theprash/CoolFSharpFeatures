// Statically resolved type parameters

// Inline functions can have a type restriction based on the existence of a static method with a
// particular name and signature in that type. The restriction is resolved at compile time.

// For example, a TryParse method that takes a string and an `out` parameter, and returns a bool
// The type is written with a ^ prefix, e.g. ^a

let inline tryParse
    text
    : ^a option when ^a : (static member TryParse : string * ^a byref -> bool)
    =
        let r = ref Unchecked.defaultof< ^a >
        if (^a : (static member TryParse: string * ^a byref -> bool) (text, &r.contents))
        then Some (!r)
        else None

let inline tryParseOrDefault text default' =
    defaultArg (tryParse text) default'

tryParseOrDefault "123" 0 // The return type is inferred from the provided default value.
tryParseOrDefault "true" false
tryParseOrDefault "01/01/2001" System.DateTime.UtcNow |> string
tryParseOrDefault "----------" System.DateTime.UtcNow |> string

tryParseOrDefault "blah" "" // Error: The type 'string' does not support the operator 'TryParse'.

// Some language features rely on this. (+) is a function/operator that works for multiple types,
// e.g. int, int32, string, instead of needing separate operators.

1 + 1
1L + 1L
"a" + "b"

// But not *all* types

true + false // Error: The type 'bool' does not support the operator '+'.
