namespace SearchBox
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props
open Dto
open Utils

module TextInputBox =
    open JsInterop

    [<Pojo>]
    type TextInputProps = { OnSearch: string->unit; Text: string option; Placeholder: string; Search: bool}
    [<Pojo>]
    type TextInputState = { Text: string }

    type TextInput(props) =
        inherit React.Component<TextInputProps, TextInputState>(props)
        do base.setInitState({ Text = "" })

        member this.HandleSubmit(e: React.KeyboardEvent) =
            if e.which = ENTER_KEY then 
                let text = (unbox<string> e.target?value).Trim()
                this.props.OnSearch(text)
                if this.props.Search then 
                    this.setState({ Text = "" })
        
        member this.HandleChange(e: React.SyntheticEvent) =
            this.setState({ Text = unbox e.target?value })
    
        member this.HandleBlur(e: React.SyntheticEvent) =
            if not this.props.Search then
                this.props.OnSearch(unbox e.target?value)

        member this.render() =
            R.input[
                ClassName (classNames[("input-lg", true); ("form-control", true)])
                Type "text"
                OnBlur this.HandleBlur
                OnChange this.HandleChange
                OnKeyDown this.HandleSubmit
                AutoFocus (this.state.Text.Length > 0)
                Placeholder this.props.Placeholder
            ] []

module SubmitButton =
    [<Pojo>]
    type ButtonProps = { Value : string } 

    type ButtonComponent(props, ctx) = 
        inherit React.Component<ButtonProps, obj>(props)
    
        member this.render() =
            R.input[
                ClassName (classNames [("btn", true); ("btn-default", true); ("btn-lg", true)])
                Type "submit"
                Value (U2.Case1 this.props.Value)
                ][]
                
module SearchContainer = 
    [<Pojo>]
    type SearchBoxProps = { Search: string -> unit; isSearching: bool }
