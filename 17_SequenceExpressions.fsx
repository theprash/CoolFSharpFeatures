// Sequence Expressions
// --------------------

// In F#, seq<'a> is an alias for IEnumerable<'a>

seq { 1 .. 4 }
seq { 0 .. 3 .. 10 }

seq { for i in 1 .. 4 -> i * 2 }

let mySeq = seq { 1 .. 2 }

seq { for i in mySeq do
          for j in mySeq do
              yield i, j }

seq { yield 1
      yield 2
      yield 4 }

seq { yield! mySeq
      yield! mySeq }

// This can also be used to define lists and arrays

[  for i in 1 .. 4 -> i * 2  ]
[| for i in 1 .. 4 -> i * 2 |]

// A custom simple list builder, to demonstrate the generality of computation expressions

type ListBuilder() =
    member __.Yield(a) = [a]        // Used for `yield`
    member __.YieldFrom(xs) = xs    // Used for `yield!`
    member __.Combine(a, b) = a @ b // Used to combine adjacent yields
    member __.Delay(f) = f ()

let list = ListBuilder()

list {
    yield 1
    yield 2
    yield! [3; 4]
}
