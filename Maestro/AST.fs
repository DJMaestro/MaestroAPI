namespace Maestro.AST
open Maestro.Types

[<AutoOpen>]
module AST = 
    
    type Dependency = {name: string; program_id: string;}
    
    type Input = {_type: Mtype; name: string;} 
    
    type ProgramBlock = Referral | Lamda
    
    type ComputationType = Pure | IO 
    
    type Program = {
        id: string
        name: string
        package: string
        _type: ComputationType
        return_type: Mtype
        dependencies: list<Dependency>
        inputs: list<Input>
        pipeline: list<ProgramBlock>
    }
    
    
    