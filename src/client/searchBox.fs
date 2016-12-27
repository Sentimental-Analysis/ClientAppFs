namespace SearchBox
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props
module TextInputBox =
    [<Pojo>]
    type TextInputProps = { OnSearch: string->unit; Text: string option; Placeholder: string; Search: bool}
    [<Pojo>]
    type TextInputState = { Text: string }

    type TextInput(props) =
        inherit React.Component<TextInputProps, TextInputState>(props)
        do base.setInitState({ Text = "" }) 


module SearchContainer = 
    [<Pojo>]
    type SearchBoxProps = { Search: string -> unit; isSearching: bool }
