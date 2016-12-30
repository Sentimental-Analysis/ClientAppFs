module App
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props
open Dto
open SearchBox
open Http

[<Pojo>]
type AppProps = { Store: Redux.IStore<Score, Actions> }

[<Pojo>]
type AppState = { Score: Score; Dispatch: Actions->unit }

let dispatch func url =
   request (Get(url)) (SearchFulfilled >> func) (SearchRejected >> func) |> ignore


type AppComponent(props) as this =
    inherit React.Component<AppProps, obj>(props)   
    let getState() = { Score = this.props.Store.getState(); Dispatch = this.props.Store.dispatch }
    do base.setInitState(getState())
    do this.props.Store.subscribe(getState >> this.setState)

    member this.render() = 
        let searchBox = R.com<SearchComponent.SearchBox, _, _> { Search = dispatch(this.props.Store.dispatch); isSearching = false } []
        R.div [] [searchBox] 