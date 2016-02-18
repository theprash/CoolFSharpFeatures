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

// Even within a module

module D =
    let f1 x = f2 x

    let f2 x = 1

// Because functions are normal values
