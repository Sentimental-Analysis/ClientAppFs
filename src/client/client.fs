module Client
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props

Node.require.Invoke("core-js") |> ignore
Node.require.Invoke("bootstrap/dist/css/bootstrap.css") |> ignore

ReactDom.render(R.h1[][unbox "Hello World"], Browser.document.getElementById("container")) |> ignore
