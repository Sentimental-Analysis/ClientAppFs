module Dto

type Sentiment =
    | Negative = 0
    | Neutral = 1
    | Positive = 2

type Localization = {longitude: double; latitude: double}

type Keyword = {key: string; quantity: int}

type Score = {keyWords: Keyword[]
              negativeTweetsQuantity: int
              positiveTweetsQuantity: int
              sentiment: Sentiment
              localizations: Localization[]
              key: string}


type Result<'a> = { value: 'a; isSuccess: bool; messages: string[] }

type Actions =
    | Search of string


let [<Literal>] ESCAPE_KEY = 27.
let [<Literal>] ENTER_KEY = 13.
