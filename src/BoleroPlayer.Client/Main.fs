namespace BoleroPlayer.Client

open System
open Microsoft.AspNetCore.Components
open Elmish
open Bolero
open Bolero.Html

open BoleroPlayer.Client.Components

module Main =

    type State = { Noop: bool }

    let init _ = { Noop = false }, Cmd.none

    type Message = Noop

    let update (msg: Message) (state: State) = state, Cmd.none

    let view (model: State) (dispatch: Dispatch<Message>) =
        article [ attr.``class`` "bol-app" ] [
            nav [] []
            main [ attr.``class`` "bol-main" ] [
                p [] [ text "Hello there" ]
                comp<MediaPlayer.View> [] []
                comp<Playlist.View> [] []
            ]
        ]

    type View() =
        inherit ProgramComponent<State, Message>()

        override this.Program = Program.mkProgram init update view
