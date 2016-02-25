// Async Workflows
// ---------------

// A simple example: waiting for random timers.

let rnd = System.Random()

[ for _ in 1 .. 6 -> rnd.Next(1, 3000) ] // Random numbers up to 3000
|> List.mapi
    (fun index sleepMs ->
        async {
            let! a = Async.Sleep sleepMs // `let!` yields the thread until the result is ready
            printfn "%A" <| (string index) + " complete"
            return sleepMs
        })
|> Async.Parallel
|> Async.RunSynchronously


// An example for downloading web pages in parallel (from MSDN)

open System.Net
open Microsoft.FSharp.Control.WebExtensions

let urlList = [ "Microsoft.com", "http://www.microsoft.com/"
                "MSDN", "http://msdn.microsoft.com/"
                "Bing", "http://www.bing.com"
              ]

let fetchAsync(name, url:string) =
    async { 
        let webClient = new WebClient()
        let! html = webClient.AsyncDownloadString(System.Uri(url))
        printfn "Read %d characters for %s" html.Length name
    }

urlList
|> Seq.map fetchAsync
|> Async.Parallel 
|> Async.RunSynchronously

// Async workflows are built from a more general feature:

// Computation Expressions
// -----------------------

// Make an option builder

type OptionBuilder() =
    member this.Bind(x : Option<'a>, f : 'a -> Option<'b>) =
        match x with
        | Some y -> f y
        | None -> None

    member this.Return(x : 'a) =
        Some x

let option = new OptionBuilder()

// A maybe divide function

let (/?) a b = if b = 0 then None else Some (a / b)

// Here's how to use the builder. This is a computation expression:

option {             // `option` now acts like a keyword, like `async`
    let! a = 20 /? 0 // Expression returns an Option<int> but `let!` allows you to treat it as int
    let! b = a /? 2  // This works even though a is None!
    return b
}

// This gets translated into the following:

option.Bind(
    20 /? 0,
    fun a ->
        option.Bind(
            a /? 2,
            fun b ->
                option.Return b))

// And if we substitute the method definitions we get:

match 20 /? 0 with
| Some a ->
    match a /? 2 with
    | Some b -> Some b
    | None -> None
| None -> None

// This is nested logic, but the computation expression allowed us to write linear steps.

// If there were more steps there would be more nesting, which would be hard to follow.
