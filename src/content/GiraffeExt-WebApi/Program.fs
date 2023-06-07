module GiraffeExt.WebApi.Program

open Giraffe
open Giraffe.EndpointRouting
open Handlers
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Hosting

let endpoints = [ GET [ route "/weatherforecast" get ] ]

[<EntryPoint>]
let main args =
    let builder = WebApplication.CreateBuilder(args)

    builder.Services.AddGiraffe() |> ignore

    let app = builder.Build()
#if (HasHttpsProfile)

    app.UseHttpsRedirection() |> ignore
#endif

    app.UseRouting().UseGiraffe(endpoints) |> ignore

    app.Run()

    0
