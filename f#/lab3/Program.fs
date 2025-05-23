open System

// zadanie 3.1
let nPierwszych (n: int) : List<int> = 
    [1..n]

// zadanie 3.2
let nMinMax (n: int) (m: int) (s: int) : List<int> = 
    [n..s..m] 

// Zadanie 3.3
let ntyElement (lista: List<int>) (n: int) : int =
    lista.[n]

// Zadanie 3.4
let czyZawiera (lista: List<int>) (elem: int) : bool =
    List.contains elem lista

// Zadanie 3.5
type WynikIndeksu =
    | Znaleziono of int
    | NieZnaleziono

let znajdzIndeks (lista: List<int>) (elem: int) : WynikIndeksu =
    match List.tryFindIndex (fun x -> x = elem) lista with
    | Some i -> Znaleziono i
    | None -> NieZnaleziono

// Zadanie 3.6
let usunPozycje (lista: List<int>) (index: int) : List<int> =
    lista |> List.mapi (fun i x -> (i, x)) |> List.filter (fun (i, _) -> i <> index) |> List.map snd

// Zadanie 3.7
let srednia (lista: List<float>) : float =
    if List.isEmpty lista then 0.0
    else List.average lista

// Zadanie 3.8
let polacz (tablica: string array) (separator: string) : string =
    String.Join(separator, tablica)

// Zadanie 3.9
let dlugosci (lista: List<string>) : List<int> =
    lista |> List.map String.length

// Zadanie 3.10
let najkrotszyNajdluzszy (lista: List<string>) : string * string =
    let posortowana = List.sortBy String.length lista
    (List.head posortowana, List.last posortowana)


// Zadanie 3.11
let ImionaZenskie (imiona: List<string>) : List<string> =
    imiona |> List.filter (fun i -> i.EndsWith("a") && not (List.contains i ["Kuba"]))

// Zadanie 3.12 
let OdwrocListe (lista: List<'a>) : List<'a> =
    List.rev lista

// Zadanie 3.13
let PodzielImiona (imiona: List<string>) : List<string> * List<string> =
    let zenskie = ImionaZenskie imiona
    let meskie = imiona |> List.except zenskie
    (zenskie, meskie)

// Zadanie 3.14
let PorownajListy (lista1: List<int>) (lista2: List<int>) : List<bool> =
    if List.length lista1 <> List.length lista2 then
        failwith "Listy mają różną długość!"
    else
        List.map2 (fun a b -> a > b) lista1 lista2


// Zadanie 3.15
type Porownanie = Pierwsza | Druga

let PorownajListyTyp (lista1: List<int>) (lista2: List<int>) : List<Porownanie> =
    let rec porownaj l1 l2 =
        match l1, l2 with
        | [], [] -> []
        | x::xs, [] -> Pierwsza :: porownaj xs []
        | [], y::ys -> Druga :: porownaj [] ys
        | x::xs, y::ys ->
            if x > y then Pierwsza :: porownaj xs ys
            else Druga :: porownaj xs ys
    porownaj lista1 lista2



// Zadanie 3.16
type KierunekSortowania = Rosnaco | Malejaco

let CzyPosortowana (kierunek: KierunekSortowania) (lista: List<int>) : bool =
    let rec sprawdz = function
        | [] | [_] -> true
        | x :: y :: xs ->
            match kierunek with
            | Rosnaco -> x <= y && sprawdz (y::xs)
            | Malejaco -> x >= y && sprawdz (y::xs)
    sprawdz lista

// Zadanie 3.17
let ScalListe (lista1: List<int>) (lista2: List<int>) : List<int> =
    let rec scal l1 l2 =
        match l1, l2 with
        | [], ys -> ys
        | xs, [] -> xs
        | x::xs, y::ys when x <= y -> x :: scal xs (y::ys)
        | x::xs, y::ys -> y :: scal (x::xs) ys
    scal lista1 lista2


// Zadanie 3.18
type Stos<'a> = Stos of List<'a>

let pustyStos = Stos []

let push x (Stos xs) = Stos (x :: xs)

let pop (Stos xs) =
    match xs with
    | [] -> failwith "Stos jest pusty"
    | y::ys -> (y, Stos ys)

let peek (Stos xs) =
    match xs with
    | [] -> failwith "Stos jest pusty"
    | y::_ -> y


// Zadanie 3.19
type ListaLaczona<'k, 'v> =
    | Pusty
    | Wezel of 'k * 'v * ListaLaczona<'k, 'v>

let pustyMap = Pusty

let mutable mapa = pustyMap

let rec dodaj klucz wartosc mapa =
    match mapa with
    | Pusty -> Wezel (klucz, wartosc, Pusty)
    | Wezel (k, v, next) when k = klucz -> Wezel (klucz, wartosc, next) // nadpisz
    | Wezel (k, v, next) -> Wezel (k, v, dodaj klucz wartosc next)


let rec znajdz klucz mapa =
    match mapa with
    | Pusty -> None
    | Wezel (k, v, next) ->
        if k = klucz then Some v
        else znajdz klucz next


let rec menu () =
        printfn "Wybierz opcję:"
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
            printfn "Dodano parę (%s, %s)" klucz wartosc
            menu()
        | "2" ->
            printf "Podaj klucz do wyszukania: "
            let klucz = Console.ReadLine()
            match znajdz klucz mapa with
            | Some wartosc -> printfn "Wartość dla klucza '%s' to: %s" klucz wartosc
            | None -> printfn "Nie znaleziono wartości dla klucza '%s'" klucz
            menu()
        | "3" -> printfn "Koniec programu."
        | _ ->
            printfn "Niepoprawny wybór, spróbuj ponownie."
            menu()

[<EntryPoint>]


let main argv =
    //Zadanie 3.1
    printfn "Zadanie 3.1"
    printfn "Podaj liczbe "
    let n = int (System.Console.ReadLine())
    let lista = nPierwszych n
    printfn "%A" lista  


    //Zadanie 3.2
    printfn "Zadanie 3.2"
    printfn "Podaj min "
    let n = int (System.Console.ReadLine())
    printfn "Podaj max "
    let m = int (System.Console.ReadLine())
    printfn "Podaj skok "
    let s = int (System.Console.ReadLine())
    let lista = nMinMax n m s
    printfn "%A" lista  

    // Zadanie 3.3
    printfn "Zadanie 3.3 "
    printfn " Podaj elementy listy oddzielone spacją:"
    let lista = Console.ReadLine().Split() |> Array.map int |> Array.toList
    printfn "Podaj indeks elementu:"
    let indeks = int (Console.ReadLine())
    printfn "Element na pozycji %d to: %d" indeks (ntyElement lista indeks)

    // Zadanie 3.4
    printfn "Zadanie 3.4"
    printfn " Podaj element do sprawdzenia (int):"
    let elem = Console.ReadLine() |> int
    let wynik = czyZawiera lista elem
    printfn "Czy element znajduje się na liście: %b" wynik

    // Zadanie 3.5
    printfn "Zadanie 3.5"
    printfn "Podaj element do znalezienia indeksu:"
    let elem = int (Console.ReadLine())
    match znajdzIndeks lista elem with
    | Znaleziono i -> printfn "Znaleziono na pozycji: %d" i
    | NieZnaleziono -> printfn "Nie znaleziono elementu."

    // Zadanie 3.6
    printfn "Zadanie 3.6"
    printfn "Podaj indeks do usunięcia:"
    let indeks = int (Console.ReadLine())
    let nowaLista = usunPozycje lista indeks
    printfn "Lista po usunięciu elementu: %A" nowaLista

    // Zadanie 3.7
    printfn "Zadanie 3.7"
    printfn "Podaj liczby (float) oddzielone spacją:"
    let listaF = Console.ReadLine().Split() |> Array.map float |> Array.toList
    let sr = srednia listaF
    printfn "Średnia wynosi: %f" sr

    // Zadanie 3.8
    printfn "Zadanie 3.8"
    printfn "Podaj stringi oddzielone spacją:"
    let strArr = Console.ReadLine().Split()
    printfn "Podaj separator:"
    let sep = Console.ReadLine()
    let polaczone = polacz strArr sep
    printfn "Połączony łańcuch: %s" polaczone

    // Zadanie 3.9
    printfn "Zadanie 3.9"
    printfn "Podaj stringi oddzielone spacją:"
    let strList = Console.ReadLine().Split() |> Array.toList
    let dlList = dlugosci strList
    printfn "Długości słów: %A" dlList

    // Zadanie 3.10
    printfn "Zadanie 3.10"
    printfn "Podaj stringi oddzielone spacją:"
    let strList2 = Console.ReadLine().Split() |> Array.toList
    let (krotki, dlugi) = najkrotszyNajdluzszy strList2
    printfn "Najkrótszy wyraz: %s, Najdłuższy wyraz: %s" krotki dlugi

    // Zadanie 3.11
    printfn "Zadanie 3.11"
    printfn "Podaj imiona oddzielone spacją:"
    let wejscie = Console.ReadLine()
    let imiona = wejscie.Split(' ') |> Array.toList
    let zenskie = ImionaZenskie imiona
    printfn "Imiona żeńskie: %A" zenskie

    // Zadanie 3.12
    printfn "Zadanie 3.12"
    printfn "Podaj elementy listy oddzielone spacją:"
    let wejscie12 = Console.ReadLine()
    let lista12 = wejscie12.Split(' ') |> Array.toList
    let odwrocona = OdwrocListe lista12
    printfn "Odwrócona lista: %A" odwrocona

    // Zadanie 3.13
    printfn "Zadanie 3.13"
    let (zenskie2, meskie2) = PodzielImiona imiona
    printfn "Imiona żeńskie: %A" zenskie2
    printfn "Imiona męskie: %A" meskie2

    // Zadanie 3.14
    try
        printfn "Zadanie 3.14"
        printfn "Podaj pierwszą listę liczb całkowitych (spacja):"
        let l1_14 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
        printfn "Podaj drugą listę liczb całkowitych (spacja):"
        let l2_14 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
        let wynik14 = PorownajListy l1_14 l2_14
        printfn "Porównanie list (true = pierwsza większa): %A" wynik14
    with
        | ex -> printfn "Błąd: %s" ex.Message

    // Zadanie 3.15
    printfn "Zadanie 3.15"
    printfn "Podaj pierwszą listę liczb całkowitych (spacja):"
    let l1_15 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    printfn "Podaj drugą listę liczb całkowitych (spacja):"
    let l2_15 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    let wynik15 = PorownajListyTyp l1_15 l2_15
    printfn "Porównanie list z typem wyliczeniowym: %A" wynik15

    // Zadanie 3.16
    printfn "Zadanie 3.16"
    printfn "Podaj kierunek sortowania (rosnaco/malejaco):"
    let kier = Console.ReadLine()
    printfn "Podaj listę liczb całkowitych (spacja):"
    let lista16 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    let kierunek = 
        match kier.ToLower() with
        | "rosnaco" -> Rosnaco
        | "malejaco" -> Malejaco
        | _ -> failwith "Nieprawidłowy kierunek"
    let wynik16 = CzyPosortowana kierunek lista16
    printfn "Czy lista jest posortowana: %b" wynik16

    // Zadanie 3.17
    printfn "Zadanie 3.17"
    printfn "Podaj pierwszą posortowaną listę liczb całkowitych (spacja):"
    let l1_17 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    printfn "Podaj drugą posortowaną listę liczb całkowitych (spacja):"
    let l2_17 = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
    let wynik17 = ScalListe l1_17 l2_17
    printfn "Scalona lista: %A" wynik17

    // Zadanie 3.18 
    let mutable stos = pustyStos
    printfn "Zadanie 3.18"
    let rec menuStos () =
        printfn "Wybierz opcję: 1-push, 2-pop, 3-peek, 4-wyjście"
        match Console.ReadLine() with
        | "1" ->
            printfn "Podaj wartość do wstawienia:"
            let x = Console.ReadLine()
            stos <- push x stos
            printfn "Dodano %s do stosu." x
            menuStos()
        | "2" ->
            try
                let (v, nowyStos) = pop stos
                stos <- nowyStos
                printfn "Usunięto %s ze stosu." v
            with
                | ex -> printfn "%s" ex.Message
            menuStos()
        | "3" ->
            try
                let v = peek stos
                printfn "Na szczycie stosu jest: %s" v
            with
                | ex -> printfn "%s" ex.Message
            menuStos()
        | "4" -> ()
        | _ -> 
            printfn "Nieznana opcja"
            menuStos()
    menuStos()
    
    // Zadanie 3.19
    menu()
    
    0