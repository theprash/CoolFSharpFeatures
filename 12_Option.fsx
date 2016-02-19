// Let's define some types.

type MyCoolRecord = { coolString : string }
type MyCoolClass() = class end

// We can create an instance of each type.

({ coolString = "hi!" } : MyCoolRecord)
(MyCoolClass() : MyCoolClass)

// Try to make null instances

(null : MyCoolRecord) // Nope!
(null : MyCoolClass)  // Nope!

// But there is a type that encodes an optional value: The Option type.

(None                 : Option<MyCoolClass>)
(Some (MyCoolClass()) : Option<MyCoolClass>)

// It's built into F# but it can easily be defined. It's just a discriminated union.

type Option<'a> =
    | Some of 'a
    | None

// Pattern match to handle each case.

let isAnyoneThere recordOption =
    match recordOption with
    | Some r -> r.coolString
    | None   -> "No-one here :("

isAnyoneThere (Some {coolString = "Hi! :)" })
isAnyoneThere None

// If you have an optional value, check for None *once*.
// Then pass it around as a guaranteed non-null and don't check it anymore.
