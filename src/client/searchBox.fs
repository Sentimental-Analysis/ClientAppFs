namespace SearchBox
open System
open Fable.Core
open Fable.Import
module R = Fable.Helpers.React
open R.Props
open Dto
open Utils

module TextInputComponent =
    open JsInterop

    [<Pojo>]
    type TextInputProps = { OnSearch: string->unit; Text: string option; Placeholder: string; Search: bool}
    [<Pojo>]
    type TextInputState = { Text: string }

    type TextInput(props) as this =
        inherit React.Component<TextInputProps, TextInputState>(props)
        do base.setInitState({ Text = defaultArg this.props.Text "" })

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

module SubmitButtonComponent =
    [<Pojo>]
    type ButtonProps = { Value : string } 

    type SubmitButton(props, ctx) = 
        inherit React.Component<ButtonProps, obj>(props)
    
        member this.render() =
            R.input[
                ClassName (classNames [("btn", true); ("btn-default", true); ("btn-lg", true)])
                Type "submit"
                Value (U2.Case1 this.props.Value)
                ][]

module SearchComponent = 
    open TextInputComponent
    open SubmitButtonComponent

    [<Pojo>]
    type SearchBoxProps = { Search: string -> unit; isSearching: bool }

    type SearchBox(props) =
        inherit React.Component<SearchBoxProps, obj>(props)

        member this.render() =
            let textInput = 
               R.com<TextInput,_,_> 
                    { OnSearch = fun (text: string) -> 
                        if text.Length <> 0 then 
                            this.props.Search text
                       ; Placeholder = "Wpisz fraze"
                       ; Search = this.props.isSearching
                       ; Text = None
                   } []
            let button = R.input[
                            ClassName (classNames [("btn", true); ("btn-default", true); ("btn-lg", true)])
                            Type "submit"
                            Value (U2.Case1 "Szukaj")
                            ][]                              
            let form = R.div[ClassName (classNames [("input-group", true); ("input-group-lg", true)])] [
                        textInput
                        R.span [ClassName "input-group-btn"] [R.com<SubmitButton, _, _> { Value = "Szukaj" } []]
                    ]
            let inputGroup = R.div[ClassName "col-lg-12"][form]
            R.div [ClassName "row"] [inputGroup]                     
