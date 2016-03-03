(*#r "../packages/Suave/lib/net40/Suave.dll"

open Suave                 // always open suave
open Suave.Successful      // for OK-result
open Suave.Web             // for config

startWebServer defaultConfig (OK "Hello World!")
*)

#if INTERACTIVE
#I __SOURCE_DIRECTORY__
#r "../packages/FSharp.Data.SqlClient/lib/net40/FSharp.Data.SqlClient.dll"
#endif

module PlayGroundSuaveData = 
    open System
    open FSharp.Data


    type Order = {Id:int; AccountNumber:String}
    [<Literal>]
    let connectionstring =
        @"data source =.;initial catalog=AdventureWorks2012;integrated security=true"
    let orderQuery = new SqlCommandProvider<"select *  from Sales.SalesOrderHeader",connectionstring>()
    let OrdResults =
        orderQuery.Execute()
        |>Seq.map(fun x-> {Id=x.SalesOrderID;AccountNumber=Option.get x.AccountNumber;})
        

   let foo (bar:string option) = 
       match bar with
       |some -> string
       |none -> "no value"        


let x = Some "foo"
type foo = Option<string>
let y = Some 2

let test z =
    match box z with 
    | :? foo  -> "string option "
    | _ -> "not string option " 

test x
test y
