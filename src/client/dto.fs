module Dto
open Fable.Core

[<Literal>]
let BaseUrl = "http://138.91.185.214"

[<Erase>]
type Sentiment =
    | Negative = 0
    | Neutral = 1
    | Positive = 2

[<Pojo>]
type Localization = {longitude: double; latitude: double}
[<Pojo>]
type Keyword = {key: string; quantity: int}
[<Pojo>]
type Score = {keyWords: Keyword[]
              negativeTweetsQuantity: int
              positiveTweetsQuantity: int
              sentiment: Sentiment
              localizations: Localization[]
              key: string}

[<Pojo>]
type Result<'a> = { value: 'a; isSuccess: bool; messages: string[] }

type Actions =
    | SearchFulfilled of Score
    | SearchRejected of string

let [<Literal>] ESCAPE_KEY = 27.
let [<Literal>] ENTER_KEY = 13.
