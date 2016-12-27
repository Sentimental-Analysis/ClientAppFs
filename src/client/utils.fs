module Utils 
let classNames = List.choose (fun (txt,add) -> if add then Some txt else None) >> String.concat " "