// Naive recursion creates many stack frames

let rec countNaively n =
    if n = 0 then
        0
    else
        1 + countNaively (n - 1)

countNaively <| int 1e6 // StackOverflowException :(


// There's a way to get around this

let count n =
    // Create a new private function
    let rec loop n acc = // that takes an accumulator
        if n = 0 then
            acc
        else
            loop (n - 1) (acc + 1) // Move the recursive call to the "tail" position

    // Call the private function with a seed value
    loop n 0

// The compiler optimises away the creation of a new stack frame for each function call.
count <| int 1e6

// This is known as tail call optimisation
