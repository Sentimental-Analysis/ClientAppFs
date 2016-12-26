module Http
open System
open Fable.Core
open Fable.Import
open Fable.Import.Browser

type HttpMethod<'a> = 
    | Get of url: string
    | Post of url: string * data: 'a


let request meth onSuccess onError =
    let url, http, data =
        match meth with
        | Get url -> url, "GET", None
        | Post (url, data) -> url, "POST", Some(JS.JSON.stringify data)
    
    let req = XMLHttpRequest.Create()

    req.onreadystatechange <- fun _ ->
        if req.readyState = 4. then
            match req.status  with
            | 200. | 0. -> JS.JSON.parse req.responseText |> unbox |> onSuccess
            | _ -> req.statusText |> onError
        null
    
    req.``open``(http, url, true)
    req.send(data)