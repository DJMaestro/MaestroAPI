namespace Maestro.API
open Newtonsoft.Json
open Newtonsoft.Json.Serialization
open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.RequestErrors

[<AutoOpen>]
module API = 

        let JSON v =
            let settings = new JsonSerializerSettings()
            settings.ContractResolver <-
                new CamelCasePropertyNamesContractResolver()
                
            JsonConvert.SerializeObject(v, settings)
            |> OK
            >=> Writers.setMimeType "application/json; charset=utf-8"
        
        let fromJson<'a> json =
            JsonConvert.DeserializeObject(json, typeof<'a>) :?> 'a