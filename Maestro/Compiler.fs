namespace Maestro.Compiler

[<AutoOpen>]
module Compiler = 
    
    type TargetLanguage = 
        | NodeJS 
        | BrowserJS
        