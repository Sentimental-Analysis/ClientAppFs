namespace SearchBox
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props
module TextInputBox =
    [<Pojo>]
    type ITextInputProps =
        abstract OnSearch: string->unit
        abstract Text: string option
        abstract Placeholder: string
        abstract Search: bool

module SearchContainer = 
    [<Pojo>]
    type SearchBoxProps = { Search: string -> unit; isSearching: bool }
