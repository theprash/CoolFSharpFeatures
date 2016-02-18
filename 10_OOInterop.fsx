open System

// Make classes

type MyClass(x) =
    inherit obj()

    new() = MyClass(1)

    member private this.Field = x

    member public this.Double =
        this.Field * 2

    member public this.Times(x) =
        this.Field * x

    interface IComparable with
        member this.CompareTo(x) =
            let other = (x :?> MyClass)
            if other.Field < this.Field then 1
            else if other.Field > this.Field then -1
            else 0


// Use classes

(new MyClass(3)).Double

// `new` keyword not necessary
MyClass(3).Double

MyClass().Double

MyClass(3).Times(4)

(MyClass(3) :> IComparable).CompareTo(MyClass(2))

MyClass(2) < MyClass(3)
