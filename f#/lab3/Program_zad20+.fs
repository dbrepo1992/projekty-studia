open System
open System.Globalization
open System.Collections.Generic

// Zadania 3.20-25

type Drzewo =
    | PusteDrzewo
    | Wezel of float * Drzewo * Drzewo

let drzewoPrzyklad =
    Wezel(4.0,
        Wezel(2.0,
            Wezel(1.0, PusteDrzewo, PusteDrzewo),
            Wezel(3.0, PusteDrzewo, PusteDrzewo)),
        Wezel(7.0,
            PusteDrzewo,
            Wezel(8.0, PusteDrzewo, PusteDrzewo)))


// Zadanie 3.20
let rec liczbaElementow drz =
    match drz with
    | PusteDrzewo -> 0
    | Wezel(_, lewy, prawy) -> 1 + liczbaElementow lewy + liczbaElementow prawy

// Zadanie 3.21
let rec sumaWartosci drz =
    match drz with
    | PusteDrzewo -> 0.0
    | Wezel(wart, lewy, prawy) -> wart + sumaWartosci lewy + sumaWartosci prawy

// Zadanie 3.22
let rec minElement drz =
    match drz with
    | PusteDrzewo -> failwith "Drzewo puste"
    | Wezel(wart, PusteDrzewo, _) -> wart
    | Wezel(_, lewy, _) -> minElement lewy

let rec usunElement x drz =
    match drz with
    | PusteDrzewo -> PusteDrzewo
    | Wezel(wart, lewy, prawy) when x < wart -> Wezel(wart, usunElement x lewy, prawy)
    | Wezel(wart, lewy, prawy) when x > wart -> Wezel(wart, lewy, usunElement x prawy)
    | Wezel(_, PusteDrzewo, PusteDrzewo) -> PusteDrzewo
    | Wezel(_, lewy, PusteDrzewo) -> lewy
    | Wezel(_, PusteDrzewo, prawy) -> prawy
    | Wezel(_, lewy, prawy) ->
        let minPrawy = minElement prawy
        Wezel(minPrawy, lewy, usunElement minPrawy prawy)


// Zadanie 3.23
let rec czyZawiera x drz =
    match drz with
    | PusteDrzewo -> false
    | Wezel(wart, lewy, prawy) when x = wart -> true
    | Wezel(wart, lewy, prawy) when x < wart -> czyZawiera x lewy
    | Wezel(_, _, prawy) -> czyZawiera x prawy

// Zadanie 3.24
let rec sciezkaDo wez drz =
    match drz with
    | PusteDrzewo -> None
    | Wezel(wart, lewy, prawy) when wart = wez -> Some [wart]
    | Wezel(wart, lewy, prawy) ->
        match sciezkaDo wez lewy with
        | Some sciezka -> Some (wart :: sciezka)
        | None ->
            match sciezkaDo wez prawy with
            | Some sciezka -> Some (wart :: sciezka)
            | None -> None



// Zadanie 3.25
let rec glebokosc drz =
    match drz with
    | PusteDrzewo -> 0
    | Wezel(_, lewy, prawy) ->
        1 + max (glebokosc lewy) (glebokosc prawy)



// Zadanie 3.26–27
type Expr =
    | Number of float
    | Variable of string
    | UnaryFunc of string * Expr
    | Op of char * Expr * Expr

// Zadanie 3.27–28 – ewaluacja z obsługą zmiennych i funkcji
let rec Eval expr (env: Map<string, float>) =
    match expr with
    | Number n -> n
    | Variable v ->
        match env.TryFind v with
        | Some value -> value
        | None -> failwithf "Brak wartości zmiennej: %s" v
    | UnaryFunc (name, arg) ->
        let a = Eval arg env
        match name with
        | "sin" -> Math.Sin a
        | "cos" -> Math.Cos a
        | "tan" -> Math.Tan a
        | "sqrt" -> Math.Sqrt a
        | _ -> failwithf "Nieznana funkcja: %s" name
    | Op (op, left, right) ->
        let l = Eval left env
        let r = Eval right env
        match op with
        | '+' -> l + r
        | '-' -> l - r
        | '*' -> l * r
        | '/' -> l / r
        | '^' -> Math.Pow(l, r)
        | _ -> failwithf "Nieznany operator: %c" op

// Zadanie 3.30 – parser RPN + tworzenie drzewa wyrażeń
let parseRPN (lines: string list) =
    let stack = Stack<Expr>()
    let zmienne = Dictionary<string, float>()

    for lineRaw in lines do
        let line = lineRaw.Trim()
        if line = "=" then
            () // koniec
        elif Double.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture) |> fst then
            stack.Push(Number(Double.Parse(line, CultureInfo.InvariantCulture)))
        elif line = "+" || line = "-" || line = "*" || line = "/" || line = "^" then
            if stack.Count < 2 then failwithf "Operator %s wymaga podania dwóch wartości." line
            let b = stack.Pop()
            let a = stack.Pop()
            stack.Push(Op(line.[0], a, b))
        elif line = "sin" || line = "cos" || line = "tan" || line = "sqrt" then
            if stack.Count < 1 then failwithf "Funkcja %s wymaga jednej wartości." line
            let a = stack.Pop()
            stack.Push(UnaryFunc(line, a))
        elif Char.IsLetter(line.[0]) then
            if not (zmienne.ContainsKey(line)) then
                printf $"Podaj wartość zmiennej %s{line}: "
                let wartosc = Double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture)
                zmienne.Add(line, wartosc)
            stack.Push(Variable line)
        else
            failwithf "Nieznany token: %s" line

    if stack.Count <> 1 then failwith "Niepoprawna składnia wyrażenia"

    let expr = stack.Pop()
    let env = zmienne |> Seq.map (fun kv -> kv.Key, kv.Value) |> Map.ofSeq
    expr, env

// Zadanie 3.29 – wyświetlanie zmiennych
let wyswietlZmienne (env: Map<string, float>) =
    if Map.isEmpty env then
        printfn "Brak zmiennych."
    else
        printfn "Zdefiniowane zmienne:"
        env |> Map.iter (fun k v -> printfn "  %s = %f" k v) 



[<EntryPoint>]


let main argv =
    // Zadanie 3.20
    printfn "Zadanie 3.20"
    printfn "Liczba elementów: %d" (liczbaElementow drzewoPrzyklad)

    // Zadanie 3.21
    printfn "Zadanie 3.21"
    printfn "Suma wartości: %f" (sumaWartosci drzewoPrzyklad)

    // Zadanie 3.22
    printfn "Zadanie 3.22"
    printfn "podaj wartość do usunięcia z drzewa (np. 2):"
    let usun = float (System.Console.ReadLine())
    let drzewoPoUsunieciu = usunElement usun drzewoPrzyklad
    printfn "Liczba elementów po usunięciu: %d" (liczbaElementow drzewoPoUsunieciu)

    // Zadanie 3.23
    printfn "Zadanie 3.23"
    printfn "podaj wartość do sprawdzenia, czy jest w drzewie:"
    let szukaj = float (System.Console.ReadLine())
    let jest = czyZawiera szukaj drzewoPrzyklad
    printfn "Czy %f jest w drzewie? %b" szukaj jest

    // Zadanie 3.24
    printfn "Zadanie 3.24"
    printfn "podaj wartość, do której chcesz znaleźć ścieżkę:"
    let sciezkaWart = float (System.Console.ReadLine())
    match sciezkaDo sciezkaWart drzewoPrzyklad with
    | Some sciezka -> printfn "Ścieżka do %f: %A" sciezkaWart sciezka
    | None -> printfn "Nie znaleziono wartości %f w drzewie." sciezkaWart

    // Zadanie 3.25
    printfn "Zadanie 3.25"
    printfn "głębokość drzewa: %d" (glebokosc drzewoPrzyklad)

    printfn "Zadania 3.26–3.30: Kalkulator w odwrotnej notacji polskiej"
    printfn "Podawaj elementy wyrażenia (liczby, operatory, funkcje, zmienne) w osobnych liniach"
    printfn "Wpisz '=' aby zakończyć i obliczyć wartość wyrażenia\n"

    let rec czytaj acc =
        let line = Console.ReadLine()
        if line.Trim() = "=" then List.rev acc
        else czytaj (line :: acc)

    let linie = czytaj []

    try
        let expr, env = parseRPN linie // Zadanie 3.30
        let wynik = Eval expr env      // Zadanie 3.26–3.28
        printfn "\nWynik końcowy: %f" wynik

        // Zadanie 3.29 – Wyświetlenie zmiennych
        printfn "\n"
        wyswietlZmienne env
    with
        | ex -> printfn "\nBłąd: %s" ex.Message

    0