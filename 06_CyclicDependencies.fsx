// No cyclic dependencies

module A =
    let func x = x + 1

module B =
    let func x = A.func (x + 1)

module C =
    let myValue = 1
    let doubledValue = myValue * 2

    let func x = B.func (x + doubledValue)

C.func 0

// Functions must be defined before use, even within a module,  because functions are values.

module D =
    let value1 = value2 // error: value2 is not defined. Seems reasonable...
    let value2 = 1

    let function1 x = function2 x // error: function2 is not defined
    let function2 x = 1

// F# restricts cyclic dependencies at
    // The project level (like C#)
    // The module level
    // The value level

// This allows for more (enforced) layering.

// The check can be circumvented for mutally recursive functions, using `rec` and `and`:

module E =
    let rec function1 x =
        function2 x

    and function2 x =
        if false then function1 x else 1

// This enforces mutually recursive functions are defined next to each other.

// Because of these restrictions, F# files in a project must be specified in a valid order,
// so modules are defined before use. A clean dependency graph is enforced.
