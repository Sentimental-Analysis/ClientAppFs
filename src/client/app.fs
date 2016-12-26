module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

[<Pojo>]
type AppProps = {a: unit}
[<Pojo>]
type AppState = {a: unit}

type AppComponent(props) as this =
    inherit React.Component<AppProps, AppState>(props)   