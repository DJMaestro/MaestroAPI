namespace Maestro.Types

[<AutoOpen>]
module Types = 

    type Mtype = 
      | Int 
      | Float 
      | Boolean 
      | Void
      | List
      | Record
      | Function of Mtype * Mtype
      | Custom of string
    
    let isMtype data = 
        match data with 
        | Int | Float | Boolean | Void | List | Record | Function _   -> true
        | Custom s -> false
        
    let dakota = Function (Int , Function(Boolean , Float))