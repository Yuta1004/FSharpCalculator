open System.Text.RegularExpressions

open Lex

let recvInput =
    printf ">> "
    stdin.ReadLine()

let parse tokenList =
    printfn "%A" tokenList

let eval ast =
    Ok 0

[<EntryPoint>]
let main argv =
    let tokenDefs = [
        (new Regex("^[0-9]+", RegexOptions.Compiled), TokenKind.Num);
        (new Regex("^(\+|-|\*|/)", RegexOptions.Compiled), TokenKind.Char);
    ]

    let result =
        recvInput
        |> lex tokenDefs
        |> parse
        |> eval

    match result with
    | Ok res -> res
    | Error msg ->
        printfn "Error! %s" msg
        1
