// Discriminated Unions a.k.a. Sum Type (an "or" type)

type MyCoolDiscriminatedUnion =
    | Case1
    | Case2
    | Case3

// Each case is a value of the type of the DU

(Case1 : MyCoolDiscriminatedUnion)
Case2

// A case can contain more data

type Level =
    | Junior
    | Senior
    | Lead

type Spell =
    | Fireball
    | Freeze

type Person =
    | Developer of Level
    | BA of Level
    | Wizard of Level * List<Spell>

[
    BA Senior
    Developer Junior
    Wizard (Lead, [Fireball; Freeze])
]
|> List.sortBy (function Developer lev | BA lev | Wizard (lev, _) -> lev)

// Exhaustive matching - warning/error when not all cases matched

let SpellResponse spell =
    match spell with
    | Fireball -> "Ouch!"

// Versus class Inheritance/Interface?

  // Discriminated unions: Closed to adding new types -- Open to adding new operations
  // Inheritance/Interfaces: Open to adding new types -- Closed to adding new operations

  // DUs give you compile time guarantee that cases are handled (Treat warnings as errors!)
