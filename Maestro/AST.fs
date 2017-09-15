namespace Maestro.AST
open Maestro.Types

[<AutoOpen>]
module AST = 
    
    type Dependency = {name: string; program_id: string;}
     
    type Input = {_type: Mtype; name: string;} 
    
    type Referral = {
        program_id: string
        program_name: string
        return_type: Mtype
        index: int
        input: list<Input>
        nextblock: int
    }
    
    type Lamda = {
        return_type: Mtype
        index: int
        input: list<Input>
        statement: string
        nextblock: int 
    } 
    
    type ProgramBlock = Referral | Lamda
    
    type IOFile = Main | Child 
    
    type ComputationType = Pure | IO of IOFile
    
    type Error = Type | Syntax | Other of string
    
    type ProgramError = {_type: Error; description: string; index:int}
    
    type Validation = | Valid | InValid of ProgramError
    
    type Author = | Unknown | Person of string
    
    type Access = Public | Private
    
    type Program = {
        id: string
        name: string
        package: string
        _type: ComputationType
        return_type: Mtype
        dependencies: list<Dependency>
        inputs: list<Input>
        pipeline: list<ProgramBlock>
        description: string
        html_description: string
        valid: Validation
        version: string
        author: Author
        access: Access
        subProgram: list<int>
        globals: list<string>
    }
    
    
    