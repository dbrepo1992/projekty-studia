open System
open System.IO

// === Zadanie 4.1: Funkcja mapuj — własna implementacja List.map ===
let rec mapuj f lst =
    match lst with
    | [] -> []
    | x::xs -> f x :: mapuj f xs

// === Zadanie 4.2: Agregowanie wartości w drzewie binarnym ===
type Drzewo<'a> =
    | Lisc of 'a
    | Wezel of Drzewo<'a> * Drzewo<'a>

let rec agreguj f drzewo =
    match drzewo with
    | Lisc x -> x
    | Wezel (l, p) -> f (agreguj f l) (agreguj f p)

// === Zadanie 4.3: Sprawdzenie, czy jakiś element w drzewie spełnia predykat ===
let rec istnieje pred drzewo =
    match drzewo with
    | Lisc x -> pred x
    | Wezel (l, p) -> istnieje pred l || istnieje pred p

// === Zadanie 4.4: Zamiana listy na drzewo zrównoważone ===
let rec listaNaDrzewo lista =
    match lista with
    | [] -> failwith "Nie można utworzyć drzewa z pustej listy"
    | [x] -> Lisc x
    | _ ->
        let polowa = List.length lista / 2
        let lewa = lista |> List.take polowa
        let prawa = lista |> List.skip polowa
        Wezel (listaNaDrzewo lewa, listaNaDrzewo prawa)

// === Zadanie 4.5: Zamiana drzewa na listę — przejście w porządku L-P ===
let rec drzewoNaListe drzewo =
    match drzewo with
    | Lisc x -> [x]
    | Wezel (l, p) -> drzewoNaListe l @ drzewoNaListe p

// === Zadanie 4.6: Podział liczb na dodatnie i ujemne ===
let podzielPlusMinus lista =
    let dodatnie = List.filter (fun x -> x > 0) lista
    let ujemne = List.filter (fun x -> x < 0) lista
    (dodatnie, ujemne)

// === Zadanie 4.7: Podział liczb względem średniej arytmetycznej ===
let podzielWgSredniej lista =
    let srednia = float (List.sum lista) / float (List.length lista)
    let powyzej = List.filter (fun x -> float x > srednia) lista
    let ponizej = List.filter (fun x -> float x < srednia) lista
    (powyzej, ponizej)

// === Zadanie 4.8: Klasyfikacja równań kwadratowych z pliku ===
let klasyfikujRownania () =
    let wiersze = File.ReadAllLines("zad8.txt")
    let podziel (a: float, b: float, c: float) =
        let delta = b * b - 4.0 * a * c
        if delta < 0.0 then 0 elif delta = 0.0 then 1 else 2
    let wspolczynniki =
        wiersze |> Array.map (fun line ->
            let parts = line.Split(" ")
            float parts[0], float parts[1], float parts[2])
    let grupy = wspolczynniki |> Array.groupBy podziel
    let get k = grupy |> Array.tryFind (fun (kl, _) -> kl = k) |> Option.defaultValue (k, [||]) |> snd
    (get 0, get 1, get 2)

// === Zadanie 4.9: Obliczanie wszystkich odległości między punktami ===
let obliczOdleglosci () =
    let punkty = File.ReadAllLines("zad9.txt") |> Array.map (fun line ->
        let parts = line.Split(" ")
        float parts[0], float parts[1])
    let dystans (x1, y1) (x2, y2) = sqrt ((x1 - x2) ** 2.0 + (y1 - y2) ** 2.0)
    let kombinacje =
        [ for i in 0 .. punkty.Length - 2 do
            for j in i+1 .. punkty.Length - 1 ->
                let p1 = punkty[i]
                let p2 = punkty[j]
                (p1, p2, dystans p1 p2) ]
        |> List.sortBy (fun (_, _, d) -> d)
    let linie = kombinacje |> List.map (fun ((x1, y1), (x2, y2), d) ->
        sprintf "(%f,%f) <-> (%f,%f) = %.4f" x1 y1 x2 y2 d)
    File.WriteAllLines("rozwiazanie9.txt", linie)

// === Zadanie 4.10: Podział punktów względem okręgu o promieniu 5 ===
let podzielWgOkregu () =
    let punkty = File.ReadAllLines("zad9.txt") |> Array.map (fun line ->
        let parts = line.Split(" ")
        float parts[0], float parts[1])
    let wewn, zewn = ResizeArray(), ResizeArray()
    for (x, y) in punkty do
        let odl = sqrt (x * x + y * y)
        if odl <= 5.0 then wewn.Add(sprintf "%f %f" x y)
        else zewn.Add(sprintf "%f %f" x y)
    File.WriteAllLines("wewnatrz.txt", wewn)
    File.WriteAllLines("poza.txt", zewn)

// === Zadanie 4.11: Statystyki (min, max, avg) dla kolumn zbioru IRIS ===
let statystykiKolumny () =
    let dane = File.ReadAllLines("iris.txt")
                |> Array.map (fun line -> line.Split(',') |> Array.take 4 |> Array.map float)
    let kolumny = Array.init 4 (fun i -> dane |> Array.map (fun row -> row.[i]))
    kolumny |> Array.map (fun kol -> Array.min kol, Array.max kol, Array.average kol)

// === Zadanie 4.12: Statystyki dla każdego gatunku osobno (IRIS) ===
let statystykiDlaGatunkow () =
    let dane = File.ReadAllLines("iris.txt") |> Array.map (fun line ->
        let parts = line.Split(',')
        parts |> Array.take 4 |> Array.map float, parts.[4])
    dane
    |> Array.groupBy snd
    |> Array.map (fun (gatunek, rekordy) ->
        let tylkoDane = rekordy |> Array.map fst
        let kolumny = Array.init 4 (fun i -> tylkoDane |> Array.map (fun row -> row.[i]))
        let staty = kolumny |> Array.map (fun kol -> Array.min kol, Array.max kol, Array.average kol)
        (gatunek, staty))

// === Zadanie 4.13: Histogram — zliczanie wystąpień liczb w liście ===
let histogramLiczb losowaLista =
    losowaLista |> List.countBy id |> Map.ofList

// === Zadanie 4.14: Histogramy wartości w kolumnach zbioru IRIS ===
let histogramyKolumn () =
    let dane = File.ReadAllLines("iris.txt") |> Array.map (fun line ->
        let parts = line.Split(',')
        parts |> Array.take 4 |> Array.map float, parts.[4])
    let histogram kol (dane: float[][]) =
        dane |> Array.map (fun row -> row.[kol]) |> Array.countBy id |> Map.ofArray
    let ogolne = [|0..3|] |> Array.map (fun i -> histogram i (dane |> Array.map fst))
    let dlaGatunkow =
        dane
        |> Array.groupBy snd
        |> Array.map (fun (gat, rekordy) ->
            let tylkoDane = rekordy |> Array.map fst
            let h = [|0..3|] |> Array.map (fun i -> histogram i tylkoDane)
            (gat, h))
    (ogolne, dlaGatunkow)

[<EntryPoint>]
let main argv =
    // Zadanie 4.1
    printfn "Zadanie 4.1"
    let lista = [1; 2; 3; 4]
    printfn "mapuj (x*2): %A" (mapuj (fun x -> x * 2) lista)

    // Zadanie 4.2
    printfn "\nZadanie 4.2"
    let drzewo = Wezel(Lisc 1, Wezel(Lisc 2, Lisc 3))
    printfn "Suma drzewa: %d" (agreguj (+) drzewo)

    // Zadanie 4.3
    printfn "\nZadanie 4.3"
    printfn "Czy w drzewie jest wartość > 2? %b" (istnieje (fun x -> x > 2) drzewo)

    // Zadanie 4.4
    printfn "\nZadanie 4.4"
    let drzewoZListy = listaNaDrzewo [1; 2; 3; 4; 5; 6; 7; 8]
    printfn "Drzewo z listy utworzone (przykładowo)"

    // Zadanie 4.5
    printfn "\nZadanie 4.5"
    let listaZDrzewa = drzewoNaListe drzewoZListy
    printfn "Lista z drzewa (in-order): %A" listaZDrzewa

    // Zadanie 4.6
    printfn "\nZadanie 4.6"
    let rand = System.Random()
    let losowaLista = List.init 20 (fun _ -> rand.Next(-10, 11))
    let (plusy, minusy) = podzielPlusMinus losowaLista
    printfn "Losowa lista: %A" losowaLista
    printfn "Dodatnie: %A" plusy
    printfn "Ujemne: %A" minusy

    // Zadanie 4.7
    printfn "\nZadanie 4.7"
    let (powyzejSredniej, ponizejSredniej) = podzielWgSredniej losowaLista
    printfn "Wartości > średnia: %A" powyzejSredniej
    printfn "Wartości < średnia: %A" ponizejSredniej

    // Zadanie 4.8
    printfn "\nZadanie 4.8"
    let (zero, jedno, dwa) = klasyfikujRownania ()
    printfn "Równania z 0 rozwiązaniami: %d" zero.Length
    printfn "Równania z 1 rozwiązaniem: %d" jedno.Length
    printfn "Równania z 2 rozwiązaniami: %d" dwa.Length

    // Zadanie 4.9
    printfn "\nZadanie 4.9"
    obliczOdleglosci ()
    printfn "Zapisano odległości w pliku 'rozwiazanie9.txt'"

    // Zadanie 4.10
    printfn "\nZadanie 4.10"
    podzielWgOkregu ()
    printfn "Zapisano punkty wewnątrz do 'wewnatrz.txt', a poza do 'poza.txt'"

    // Zadanie 4.11
    printfn "\nZadanie 4.11"
    let ogolneStaty = statystykiKolumny ()
    ogolneStaty
    |> Array.iteri (fun i (min, max, avg) ->
        printfn "Kolumna %d: min=%.2f max=%.2f avg=%.2f" (i + 1) min max avg)

    // Zadanie 4.12
    printfn "\nZadanie 4.12"
    let statyGatunkowe = statystykiDlaGatunkow ()
    for (gatunek, kolumny) in statyGatunkowe do
        printfn "Gatunek: %s" gatunek
        kolumny
        |> Array.iteri (fun i (min, max, avg) ->
            printfn "  Kolumna %d: min=%.2f max=%.2f avg=%.2f" (i + 1) min max avg)

    // Zadanie 4.13
    printfn "\nZadanie 4.13"
    let duzaLista = List.init 1000 (fun _ -> rand.Next(-10, 11))
    let mapa = histogramLiczb duzaLista
    printfn "Histogram losowych wartości:"
    mapa |> Map.iter (fun k v -> printfn "%d => %d" k v)

    // Zadanie 4.14
    printfn "\nZadanie 4.14"
    let (histKolumny, histGatunki) = histogramyKolumn ()
    printfn "Histogramy ogólne:"
    histKolumny
    |> Array.iteri (fun i h ->
        printfn "Kolumna %d: %A" (i + 1) h)

    printfn "\nHistogramy według gatunków:"
    for (gatunek, h) in histGatunki do
        printfn "Gatunek: %s" gatunek
        h |> Array.iteri (fun i m -> printfn "  Kolumna %d: %A" (i + 1) m)

    0

