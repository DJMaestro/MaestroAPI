open Maestro.Types

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let test = Int
    let s = match test with 
                | Custom st -> st
                | _ -> "balls"
        
    printfn "%A" s
     // return an integer exit code

    printfn "Hello"
    0
