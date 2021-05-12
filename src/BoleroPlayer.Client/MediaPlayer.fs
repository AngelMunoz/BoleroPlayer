namespace BoleroPlayer.Client.Components

open Microsoft.AspNetCore.Components

open Elmish
open Bolero
open Bolero.Html

[<RequireQualifiedAccess>]
module MediaPlayer =
    type State = { CurrentSong: string option }

    type Message =
        | Play
        | Pause
        | Stop
        | Next
        | Back

    let private init _ = { CurrentSong = None }, Cmd.none

    let private update (msg: Message) (state: State) = state, Cmd.none

    let private view (state: State) (dispatch: Dispatch<Message>) = div [] []


    type View() =
        inherit ProgramComponent<State, Message>()


        override this.Program = Program.mkProgram init update view
