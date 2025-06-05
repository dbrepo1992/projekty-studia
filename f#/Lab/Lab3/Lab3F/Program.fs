open System
open System.Globalization
open System.Collections.Generic

// Funkcja zwracająca listę liczb całkowitych od 1 do n
let nPierwszych (n: int) : int list = 
    [1..n]

// Funkcja generująca listę liczb całkowitych od n do m ze skokiem s
let nMinMax (n: int) (m: int) (s: int) : int list = 
    [n..s..m] 

// Funkcja zwracająca n-ty element z listy
let ntyElement (lista: int list) (n: int) : int =
    lista.[n]

// Funkcja sprawdzająca, czy lista zawiera podany element
let czyZawiera (lista: int list) (elem: int) : bool =
    List.contains elem lista

// Typ wyniku wyszukiwania indeksu
type WynikIndeksu =
    | Znaleziono of int
    | NieZnaleziono

// Funkcja znajdująca indeks podanego elementu w liście
let znajdzIndeks (lista: int list) (elem: int) : WynikIndeksu =
    match List.tryFindIndex (fun x -> x = elem) lista with
    | Some i -> Znaleziono i
    | None -> NieZnaleziono

// Funkcja usuwająca element na podanej pozycji z listy
let usunPozycje (lista: int list) (index: int) : int list =
    lista |> List.mapi (fun i x -> (i, x)) |> List.filter (fun (i, _) -> i <> index) |> List.map snd

// Funkcja obliczająca średnią z listy liczb zmiennoprzecinkowych
let srednia (lista: float list) : float =
    if List.isEmpty lista then 0.0
    else List.average lista

// Funkcja łącząca elementy tablicy stringów w jeden string z separatorem
let polacz (tablica: string array) (separator: string) : string =
    String.Join(separator, tablica)

// Funkcja zwracająca listę długości stringów
let dlugosci (lista: string list) : int list =
    lista |> List.map String.length

// Funkcja zwracająca najkrótszy i najdłuższy string z listy
let najkrotszyNajdluzszy (lista: string list) : string * string =
    let posortowana = List.sortBy String.length lista
    (List.head posortowana, List.last posortowana)

// Funkcja filtrująca żeńskie imiona (kończące się na "a" z wyjątkiem "Kuba")
let ImionaZenskie (imiona: string list) : string list =
    imiona |> List.filter (fun i -> i.EndsWith("a") && not (List.contains i ["Kuba"]))

// Funkcja odwracająca kolejność elementów listy
let OdwrocListe (lista: 'a list) : 'a list =
    List.rev lista

// Funkcja dzieląca listę imion na żeńskie i męskie
let PodzielImiona (imiona: string list) : string list * string list =
    let zenskie = ImionaZenskie imiona
    let meskie = imiona |> List.except zenskie
    (zenskie, meskie)

// Funkcja porównująca dwa elementy z dwóch list i zwracająca listę wartości logicznych (czy pierwszy > drugi)
let PorownajListy (lista1: int list) (lista2: int list) : bool list =
    if List.length lista1 <> List.length lista2 then
        failwith "Listy mają różną długość!"
    else
        List.map2 (fun a b -> a > b) lista1 lista2

// Typ oznaczający, która z list miała większy element
type Porownanie = Pierwsza | Druga

// Funkcja porównująca dwa elementy z dwóch list i zwracająca listę, która lista miała większy element
let PorownajListyTyp (lista1: int list) (lista2: int list) : Porownanie list =
    let rec porownaj l1 l2 =
        match l1, l2 with
        | [], [] -> []
        | x::xs, [] -> Pierwsza :: porownaj xs []
        | [], y::ys -> Druga :: porownaj [] ys
        | x::xs, y::ys ->
            if x > y then Pierwsza :: porownaj xs ys
            else Druga :: porownaj xs ys
    porownaj lista1 lista2

// Typ wyliczeniowy kierunku sortowania
type KierunekSortowania = Rosnaco | Malejaco

// Funkcja sprawdzająca, czy lista jest posortowana w danym kierunku
let CzyPosortowana (kierunek: KierunekSortowania) (lista: int list) : bool =
    let rec sprawdz = function
        | [] | [_] -> true
        | x :: y :: xs ->
            match kierunek with
            | Rosnaco -> x <= y && sprawdz (y::xs)
            | Malejaco -> x >= y && sprawdz (y::xs)
    sprawdz lista

// Funkcja scalająca dwie posortowane listy w jedną posortowaną listę
let ScalListe (lista1: int list) (lista2: int list) : int list =
    let rec scal l1 l2 =
        match l1, l2 with
        | [], ys -> ys
        | xs, [] -> xs
        | x::xs, y::ys when x <= y -> x :: scal xs (y::ys)
        | x::xs, y::ys -> y :: scal (x::xs) ys
    scal lista1 lista2



// === Zadanie 3.18: Implementacja stosu (LIFO) ===
type Stos<'a> = Stos of 'a list

let pustyStos = Stos []

let push x (Stos xs) = Stos (x :: xs) // dodaje element na szczyt stosu

let pop (Stos xs) = // usuwa i zwraca element ze szczytu stosu
    match xs with
    | [] -> failwith "Stos jest pusty"
    | y::ys -> (y, Stos ys)

let peek (Stos xs) = // podgląda element na szczycie stosu bez usuwania
    match xs with
    | [] -> failwith "Stos jest pusty"
    | y::_ -> y


// === Zadanie 3.19: Własna implementacja mapy (słownika) jako lista połączona ===
type ListaLaczona<'k, 'v> =
    | Pusty
    | Wezel of 'k * 'v * ListaLaczona<'k, 'v>

let pustyMap = Pusty
let mutable mapa = pustyMap

// dodaje lub nadpisuje wartość skojarzoną z kluczem
let rec dodaj klucz wartosc mapa =
    match mapa with
    | Pusty -> Wezel (klucz, wartosc, Pusty)
    | Wezel (k, v, next) when k = klucz -> Wezel (klucz, wartosc, next)
    | Wezel (k, v, next) -> Wezel (k, v, dodaj klucz wartosc next)

// wyszukuje wartość po kluczu
let rec znajdz klucz mapa =
    match mapa with
    | Pusty -> None
    | Wezel (k, v, next) ->
        if k = klucz then Some v
        else znajdz klucz next

// menu do obsługi mapy
let rec menu () =
    printfn "=== Mapa klucz-wartość ==="
    printfn "1 - Dodaj parę (klucz, wartość)"
    printfn "2 - Znajdź wartość po kluczu"
    printfn "3 - Wyjście"
    printf "Twój wybór: "
    match Console.ReadLine() with
    | "1" ->
        printf "Podaj klucz (string): "
        let klucz = Console.ReadLine()
        printf "Podaj wartość (string): "
        let wartosc = Console.ReadLine()
        mapa <- dodaj klucz wartosc mapa
        printfn "Dodano: (%s, %s)\n" klucz wartosc
        menu()
    | "2" ->
        printf "Podaj klucz do wyszukania: "
        let klucz = Console.ReadLine()
        match znajdz klucz mapa with
        | Some wartosc -> printfn "Znaleziono wartość: %s\n" wartosc
        | None -> printfn "Nie znaleziono klucza: %s\n" klucz
        menu()
    | "3" -> printfn "Zakończono obsługę mapy.\n"
    | _ ->
        printfn "Niepoprawny wybór, spróbuj ponownie.\n"
        menu()


// === Zadania 3.20–3.22: Operacje na drzewie BST ===
type Drzewo =
    | PusteDrzewo
    | Wezel of float * Drzewo * Drzewo

// przykładowe drzewo
let drzewoPrzyklad =
    Wezel(4.0,
        Wezel(2.0,
            Wezel(1.0, PusteDrzewo, PusteDrzewo),
            Wezel(3.0, PusteDrzewo, PusteDrzewo)),
        Wezel(7.0,
            PusteDrzewo,
            Wezel(8.0, PusteDrzewo, PusteDrzewo)))

// Zadanie 3.20: Liczenie liczby węzłów w drzewie
let rec liczbaElementow drz =
    match drz with
    | PusteDrzewo -> 0
    | Wezel(_, lewy, prawy) -> 1 + liczbaElementow lewy + liczbaElementow prawy

// Zadanie 3.21: Obliczanie sumy wszystkich wartości w drzewie
let rec sumaWartosci drz =
    match drz with
    | PusteDrzewo -> 0.0
    | Wezel(wart, lewy, prawy) -> wart + sumaWartosci lewy + sumaWartosci prawy

// Zadanie 3.22: Usuwanie elementu z drzewa
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


// === Zadanie 3.23: Czy drzewo zawiera wartość ===
let rec czyZawieraDrzewo x drz =
    match drz with
    | PusteDrzewo -> false
    | Wezel(wart, lewy, prawy) when x = wart -> true
    | Wezel(wart, lewy, prawy) when x < wart -> czyZawieraDrzewo x lewy
    | Wezel(_, _, prawy) -> czyZawieraDrzewo x prawy

// === Zadanie 3.24: Znajdowanie ścieżki do wartości w drzewie ===
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

// === Zadanie 3.25: Głębokość drzewa ===
let rec glebokosc drz =
    match drz with
    | PusteDrzewo -> 0
    | Wezel(_, lewy, prawy) ->
        1 + max (glebokosc lewy) (glebokosc prawy)


// === Zadania 3.26–27: Reprezentacja wyrażeń matematycznych ===
type Expr =
    | Number of float
    | Variable of string
    | UnaryFunc of string * Expr
    | Op of char * Expr * Expr

// === Zadanie 3.27–28: Ewaluacja wyrażeń (RPN, zmienne, funkcje) ===
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

// === Zadanie 3.30: Parsowanie wyrażeń w odwrotnej notacji polskiej (RPN) ===
let parseRPN (lines: string list) =
    let stack = Stack<Expr>()
    let zmienne = Dictionary<string, float>()

    for lineRaw in lines do
        let line = lineRaw.Trim()
        if line = "=" then
            () // Koniec wczytywania
        elif Double.TryParse(line, NumberStyles.Float, CultureInfo.InvariantCulture) |> fst then
            stack.Push(Number(Double.Parse(line, CultureInfo.InvariantCulture)))
        elif line = "+" || line = "-" || line = "*" || line = "/" || line = "^" then
            if stack.Count < 2 then failwithf "Operator %s wymaga dwóch operandów." line
            let b = stack.Pop()
            let a = stack.Pop()
            stack.Push(Op(line.[0], a, b))
        elif line = "sin" || line = "cos" || line = "tan" || line = "sqrt" then
            if stack.Count < 1 then failwithf "Funkcja %s wymaga jednego argumentu." line
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

// === Zadanie 3.29: Wyświetlanie zmiennych środowiska ===
let wyswietlZmienne (env: Map<string, float>) =
    if Map.isEmpty env then
        printfn "Brak zdefiniowanych zmiennych."
    else
        printfn "Zdefiniowane zmienne:"
        env |> Map.iter (fun k v -> printfn "  %s = %f" k v)


[<EntryPoint>]


let main argv =
    // === Zadanie 3.1: Generowanie listy od 1 do n ===
    printfn "\n[3.1] Generowanie listy liczb całkowitych od 1 do n:"
    printf "Podaj liczbę n: "
    let n = int (Console.ReadLine())
    let lista1 = nPierwszych n
    printfn "Wygenerowana lista: %A" lista1  

    // === Zadanie 3.2: Generowanie listy z krokiem ===
    printfn "\n[3.2] Generowanie listy od min do max ze skokiem:"
    printf "Podaj wartość początkową (min): "
    let n = int (Console.ReadLine())
    printf "Podaj wartość końcową (max): "
    let m = int (Console.ReadLine())
    printf "Podaj wartość skoku: "
    let s = int (Console.ReadLine())
    let lista2 = nMinMax n m s
    printfn "Wygenerowana lista: %A" lista2

    // === Zadanie 3.3: Pobieranie n-tego elementu z listy ===
    printfn "\n[3.3] Pobieranie elementu z listy po indeksie:"
    printf "Podaj elementy listy oddzielone spacją: "
    let lista3 = Console.ReadLine().Split() |> Array.map int |> Array.toList
    printf "Podaj indeks elementu do odczytania: "
    let indeks = int (Console.ReadLine())
    printfn "Element na pozycji %d to: %d" indeks (ntyElement lista3 indeks)

    // === Zadanie 3.4: Sprawdzenie czy lista zawiera element ===
    printfn "\n[3.4] Sprawdzenie czy lista zawiera wskazany element:"
    printf "Podaj liczbę do sprawdzenia: "
    let elem = Console.ReadLine() |> int
    let wynik = czyZawiera lista3 elem
    printfn "Czy lista zawiera %d? %b" elem wynik

    // === Zadanie 3.5: Szukanie indeksu elementu w liście ===
    printfn "\n[3.5] Wyszukiwanie indeksu wskazanej wartości:"
    printf "Podaj liczbę do znalezienia: "
    let elem = int (Console.ReadLine())
    match znajdzIndeks lista3 elem with
    | Znaleziono i -> printfn "Element %d znajduje się na pozycji: %d" elem i
    | NieZnaleziono -> printfn "Element %d nie został znaleziony w liście." elem

    // === Zadanie 3.6: Usuwanie elementu z listy po indeksie ===
    printfn "\n[3.6] Usuwanie elementu na wskazanym indeksie:"
    printf "Podaj indeks do usunięcia: "
    let indeks = int (Console.ReadLine())
    let nowaLista = usunPozycje lista3 indeks
    printfn "Lista po usunięciu elementu na pozycji %d: %A" indeks nowaLista

    // === Zadanie 3.7: Obliczanie średniej arytmetycznej ===
    printfn "\n[3.7] Obliczanie średniej z listy liczb zmiennoprzecinkowych:"
    printf "Podaj liczby oddzielone spacją: "
    let listaF = Console.ReadLine().Split() |> Array.map float |> Array.toList
    let sr = srednia listaF
    printfn "Średnia wartość: %f" sr

    // === Zadanie 3.8: Łączenie łańcuchów znaków separatorem ===
    printfn "\n[3.8] Łączenie słów separatorem:"
    printf "Podaj słowa oddzielone spacją: "
    let strArr = Console.ReadLine().Split()
    printf "Podaj separator: "
    let sep = Console.ReadLine()
    let polaczone = polacz strArr sep
    printfn "Połączony łańcuch: %s" polaczone

    // === Zadanie 3.9: Wyznaczanie długości każdego słowa ===
    printfn "\n[3.9] Długości poszczególnych słów w liście:"
    printf "Podaj słowa oddzielone spacją: "
    let strList = Console.ReadLine().Split() |> Array.toList
    let dlList = dlugosci strList
    printfn "Długości słów: %A" dlList

       // === Zadanie 3.10: Najkrótszy i najdłuższy wyraz z listy ===
    printfn "\n[3.10] Znalezienie najkrótszego i najdłuższego słowa:"
    printf "Podaj słowa oddzielone spacją: "
    let strList2 = Console.ReadLine().Split() |> Array.toList
    let (krotki, dlugi) = najkrotszyNajdluzszy strList2
    printfn "Najkrótszy wyraz: %s, Najdłuższy wyraz: %s" krotki dlugi

    // === Zadanie 3.11: Filtrowanie imion żeńskich ===
    printfn "\n[3.11] Wyszukiwanie imion żeńskich:"
    printf "Podaj listę imion oddzielonych spacją: "
    let wejscie = Console.ReadLine()
    let imiona = wejscie.Split(' ') |> Array.toList
    let zenskie = ImionaZenskie imiona
    printfn "Imiona żeńskie: %A" zenskie

    // === Zadanie 3.12: Odwrócenie listy ===
    printfn "\n[3.12] Odwrócenie elementów w liście:"
    printf "Podaj elementy listy oddzielone spacją: "
    let wejscie12 = Console.ReadLine()
    let lista12 = wejscie12.Split(' ') |> Array.toList
    let odwrocona = OdwrocListe lista12
    printfn "Odwrócona lista: %A" odwrocona

    // === Zadanie 3.13: Podział imion na żeńskie i męskie ===
    printfn "\n[3.13] Podział imion na żeńskie i męskie:"
    let (zenskie2, meskie2) = PodzielImiona imiona
    printfn "Imiona żeńskie: %A" zenskie2
    printfn "Imiona męskie: %A" meskie2

    // === Zadanie 3.14: Porównanie dwóch list element po elemencie ===
    try
        printfn "\n[3.14] Porównanie dwóch list (czy element z pierwszej > z drugiej):"
        printf "Podaj pierwszą listę liczb całkowitych (spacja): "
        let l1_14 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
        printf "Podaj drugą listę liczb całkowitych (spacja): "
        let l2_14 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
        let wynik14 = PorownajListy l1_14 l2_14
        printfn "Porównanie wyników (true jeśli pierwszy większy): %A" wynik14
    with
        | ex -> printfn "Błąd: %s" ex.Message

    // === Zadanie 3.15: Porównanie list z typem wyliczeniowym ===
    printfn "\n[3.15] Porównanie list z wyróżnieniem większego elementu:"
    printf "Podaj pierwszą listę liczb całkowitych (spacja): "
    let l1_15 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    printf "Podaj drugą listę liczb całkowitych (spacja): "
    let l2_15 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    let wynik15 = PorownajListyTyp l1_15 l2_15
    printfn "Wynik porównania (Pierwsza/Druga): %A" wynik15

    // === Zadanie 3.16: Sprawdzenie czy lista jest posortowana ===
    printfn "\n[3.16] Sprawdzenie sortowania listy:"
    printf "Podaj kierunek sortowania (rosnaco/malejaco): "
    let kier = Console.ReadLine()
    printf "Podaj listę liczb całkowitych (spacja): "
    let lista16 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    let kierunek = 
        match kier.ToLower() with
        | "rosnaco" -> Rosnaco
        | "malejaco" -> Malejaco
        | _ -> failwith "Nieprawidłowy kierunek"
    let wynik16 = CzyPosortowana kierunek lista16
    printfn "Czy lista jest posortowana (%s): %b" kier wynik16

    // === Zadanie 3.17: Scalanie dwóch posortowanych list ===
    printfn "\n[3.17] Scalanie dwóch posortowanych list w jedną:"
    printf "Podaj pierwszą posortowaną listę (spacja): "
    let l1_17 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    printf "Podaj drugą posortowaną listę (spacja): "
    let l2_17 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    let wynik17 = ScalListe l1_17 l2_17
    printfn "Scalona lista: %A" wynik17

    // === Zadanie 3.18: Symulacja stosu ===
    printfn "\n[3.18] Symulacja operacji na stosie (push/pop/peek):"
    let mutable stos = pustyStos
    let rec menuStos () =
        printfn "\nWybierz opcję: 1-push, 2-pop, 3-peek, 4-wyjście"
        match Console.ReadLine() with
        | "1" ->
            printf "Podaj wartość do wstawienia na stos: "
            let x = Console.ReadLine()
            stos <- push x stos
            printfn "Dodano \"%s\" na stos." x
            menuStos()
        | "2" ->
            try
                let (v, nowyStos) = pop stos
                stos <- nowyStos
                printfn "Usunięto ze stosu: \"%s\"" v
            with ex -> printfn "Błąd: %s" ex.Message
            menuStos()
        | "3" ->
            try
                let v = peek stos
                printfn "Na szczycie stosu: \"%s\"" v
            with ex -> printfn "Błąd: %s" ex.Message
            menuStos()
        | "4" -> printfn "Zakończono obsługę stosu."
        | _ -> 
            printfn "Niepoprawny wybór. Spróbuj ponownie."
            menuStos()
    menuStos()

    
       // === Zadanie 3.19: Prosta mapa (słownik) jako lista wiązana ===
    printfn "\n[3.19] Symulacja działania słownika (mapy):"
    menu()

    // === Zadanie 3.20: Liczba elementów w drzewie ===
    printfn "\n[3.20] Liczba elementów w drzewie:"
    printfn "Liczba elementów: %d" (liczbaElementow drzewoPrzyklad)

    // === Zadanie 3.21: Suma wartości w drzewie ===
    printfn "\n[3.21] Obliczanie sumy wartości w drzewie:"
    printfn "Suma wartości: %f" (sumaWartosci drzewoPrzyklad)

    // === Zadanie 3.22: Usunięcie elementu z drzewa ===
    printfn "\n[3.22] Usunięcie wartości z drzewa binarnego:"
    printf "Podaj wartość do usunięcia (np. 2): "
    let usun = float (Console.ReadLine())
    let drzewoPoUsunieciu = usunElement usun drzewoPrzyklad
    printfn "Liczba elementów po usunięciu: %d" (liczbaElementow drzewoPoUsunieciu)

    // === Zadanie 3.23: Sprawdzenie, czy wartość istnieje w drzewie ===
    printfn "\n[3.23] Sprawdzenie obecności wartości w drzewie:"
    printf "Podaj wartość do sprawdzenia: "
    let szukaj = float (Console.ReadLine())
    let jest = czyZawieraDrzewo szukaj drzewoPrzyklad
    printfn "Czy %f znajduje się w drzewie? %b" szukaj jest

    // === Zadanie 3.24: Ścieżka do podanej wartości w drzewie ===
    printfn "\n[3.24] Znalezienie ścieżki do wartości w drzewie:"
    printf "Podaj wartość, do której chcesz znaleźć ścieżkę: "
    let sciezkaWart = float (Console.ReadLine())
    match sciezkaDo sciezkaWart drzewoPrzyklad with
    | Some sciezka -> printfn "Ścieżka do %f: %A" sciezkaWart sciezka
    | None -> printfn "Nie znaleziono wartości %f w drzewie." sciezkaWart

    // === Zadanie 3.25: Obliczenie głębokości drzewa ===
    printfn "\n[3.25] Obliczenie głębokości drzewa:"
    printfn "Głębokość drzewa: %d" (glebokosc drzewoPrzyklad)

    // === Zadania 3.26–3.30: Kalkulator RPN (Reverse Polish Notation) ===
    printfn "\n[3.26–3.30] Kalkulator w odwrotnej notacji polskiej (RPN):"
    printfn "Podawaj elementy wyrażenia (liczby, operatory, funkcje, zmienne) w osobnych liniach."
    printfn "Wpisz '=' aby zakończyć i obliczyć wartość wyrażenia.\n"

    let rec czytaj acc =
        let line = Console.ReadLine()
        if line.Trim() = "=" then List.rev acc
        else czytaj (line :: acc)

    let linie = czytaj []

    try
        let expr, env = parseRPN linie  // [3.30] Parsowanie wyrażenia
        let wynik = Eval expr env       // [3.26–3.28] Ewaluacja wyrażenia
        printfn "\nWynik końcowy: %f" wynik

        // === Zadanie 3.29: Wyświetlanie zmiennych środowiska ===
        printfn "\nZdefiniowane zmienne:"
        wyswietlZmienne env
    with
        | ex -> printfn "\nBłąd: %s" ex.Message

    0 // zakończenie programu z kodem powodzenia
