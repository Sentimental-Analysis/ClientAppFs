#r "../packages/Suave/lib/net40/Suave.dll"

open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators
open Suave.Files
open Suave.Sockets
open Suave.Sockets.Control
open Suave.WebSocket

let app : WebPart =
    choose [ GET >=> choose [ path "/" >=> file "./index.html"; browseHome ]
             RequestErrors.NOT_FOUND "Found no handlers." ]   