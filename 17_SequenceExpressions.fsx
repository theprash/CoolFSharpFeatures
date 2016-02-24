// Sequence Expressions
// --------------------

// In F#, seq<'a> is an alias for IEnumerable<'a>.
// Use sequence expressions to create useful sequences concisely.

// Ranges

seq { 1 .. 4 }
seq { 0 .. 3 .. 10 }

seq { for i in 1 .. 4 -> i * 2 }

let mySeq = seq { 1 .. 2 }

// Multiply out sequences using the imperative style for-do loop

seq { for i in mySeq do
          for j in mySeq do
              yield i, j }

// Yield items sequentially

seq { yield 1
      yield 2
      yield 4 }

// Use `yield!` to yield a sequence and flatten it intoo a list

seq { yield! [1; 2]
      yield! [3; 4] }

// Sequence expressions can also be used to create lists and arrays

[  for i in 1 .. 4 -> i * 2  ]
[| for i in 1 .. 4 -> i * 2 |]

// A custom simple list builder, to demonstrate the generality of computation expressions

type ListBuilder() =
    member __.Yield(a) = [a]  // Used for `yield`
    member __.YieldFrom(xs) = xs  // Used for `yield!`
    member __.Combine(a, b) = a @ b  // Used to combine adjacent yields
    member __.Delay(f) = f ()
    member __.Bind(xs, f) = List.collect f xs  // Used for `let!`
    member __.Zero() = []  // Used if nothing is yielded

let list = ListBuilder()

list {
    yield 1
    yield 2
    yield! [3; 4]
}

// We defined `Bind`, so we can use `let!` to multiply out lists (as opposed to `for` and `do` above)

list {
    let! a = [1; 2]
    let! b = [1; 2]

    yield a, b
}

// This is like adding new syntax to the language!

// Let's use this to find some Pythagorean triples:

list {
    let! c = [1 .. 20]
    let! a = [1 .. c]
    let! b = [1 .. c]

    if (a * a + b * b = c * c) then
        yield a, b, c
}
