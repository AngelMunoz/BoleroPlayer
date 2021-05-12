namespace BoleroPlayer.Client

open Microsoft.AspNetCore.Components.WebAssembly.Hosting

module Program =

    [<EntryPoint>]
    let Main args =
        let builder =
            WebAssemblyHostBuilder.CreateDefault(args)

        builder.RootComponents.Add<Main.View>("#main")

        builder.Build().RunAsync()
        |> Async.AwaitTask
        |> Async.Start

        0
