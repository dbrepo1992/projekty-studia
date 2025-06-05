open System
open System.IO

// Zadanie 5.1 – definicja typu i funkcji ewaluacji

type Wyrazenie =
    | Liczba of float
    | Dodaj of Wyrazenie * Wyrazenie
    | Odejmij of Wyrazenie * Wyrazenie
    | Pomnoz of Wyrazenie * Wyrazenie
    | Podziel of Wyrazenie * Wyrazenie

let rec oblicz wyrazenie =
    match wyrazenie with
    | Liczba x -> x
    | Dodaj (a, b) -> oblicz a + oblicz b
    | Odejmij (a, b) -> oblicz a - oblicz b
    | Pomnoz (a, b) -> oblicz a * oblicz b
    | Podziel (a, b) -> oblicz a / oblicz b

// Przykład użycia:
let przyklad =
    Dodaj(
        Liczba 2.0,
        Pomnoz(
            Liczba 3.0,
            Odejmij(Liczba 5.0, Liczba 1.0)
        )
    )

printfn "5.1 Wynik: %f" (oblicz przyklad)

// Zadanie 5.2 – funkcja zamieniająca wyrażenie na string

let rec toString wyrazenie =
    match wyrazenie with
    | Liczba x -> sprintf "%.1f" x
    | Dodaj (a, b) -> sprintf "(%s + %s)" (toString a) (toString b)
    | Odejmij (a, b) -> sprintf "(%s - %s)" (toString a) (toString b)
    | Pomnoz (a, b) -> sprintf "(%s * %s)" (toString a) (toString b)
    | Podziel (a, b) -> sprintf "(%s / %s)" (toString a) (toString b)

// Przykład:
printfn "5.2 Wyrażenie: %s" (toString przyklad)

let zadanie5_3 () =
    printf "Wprowadź liczbę całkowitą (ENTER = brak wartości): "
    let input = Console.ReadLine()
    let wynik =
        if String.IsNullOrWhiteSpace input then None
        else
            match Int32.TryParse input with
            | true, n -> Some (n * n)
            | _ -> None
    match wynik with
    | Some x -> printfn "Kwadrat podanej liczby: %d" x
    | None -> printfn "Nie podałeś liczby. Brak wyniku."

let zadanie5_4 () =
    printf "Wprowadź liczbę całkowitą (ENTER = brak wartości): "
    let input = Console.ReadLine()
    input
    |> fun s -> if String.IsNullOrWhiteSpace s then None else Some s
    |> Option.bind (fun s -> match Int32.TryParse s with | true, n -> Some n | _ -> None)
    |> Option.map (fun n -> n * n)
    |> Option.iter (printfn "Kwadrat podanej liczby: %d")
    |> fun _ -> if String.IsNullOrWhiteSpace input then printfn "Nie podałeś liczby. Brak wyniku."

let zadanie5_5 () =
    printf "Wprowadź liczbę całkowitą (ENTER = użycie domyślnej 100): "
    let input = Console.ReadLine()
    let wartosc =
        if String.IsNullOrWhiteSpace input then 100
        else
            match Int32.TryParse input with
            | true, n -> n
            | _ -> 100
    printfn "Kwadrat użytej liczby: %d" (wartosc * wartosc)

let zadanie5_6 () =
    printf "Wprowadź liczbę całkowitą: "
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | true, n -> printfn "Kwadrat: %d" (n * n)
    | _ -> printfn "Błąd: wpis nie jest liczbą całkowitą."

let rec zadanie5_7 () =
    printf "Wprowadź liczbę całkowitą: "
    let input = Console.ReadLine()
    match Int32.TryParse input with
    | true, n -> printfn "Kwadrat: %d" (n * n)
    | _ ->
        printfn "Błąd: wpis nie jest liczbą całkowitą. Spróbuj ponownie."
        zadanie5_7 ()

let rec zadanie5_8 proba =
    if proba >= 4 then
        printfn "Osiągnięto limit prób. Koniec."
    else
        printf "Wprowadź liczbę całkowitą: "
        let input = Console.ReadLine()
        match Int32.TryParse input with
        | true, n -> printfn "Kwadrat: %d" (n * n)
        | _ ->
            printfn "Błąd: wpis nie jest liczbą całkowitą."
            zadanie5_8 (proba + 1)

let zadanie5_9 () =
    printf "Wprowadź liczbę całkowitą (ENTER = brak wartości): "
    let input = Console.ReadLine()
    if String.IsNullOrWhiteSpace input then
        printfn "Nie podałeś liczby. Brak wyniku."
    else
        match Int32.TryParse input with
        | true, n -> printfn "Kwadrat: %d" (n * n)
        | _ -> printfn "Błąd: wpis nie jest liczbą całkowitą."

let zadanie5_10 () =
    printf "Podaj pierwszą liczbę całkowitą: "
    let a = Console.ReadLine()
    printf "Podaj drugą liczbę całkowitą: "
    let b = Console.ReadLine()
    match Int32.TryParse a, Int32.TryParse b with
    | (true, x), (true, y) -> printfn "Suma: %d" (x + y)
    | _ -> printfn "Błąd: co najmniej jedna liczba jest niepoprawna."

let zadanie5_11 () =
    printf "Podaj pierwszą liczbę całkowitą: "
    let a = Console.ReadLine()
    match Int32.TryParse a with
    | false, _ -> printfn "Błąd: pierwsza liczba jest niepoprawna."
    | true, x ->
        printf "Podaj drugą liczbę całkowitą: "
        let b = Console.ReadLine()
        match Int32.TryParse b with
        | false, _ -> printfn "Błąd: druga liczba jest niepoprawna."
        | true, y -> printfn "Suma: %d" (x + y)

let rec zadanie5_12 () =
    printf "Podaj pierwszą liczbę całkowitą: "
    let a = Console.ReadLine()
    printf "Podaj drugą liczbę całkowitą: "
    let b = Console.ReadLine()
    match Int32.TryParse a, Int32.TryParse b with
    | (true, x), (true, y) -> printfn "Suma: %d" (x + y)
    | _ ->
        printfn "Błąd: wpisano niepoprawne dane. Spróbuj jeszcze raz."
        zadanie5_12 ()

let zadanie5_13 () =
    printf "Podaj nazwę pliku do odczytu: "
    let nazwa = Console.ReadLine()
    try
        File.ReadLines(nazwa)
        |> Seq.iteri (fun i l -> printfn "Linia %d: %s" (i + 1) l)
    with
    | ex -> printfn "Błąd podczas czytania pliku: %s" ex.Message

let zadanie5_14 () =
    printf "Podaj nazwę pliku do odczytu: "
    let nazwa = Console.ReadLine()
    printf "Ile linii chcesz wczytać? (ENTER = wszystkie): "
    let limitStr = Console.ReadLine()
    try
        let wszystkie = File.ReadLines(nazwa) |> Seq.toList
        let limit =
            if String.IsNullOrWhiteSpace limitStr then wszystkie.Length
            else match Int32.TryParse limitStr with | true, l -> min l wszystkie.Length | _ -> wszystkie.Length
        wszystkie |> List.take limit |> List.iteri (fun i l -> printfn "Linia %d: %s" (i + 1) l)
    with
    | ex -> printfn "Błąd podczas czytania pliku: %s" ex.Message

[<EntryPoint>]
let main argv =
    printfn "==> Zadanie 5.3"; zadanie5_3 ()
    printfn "==> Zadanie 5.4"; zadanie5_4 ()
    printfn "==> Zadanie 5.5"; zadanie5_5 ()
    printfn "==> Zadanie 5.6"; zadanie5_6 ()
    printfn "==> Zadanie 5.7"; zadanie5_7 ()
    printfn "==> Zadanie 5.8"; zadanie5_8 0
    printfn "==> Zadanie 5.9"; zadanie5_9 ()
    printfn "==> Zadanie 5.10"; zadanie5_10 ()
    printfn "==> Zadanie 5.11"; zadanie5_11 ()
    printfn "==> Zadanie 5.12"; zadanie5_12 ()
    printfn "==> Zadanie 5.13"; zadanie5_13 ()
    printfn "==> Zadanie 5.14"; zadanie5_14 ()
    0
