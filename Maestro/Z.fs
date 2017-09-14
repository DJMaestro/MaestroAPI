open Maestro.Types

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    let test = Int
    let s = match test with 
                | Custom st -> st
                | _ -> "balls"
        
    printfn "%A" s
    0 // return an integer exit code
