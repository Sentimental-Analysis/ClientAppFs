module Reducers
open Dto

let searchReducer(state: Score) = function
    | Search(query) -> 
        ""