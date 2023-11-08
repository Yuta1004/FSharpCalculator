open System.Text.RegularExpressions

let recvInput =
    printf ">> "
    stdin.ReadLine()

type TokenKind =
    | Num
    | Char

type Token = {
    kind: TokenKind;
    raw_str: string;
}

let lex tokenDefs target =
    let rec lexInner (s: string) =
        let fetch s =
            let check (regex: Regex, kind: TokenKind) =
                let m = regex.Match(s)
                if m.Success then Some ({kind = kind; raw_str = m.Value}, s[m.Length..])
                else None
            try
                List.map check tokenDefs
                |> List.find (fun x -> x.IsSome)
            with
            | _ -> None
        match fetch (s.TrimStart ' ') with
        | Some (token, remain) -> token :: lexInner remain
        | None -> []
    lexInner target

let parse tokenList =
    printfn "%A" tokenList

let eval ast =
    printfn "eval"

let main =
    let tokenDefs = [
        (new Regex("^[0-9]+", RegexOptions.Compiled), TokenKind.Num);
        (new Regex("^(\+|-|\*|/)", RegexOptions.Compiled), TokenKind.Char);
    ]

    recvInput
    |> lex tokenDefs
    |> parse
    |> eval

main
