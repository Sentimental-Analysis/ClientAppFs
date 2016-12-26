module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

type AppProps = {a: unit}
type AppState = {a: unit}

type AppComponent(props) as this =
    inherit React.Component<AppProps, AppState>(props)   