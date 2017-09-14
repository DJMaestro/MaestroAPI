module Utility

open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Chiron
open Chiron.Operators

let private random = System.Random()

// returns random string of length len
let randomStr len = 
    let chars = "ABCDEFGHIJKLMNOPQRSTUVWUXYZ0123456789"
    let charsLen = chars.Length
    let randomChars = [|for i in 0..len -> chars.[random.Next(charsLen)]|]
    new System.String(randomChars)

let fromJson= Json.parse >> Json.deserialize
      
let JSON v =
    let settings = new JsonSerializerSettings()
    settings.ContractResolver <-
        new CamelCasePropertyNamesContractResolver()
    
    JsonConvert.SerializeObject(v, settings)

