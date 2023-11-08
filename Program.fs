open System.Text.RegularExpressions

open Lex
open Parse
open Eval

type TokenKind =
    | Num
    | Add
    | Minus
    | Mul
    | Div

[<EntryPoint>]
let main argv =
    let tokenDefs = [
        (new Regex("^[0-9]+", RegexOptions.Compiled), TokenKind.Num);
        (new Regex("^\+", RegexOptions.Compiled), TokenKind.Add);
        (new Regex("^-", RegexOptions.Compiled), TokenKind.Minus);
        (new Regex("^\*", RegexOptions.Compiled), TokenKind.Mul);
        (new Regex("^/", RegexOptions.Compiled), TokenKind.Div);
    ]

    let result =
        stdin.ReadLine()
        |> lex tokenDefs
        |> parse
        |> eval

    match result with
    | Ok res -> res
    | Error msg ->
        printfn "Error! %s" msg
        1
