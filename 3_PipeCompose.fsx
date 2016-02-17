// Pipe
let add1 x = x + 1

add1 1

1 |> add1

1
|> add1
|> add1
|> add1

// <Ignore>
let carrots, wash, dry, peel, chop, boil, eat = 1, id, id, id, id, id, id
// </Ignore>

// Awkward
(eat (boil (chop (peel (dry (wash carrots))))))

// Awkward and error-prone
let washed = wash carrots
let dried = dry washed
let peeled = peel dried
let chopped = chop peeled
let boiled = boil chopped
eat boiled

// Lovely
carrots
|> wash
|> dry
|> peel
|> chop
|> boil
|> eat

// Pipe left

add1 (2 + 2)
add1 <| 2 + 2

// Compose

let add2 = add1 >> add1

add2 1

let prepare = wash >> dry >> peel >> chop >> boil

carrots |> prepare |> eat