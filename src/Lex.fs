module Lex

open System.Text.RegularExpressions

type Token<'a> = {
    kind: 'a;
    raw_str: string;
}

let lex tokenDefs target =
    let rec lexInner (s: string) =
        let fetch s =
            let check (regex: Regex, kind: 'a) =
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
