// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open FSharp.Data.Sql


let [<Literal>] resolutionPath = __SOURCE_DIRECTORY__ + @"/../packages/Npgsql.3.1.10/lib/net451"
let [<Literal>] connectionString = "Server=localhost;Port=5432;User ID=postgres;Password=postgres;Database=mydb"

type DB = SqlDataProvider<Common.DatabaseProviderTypes.POSTGRESQL,
                          ConnectionString  = connectionString,
                          ResolutionPath    = resolutionPath,
                          IndividualsAmount = 1000,
                          UseOptionTypes    = true>
let ctx = DB.GetDataContext()

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    query {
        for u in ctx.Public.Person do
        select (u.Id, u.``public.slacktoken by id``) }
    |> Seq.toArray
    |> printfn "%A"
    0 // return an integer exit code
