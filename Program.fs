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

    let exec =
        let rec executor _ =
            match stdin.ReadLine() with
            | "exit" -> 0
            | input ->
                lex tokenDefs input
                |> parse
                |> eval
                |> executor
        executor (Ok 0)

    exec
