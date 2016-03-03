#if INTERACTIVE
#I __SOURCE_DIRECTORY__
#r "../packages/FSharp.Data.SqlClient/lib/net40/FSharp.Data.SqlClient.dll"
#endif

module PlayGround.Suave.Data
open System
open FSharp.Data


type Order = {Id:int; AccountNumber:String}
[<Literal>]
let connectionstring =
    @"data source =.;initial catalog=AdventureWorks2012;integrated security=true"
let orderQuery = new SqlCommandProvider<"select *  from Sales.SalesOrderHeader",connectionstring>()
let OrdResults =
    orderQuery.Execute()
    |>Seq.map(fun x-> {Id=x.SalesOrderID;AccountNumber=Option.get x.AccountNumber})

    








