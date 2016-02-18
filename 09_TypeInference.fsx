(
    [
        [
            1, Set.ofList ["a"]
        ]
    ]
    //: List<List<int * Set<string>>>
)

// Partial inference with wildcard `_`.
// Allows you to be partly explicit and partly implicit


// Automatic generalisation - there is often no need to write out type parameters

let explicitGeneric (x : 'a) : List<'a> = [x]

let automaticGeneric x = [x]


// Types are also inferred from usage, e.g. be being applied to function

let intTuple (x : int) = x, x // x parameter is annotated to int

let f x = [intTuple x]        // x is interred to int from function application
