open System

let wczytajPare () =    // Zadanie 2.2 – pobranie dwóch liczb całkowitych od użytkownika
    printfn "Wprowadź pierwszą liczbę:"
    let a = int (System.Console.ReadLine())
    printfn "Wprowadź drugą liczbę:"
    let b = int (System.Console.ReadLine())
    (a, b)

let trojkat a b c =   // Zadanie 2.3 – obliczenie pola i obwodu trójkąta, jeśli możliwy
    let a = abs (float a)
    let b = abs (float b)
    let c = abs (float c)

    if (min a b + min b c) > (max a (max b c)) then
        let p = (a+b+c)/2.0
        let Pole = sqrt(p*(p-a)*(p-b)*(p-c))
        let Obwod = a+b+c
        Some (Pole, Obwod)
    else
        printfn "Z podanych boków nie można utworzyć trójkąta."
        None

let RozdzielEmail (email: string) = // Zadanie 2.4 – rozdziela adres e-mail na użytkownika i domenę
    match email.Split('@') with
    | [| identyfikator; domena |] -> Some (identyfikator, domena)
    | _ -> None 

let PczEmail (email: string) = // Zadanie 2.5 – sprawdzenie przynależności adresu do domeny PCz
    match email.Split('@') with
    | [| identyfikator; domena |] ->
        if domena.ToLower() = "pcz.pl" then printfn "Adres '%s' należy do domeny PCz." identyfikator
        else printfn "Adres '%s' nie należy do domeny PCz." identyfikator
        Some (identyfikator, domena)
    | _ -> None 

let Odleglosc3D (x1, y1, z1) (x2, y2, z2) = // Zadanie 2.6 – oblicza dystans pomiędzy punktami 3D
    let dx = x2 - x1
    let dy = y2 - y1
    let dz = z2 - z1
    sqrt (dx*dx + dy*dy + dz*dz)

let PunktWOkregu (srodek: float * float, r: float, p: float * float) = // Zadanie 2.7 – sprawdza przynależność punktu do okręgu
    let (x0, y0) = srodek
    let (x, y) = p
    let odleglosc = sqrt ((x - x0)**2.0 + (y - y0)**2.0)
    odleglosc <= r

let skroc (a: int, b: int) = // Zadanie 2.8 – skraca ułamek jako krotkę liczb całkowitych
    let rec NWD x y =
        if y = 0 then abs x else NWD y (x % y)
    let nwd = NWD a b
    (a / nwd, b / nwd)

let dodaj (a1, b1) (a2, b2) =
    skroc (a1*b2 + a2*b1, b1*b2)

let odejmij (a1, b1) (a2, b2) =
    skroc (a1*b2 - a2*b1, b1*b2)

let mnoz (a1, b1) (a2, b2) =
    skroc (a1*a2, b1*b2)

let dziel (a1, b1) (a2, b2) =
    if a2 = 0 then failwith "Nie można dzielić przez zero."
    else skroc (a1*b2, b1*a2)

type Ulamek = { Licznik: int; Mianownik: int } // Zadanie 2.9 – definicja rekordu dla ułamka

let skrocUlamek u =
    let rec NWD x y =
        if y = 0 then abs x else NWD y (x % y)
    let nwd = NWD u.Licznik u.Mianownik
    { Licznik = u.Licznik / nwd; Mianownik = u.Mianownik / nwd }

let dodajUl a b =
    skrocUlamek { Licznik = a.Licznik * b.Mianownik + b.Licznik * a.Mianownik
                  Mianownik = a.Mianownik * b.Mianownik }

let odejmijUl a b =
    skrocUlamek { Licznik = a.Licznik * b.Mianownik - b.Licznik * a.Mianownik
                  Mianownik = a.Mianownik * b.Mianownik }

let mnozUl a b =
    skrocUlamek { Licznik = a.Licznik * b.Licznik; Mianownik = a.Mianownik * b.Mianownik }

let dzielUl a b =
    if b.Licznik = 0 then failwith "Nie można dzielić przez zero."
    else skrocUlamek { Licznik = a.Licznik * b.Mianownik; Mianownik = a.Mianownik * b.Licznik }

type Data = { Dzien: int; Miesiac: int; Rok: int } // Zadanie 2.10 – struktura daty

let czyRokPrzestepny rok =
    (rok % 4 = 0 && rok % 100 <> 0) || (rok % 400 = 0)

let liczbaDniWMiesiacu miesiac rok =
    match miesiac with
    | 1 | 3 | 5 | 7 | 8 | 10 | 12 -> 31
    | 4 | 6 | 9 | 11 -> 30
    | 2 -> if czyRokPrzestepny rok then 29 else 28
    | _ -> 0

let dniTygodnia = [| "Poniedzialek"; "Wtorek"; "Sroda"; "Czwartek"; "Piatek"; "Sobota"; "Niedziela" |]

let obliczDzienTygodnia (data: Data) =
    let rec liczDni (rok, miesiac) =
        if rok < 1990 then 0
        elif rok = 1990 && miesiac = 1 then 0
        elif miesiac = 1 then liczbaDniWMiesiacu 12 (rok - 1) + liczDni (rok - 1, 12)
        else liczbaDniWMiesiacu (miesiac - 1) rok + liczDni (rok, miesiac - 1)

    let dniOd1990 = liczDni (data.Rok, data.Miesiac) + data.Dzien - 1
    dniTygodnia.[dniOd1990 % 7]

let bezpieczneDzielenie x y = // Zadanie 2.11 – dzielenie z obsługą błędu przez zero
    if y = 0.0 then None
    else Some (x / y)

type VIN = {    // Zadanie 2.12 – struktura identyfikatora pojazdu
    WMI: string       
    VDS: string       
    VIS: string       
}

let dekodujVIN (vin: string) =
    if vin.Length = 17 then
        Some {
            WMI = vin.Substring(0, 3)
            VDS = vin.Substring(3, 6)
            VIS = vin.Substring(9, 8)
        }
    else
        None

let poleIObwodTrojkata a b c = // Zadanie 2.13 – oblicza pole i obwód trójkąta, jeśli możliwe
    let a, b, c = abs a, abs b, abs c
    if a + b > c && a + c > b && b + c > a then
        let obwod = a + b + c
        let p = obwod / 2.0
        let pole = sqrt (p * (p - a) * (p - b) * (p - c))
        Some (pole, obwod)
    else
        None

type Rozwiazanie = // Zadanie 2.14 – możliwe przypadki rozwiązania równania kwadratowego
    | Brak
    | Jedno of float
    | Dwa of float * float

let rozwiazRownanieKwadratowe a b c =
    let delta = b*b - 4.0*a*c
    if a = 0.0 then
        if b = 0.0 then Brak
        else Jedno (-c / b)
    elif delta < 0.0 then Brak
    elif delta = 0.0 then
        let x = -b / (2.0 * a)
        Jedno x
    else
        let sqrtDelta = sqrt delta
        let x1 = (-b - sqrtDelta) / (2.0 * a)
        let x2 = (-b + sqrtDelta) / (2.0 * a)
        Dwa (x1, x2)


[<EntryPoint>]
let main argv =
    // Zadanie 2.1 – wczytaj wartość i dopasuj do znanych przypadków
    printfn "Wpisz liczbę:"
    let wartosc = int (System.Console.ReadLine())
    match wartosc with 
    | 1 | 2 | 3 | 4 -> printfn "Wprowadzono wartość: %d" wartosc
    | _ -> printfn "Wartość różna od 1, 2, 3 lub 4"

    // Zadanie 2.2 – porównanie dwóch liczb
    printfn "\nZadanie 2.2"
    let (x, y) = wczytajPare ()
    match (x, y) with
    | (a, b) when a > b -> printfn "Pierwsza liczba (%d) jest większa od drugiej (%d)" a b
    | (a, b) when a < b -> printfn "Druga liczba (%d) jest większa od pierwszej (%d)" b a
    | (a, b) -> printfn "Obie liczby są sobie równe: %d = %d" a b

    // Zadanie 2.3 – sprawdzenie trójkąta i obliczenia
    printfn "\nZadanie 2.3"
    printfn "Podaj długość boku a:"
    let a = float (System.Console.ReadLine())
    printfn "Podaj długość boku b:"
    let b = float (System.Console.ReadLine())
    printfn "Podaj długość boku c:"
    let c = float (System.Console.ReadLine())
    match trojkat a b c with
    | Some (pole, obwod) -> printfn "Pole trójkąta: %.2f, Obwód: %.2f" pole obwod
    | None -> printfn "Nie można utworzyć trójkąta z boków: %.2f, %.2f, %.2f" a b c

    // Zadanie 2.4 – analiza adresu e-mail
    printfn "\nZadanie 2.4"
    printfn "Podaj adres e-mail do analizy:"
    let email = System.Console.ReadLine()
    match RozdzielEmail email with
    | Some (ident, domena) ->
        printfn "Nazwa użytkownika: %s" ident
        printfn "Domena e-mail: %s" domena
    | None -> printfn "Adres e-mail ma niepoprawny format."

    // Zadanie 2.5 – sprawdzenie domeny PCz
    printfn "\nZadanie 2.5"
    printfn "Podaj adres e-mail do weryfikacji domeny:"
    let email = System.Console.ReadLine()
    ignore (PczEmail email)

    // Zadanie 2.6 – odległość między punktami 3D
    printfn "\nZadanie 2.6 – Odległość między punktami 3D"
    printfn "Wprowadź współrzędne punktu A (x, y, z):"
    let x1 = float (Console.ReadLine())
    let y1 = float (Console.ReadLine())
    let z1 = float (Console.ReadLine())
    printfn "Wprowadź współrzędne punktu B (x, y, z):"
    let x2 = float (Console.ReadLine())
    let y2 = float (Console.ReadLine())
    let z2 = float (Console.ReadLine())
    let odleglosc = Odleglosc3D (x1, y1, z1) (x2, y2, z2)
    printfn "Odległość między punktami wynosi: %.2f" odleglosc

    // Zadanie 2.7 – sprawdzenie czy punkt należy do okręgu
    printfn "\nZadanie 2.7 – Czy punkt znajduje się w okręgu?"
    printfn "Wprowadź współrzędne środka okręgu (x, y):"
    let sx = float (Console.ReadLine())
    let sy = float (Console.ReadLine())
    printfn "Podaj promień okręgu:"
    let r = float (Console.ReadLine())
    printfn "Wprowadź współrzędne punktu (x, y):"
    let px = float (Console.ReadLine())
    let py = float (Console.ReadLine())
    let wewnatrz = PunktWOkregu ((sx, sy), r, (px, py))
    if wewnatrz then
        printfn "Punkt leży wewnątrz lub na okręgu."
    else
        printfn "Punkt znajduje się poza okręgiem."

    // Zadanie 2.8 – działania na ułamkach (krotki)
    printfn "\nZadanie 2.8 – Operacje na ułamkach jako krotki"
    printfn "Podaj licznik i mianownik pierwszego ułamka:"
    let a1 = int (Console.ReadLine())
    let b1 = int (Console.ReadLine())
    printfn "Podaj licznik i mianownik drugiego ułamka:"
    let a2 = int (Console.ReadLine())
    let b2 = int (Console.ReadLine())
    printfn "Suma: %d/%d" (fst (dodaj (a1, b1) (a2, b2))) (snd (dodaj (a1, b1) (a2, b2)))
    printfn "Różnica: %d/%d" (fst (odejmij (a1, b1) (a2, b2))) (snd (odejmij (a1, b1) (a2, b2)))
    printfn "Iloczyn: %d/%d" (fst (mnoz (a1, b1) (a2, b2))) (snd (mnoz (a1, b1) (a2, b2)))
    printfn "Iloraz: %d/%d" (fst (dziel (a1, b1) (a2, b2))) (snd (dziel (a1, b1) (a2, b2)))

    // Zadanie 2.9 – działania na ułamkach jako rekordy
    printfn "\nZadanie 2.9 – Operacje na ułamkach jako rekordy"
    let u1 = { Licznik = a1; Mianownik = b1 }
    let u2 = { Licznik = a2; Mianownik = b2 }
    printfn "Suma: %d/%d" (dodajUl u1 u2).Licznik (dodajUl u1 u2).Mianownik
    printfn "Różnica: %d/%d" (odejmijUl u1 u2).Licznik (odejmijUl u1 u2).Mianownik
    printfn "Iloczyn: %d/%d" (mnozUl u1 u2).Licznik (mnozUl u1 u2).Mianownik
    printfn "Iloraz: %d/%d" (dzielUl u1 u2).Licznik (dzielUl u1 u2).Mianownik

    // Zadanie 2.10 – oblicz dzień tygodnia na podstawie daty
    printf "\nWprowadź datę (dzień miesiąc rok): "
    let dzien, miesiac, rok = 
        let parts = System.Console.ReadLine().Split() |> Array.map int
        parts.[0], parts.[1], parts.[2]
    printfn "Dzień tygodnia to: %s" (obliczDzienTygodnia { Dzien = dzien; Miesiac = miesiac; Rok = rok })

    // Zadanie 2.11 – bezpieczne dzielenie
    printf "\nWprowadź dwie liczby (oddzielone spacją): "
    let a, b = 
        let parts = System.Console.ReadLine().Split() |> Array.map float
        parts.[0], parts.[1]
    match bezpieczneDzielenie a b with
    | Some x -> printfn "Wynik dzielenia: %.2f" x
    | None -> printfn "Błąd: dzielenie przez zero"

    // Zadanie 2.12 – dekodowanie numeru VIN
    printf "\nPodaj numer VIN: "
    let vin = System.Console.ReadLine()
    match dekodujVIN vin with
    | Some v -> printfn "WMI: %s, VDS: %s, VIS: %s" v.WMI v.VDS v.VIS
    | None -> printfn "Błędny numer VIN."

    // Zadanie 2.13 – pole i obwód trójkąta
    printf "\nPodaj trzy boki trójkąta: "
    let a, b, c = 
        let parts = System.Console.ReadLine().Split() |> Array.map float
        parts.[0], parts.[1], parts.[2]
    match poleIObwodTrojkata a b c with
    | Some (pole, obwod) -> printfn "Pole: %.2f, Obwód: %.2f" pole obwod
    | None -> printfn "Nie można utworzyć trójkąta z podanych długości."

    // Zadanie 2.14 – rozwiązanie równania kwadratowego
    printf "\nWprowadź współczynniki równania kwadratowego (a b c): "
    let a, b, c = 
        let parts = System.Console.ReadLine().Split() |> Array.map float
        parts.[0], parts.[1], parts.[2]
    match rozwiazRownanieKwadratowe a b c with
    | Brak -> printfn "Równanie nie ma rozwiązań."
    | Jedno x -> printfn "Jedno rozwiązanie: x = %.2f" x
    | Dwa (x1, x2) -> printfn "Dwa rozwiązania: x1 = %.2f, x2 = %.2f" x1 x2

    0