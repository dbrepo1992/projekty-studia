open System
open System.IO

// Zadanie 5.3
let zadanie5_3 () =
    printf "Podaj liczbę całkowitą (możesz zostawić puste): "
    let input = Console.ReadLine()
    let wynik =
        if String.IsNullOrWhiteSpace input then None
        else
            match Int32.TryParse input with
            | true, n -> Some (n * n)
            | _ -> None
    match wynik with
    | Some x -> printfn "Kwadrat: %d" x
    | None -> printfn "Nie podałeś wartości, to ja nie podam wyniku"

// Zadanie 5.4
let zadanie5_4 () =
    printf "Podaj liczbę całkowitą (możesz zostawić puste): "
    let input = Console.ReadLine()
    input
    |> fun s -> if String.IsNullOrWhiteSpace s then None else Some s
    |> Option.bind (fun s -> match Int32.TryParse s with | true, n -> Some n | _ -> None)
    |> Option.map (fun n -> n * n)
    |> Option.iter (printfn "Kwadrat: %d")
    |> fun _ -> if input |> String.IsNullOrWhiteSpace then printfn "Nie podałeś wartości, to ja nie podam wyniku"

// Zadanie 5.5
let zadanie5_5 () =
    printf "Podaj liczbę całkowitą (możesz zostawić puste): "
    let input = Console.ReadLine()
    let wartosc =
        if String.IsNullOrWhiteSpace input then 100
        else
            match Int32.TryParse input with
            | true, n -> n
            | _ -> 100
    printfn "Kwadrat: %d" (wartosc * wartosc)

// Zadanie 5.6
let zadanie5_6 () =
    printf "Podaj liczbę całkowitą: "
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | true, n -> printfn "Kwadrat: %d" (n * n)
    | _ -> printfn "Błąd: podana wartość nie jest liczbą całkowitą"

// Zadanie 5.7
let rec zadanie5_7 () =
    printf "Podaj liczbę całkowitą: "
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | true, n -> printfn "Kwadrat: %d" (n * n)
    | _ ->
        printfn "Błąd: podana wartość nie jest liczbą całkowitą"
        zadanie5_7 ()

// Zadanie 5.8
let rec zadanie5_8 proba =
    if proba >= 4 then printfn "No ile razy można się mylić"
    else
        printf "Podaj liczbę całkowitą: "
        let input = Console.ReadLine()
        match Int32.TryParse input with
        | true, n -> printfn "Kwadrat: %d" (n * n)
        | _ ->
            printfn "Błąd: podana wartość nie jest liczbą całkowitą"
            zadanie5_8 (proba + 1)

// Zadanie 5.9
let zadanie5_9 () =
    printf "Podaj liczbę całkowitą (może być pusta): "
    let input = Console.ReadLine()
    if String.IsNullOrWhiteSpace input then
        printfn "Nie podałeś wartości, to ja nie podam wyniku"
    else
        match Int32.TryParse input with
        | true, n -> printfn "Kwadrat: %d" (n * n)
        | _ -> printfn "Błąd: podana wartość nie jest liczbą całkowitą"

// Zadanie 5.10
let zadanie5_10 () =
    printf "Podaj pierwszą liczbę: "
    let a = Console.ReadLine()
    printf "Podaj drugą liczbę: "
    let b = Console.ReadLine()
    match Int32.TryParse a, Int32.TryParse b with
    | (true, x), (true, y) -> printfn "Suma: %d" (x + y)
    | _ -> printfn "Błąd: niepoprawne dane"

// Zadanie 5.11
let zadanie5_11 () =
    printf "Podaj pierwszą liczbę: "
    let a = Console.ReadLine()
    match Int32.TryParse a with
    | false, _ -> printfn "Błąd: pierwsza liczba niepoprawna"
    | true, x ->
        printf "Podaj drugą liczbę: "
        let b = Console.ReadLine()
        match Int32.TryParse b with
        | false, _ -> printfn "Błąd: druga liczba niepoprawna"
        | true, y -> printfn "Suma: %d" (x + y)

// Zadanie 5.12
let rec zadanie5_12 () =
    printf "Podaj pierwszą liczbę: "
    let a = Console.ReadLine()
    printf "Podaj drugą liczbę: "
    let b = Console.ReadLine()
    match Int32.TryParse a, Int32.TryParse b with
    | (true, x), (true, y) -> printfn "Suma: %d" (x + y)
    | _ ->
        printfn "Błąd: podano niepoprawne dane. Spróbuj jeszcze raz."
        zadanie5_12 ()

// Zadanie 5.13
let zadanie5_13 () =
    printf "Podaj nazwę pliku: "
    let nazwa = Console.ReadLine()
    try
        File.ReadLines(nazwa)
        |> Seq.iteri (fun i l -> printfn "%d: %s" (i + 1) l)
    with
    | ex -> printfn "Błąd odczytu pliku: %s" ex.Message

// Zadanie 5.14
let zadanie5_14 () =
    printf "Podaj nazwę pliku: "
    let nazwa = Console.ReadLine()
    printf "Ile wierszy chcesz wczytać (ENTER = wszystkie): "
    let limitStr = Console.ReadLine()
    try
        let wszystkie = File.ReadLines(nazwa) |> Seq.toList
        let limit =
            if String.IsNullOrWhiteSpace limitStr then wszystkie.Length
            else match Int32.TryParse limitStr with | true, l -> min l wszystkie.Length | _ -> wszystkie.Length
        wszystkie |> List.take limit |> List.iteri (fun i l -> printfn "%d: %s" (i + 1) l)
    with
    | ex -> printfn "Błąd odczytu pliku: %s" ex.Message

// Main
[<EntryPoint>]
let main argv =
    printfn "Zadanie 5.3"; zadanie5_3 ()
    printfn "Zadanie 5.4"; zadanie5_4 ()
    printfn "Zadanie 5.5"; zadanie5_5 ()
    printfn "Zadanie 5.6"; zadanie5_6 ()
    printfn "Zadanie 5.7"; zadanie5_7 ()
    printfn "Zadanie 5.8"; zadanie5_8 0
    printfn "Zadanie 5.9"; zadanie5_9 ()
    printfn "Zadanie 5.10"; zadanie5_10 ()
    printfn "Zadanie 5.11"; zadanie5_11 ()
    printfn "Zadanie 5.12"; zadanie5_12 ()
    printfn "Zadanie 5.13"; zadanie5_13 ()
    printfn "Zadanie 5.14"; zadanie5_14 ()
    0