namespace Maestro.AST
open Maestro.Types

[<AutoOpen>]
module AST = 
    
    type Dependency = {name: string; program_id: string;}
     
    type Input = {_type: Mtype; name: string;} 
    
    type Instruction = Left | Right
    
    type PathFromOrigin = list<Instruction>

    type PipeLocation = Origin | Coordinates of PathFromOrigin

    type Action = Next | Recursive of (PipeLocation *  int) | None 

    type Reference = {
        program_id: string
        program_name: string
        return_type: Mtype
        index: int
        input: list<Input>
        next: Action
    }
    
    type Lamda = {
        return_type: Mtype
        index: int
        input: list<Input>
        statement: string
        next: Action 
    } 
    
    type ProgramBlock = Reference | Lamda
    
    type IOFile = Main | Child 
    
    type ComputationType = Pure | IO of IOFile
    
    type Error = Type | Syntax | Other of string
    
    type ProgramError = {_type: Error; description: string; index:int}
    
    type Validation = | Valid | InValid of ProgramError
    
    type Author = | Unknown | Person of string
    
    type Access = Public | Private
    
    type Pipe = list<ProgramBlock>

   
  //this is a good example of using type generics for circular dependent types 
    type Fork<'a> = {
      main: Pipe
      bool: ProgramBlock
      left: 'a
      right: 'a
    }

    type PipeLine<'a> = 
      |  ForkLess of Pipe
      | Fork of 'a  Fork 
    
    type Program = {
        id:  string Option
        name: string Option
        package: string Option
        _type: ComputationType
        return_type: Mtype
        dependencies: list<Dependency>
        inputs: list<Input>
        pipe: Program PipeLine
        location: PipeLocation
        description: string Option
        html_description: string Option
        valid: Validation Option
        version: string Option
        author: Author Option
        access: Access Option
        globals: list<string>
    }
    
    
    