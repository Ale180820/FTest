namespace FTest
#nowarn "20"
open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =
        let square = Func<_,_>(fun num ->  num * num)
        let double = Func<_,_>(fun num ->  num * 2)
        let sum = Func<_,_>(fun (num1,num2) ->  num1 * num2)
        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddControllers()

        let app = builder.Build()

        app.UseHttpsRedirection()

        app.UseAuthorization()
        app.MapControllers()
        app.MapGet("/square", square) |> ignore
        app.MapGet("/double", double) |> ignore
        app.MapPost("/sum", sum) |> ignore
        app.Run()

        exitCode
