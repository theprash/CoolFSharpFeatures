// Everything is an expression. So no `return` needed.

let myCoolFunction myCoolParam =
    myCoolParam * 2

// `if` is an expression. So put it anywhere.

let myCoolVariable =
    if 1 < 2 then
        ":)"
    else
        ":("

floor (if 1 < 2 then 2.2
       else if 3 < 4 then 3.3
       else 4.4)

// The same with case matching.

1 + (
    match [1; 2; 3] with
    | [] -> 0
    | [a; b; c] -> 3
    | _ -> 0 )
