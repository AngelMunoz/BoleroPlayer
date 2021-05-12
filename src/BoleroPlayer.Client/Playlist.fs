namespace BoleroPlayer.Client.Components

open Microsoft.AspNetCore.Components

open Elmish
open Bolero
open Bolero.Html
open Microsoft.JSInterop
open Microsoft.AspNetCore.Components.Forms
open Bolero.Remoting.Client

[<RequireQualifiedAccess>]
module Playlist =
    type State = { Songs: string list }

    type Message =
        | AddFiles
        | SelectedFiles of obj array
        | RemoveFromPlaylist
        | PlaySong
        | Error of exn

    let private init _ = { Songs = [] }, Cmd.none

    let private update (js: IJSRuntime) (msg: Message) (state: State) =
        match msg with
        | AddFiles -> state, Cmd.OfJS.either js "Interop.FileService.GetFiles" [||] SelectedFiles Error
        | SelectedFiles files -> state, Cmd.OfJS.attempt js "Interop.PlayerService.Play" files Error
        | Error ex ->
            eprintfn "%O" ex
            state, Cmd.none
        | _ -> state, Cmd.none

    let private view (state: State) (dispatch: Dispatch<Message>) =
        div [] [
            button [ on.click (fun _ -> dispatch AddFiles) ] [
                text "Select Files"
            ]
        ]


    type View() =
        inherit ProgramComponent<State, Message>()


        override this.Program =
            let update = update this.JSRuntime
            Program.mkProgram init update view
