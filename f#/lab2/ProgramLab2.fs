open System

let wczytajPare () =    // Zadanie 2.2
    printfn "Podaj pierwsza liczbe:"
    let a = int (System.Console.ReadLine())
    printfn "Podaj druga liczbe:"
    let b = int (System.Console.ReadLine())
    (a, b)

let trojkat a b c =   // Zadanie 2.3
    let a = abs (float a)
    let b = abs (float b)
    let c = abs (float c)

    if (min a b + min b c) > (max a (max b c)) then
        let p = (a+b+c)/2.0
        let Pole = sqrt(p*(p-a)*(p-b)*(p-c))
        let Obwod = a+b+c
        Some (Pole, Obwod)
    else
        printfn "Nie ma trojkata o takich bokach"
        None

let RozdzielEmail (email: string) = // zadanie 2.4
    match email.Split('@') with
    | [| identyfikator; domena |] -> Some (identyfikator, domena)
    | _ -> None 

let PczEmail (email: string) = // zadanie 2.5
    match email.Split('@') with
    | [| identyfikator; domena |] ->
        if domena.ToLower() = "pcz.pl" then printfn "email uzytkownika %s nalezy do domeny PCz" identyfikator
        else printfn "email uzytkownika %s nie nalezy do domeny PCz" identyfikator
        Some (identyfikator, domena)
    | _ -> None 

let Odleglosc3D (x1, y1, z1) (x2, y2, z2) = // zadanie 2.6
    let dx = x2 - x1
    let dy = y2 - y1
    let dz = z2 - z1
    sqrt (dx*dx + dy*dy + dz*dz)


let PunktWOkregu (srodek: float * float, r: float, p: float * float) = // zadanie 2.7
    let (x0, y0) = srodek
    let (x, y) = p
    let odleglosc = sqrt ((x - x0)**2.0 + (y - y0)**2.0)
    odleglosc <= r


let skroc (a: int, b: int) = // Zadanie 2.89
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
    if a2 = 0 then failwith "Nie można dzielić przez 0"
    else skroc (a1*b2, b1*a2)


type Ulamek = { Licznik: int; Mianownik: int } // zadanie 2.9

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
    if b.Licznik = 0 then failwith "Nie można dzielić przez 0"
    else skrocUlamek { Licznik = a.Licznik * b.Mianownik; Mianownik = a.Mianownik * b.Licznik }


type Data = { Dzien: int; Miesiac: int; Rok: int } // zadanie 2.10

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



let bezpieczneDzielenie x y = //zadanie 2.11
    if y = 0.0 then None
    else Some (x / y)



type VIN = {    // zadanie 2.12
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


let poleIObwodTrojkata a b c = // zadanie 2.13
    let a, b, c = abs a, abs b, abs c
    if a + b > c && a + c > b && b + c > a then
        let obwod = a + b + c
        let p = obwod / 2.0
        let pole = sqrt (p * (p - a) * (p - b) * (p - c))
        Some (pole, obwod)
    else
        None



type Rozwiazanie = // Zadanie 2.14
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
    //Zad. 2.1
    printfn "Podaj wartosc"
    let wartosc = int (System.Console.ReadLine())
    match wartosc with 
    | 1 -> printfn "Wprowadziles %d" wartosc
    | 2 -> printfn "Wprowadziles %d" wartosc
    | 3 -> printfn "Wprowadziles %d" wartosc
    | 4 -> printfn "Wprowadziles %d" wartosc
    | _ -> printfn "Wprowadziles inna liczbe niz 1, 2, 3 lub 4"
    
    // Zadanie 2.2
    printfn "Zadanie 2.2"
    let (x, y) = wczytajPare ()
    match (x, y) with
    | (a, b) when a > b -> printfn "Pierwsza liczba (%d) jest wieksza od drugiej (%d)" a b
    | (a, b) when a < b -> printfn "Druga liczba (%d) jest wieksza od pierwszej (%d)" b a
    | (a, b) -> printfn "Obie liczby sa rowne (%d = %d)" a b



    // Zadanie 2.3
    printfn "Zadanie 2.3"
    printfn "Podaj a"
    let a = float (System.Console.ReadLine())
    printfn "Podaj b"
    let b = float (System.Console.ReadLine())
    printfn "Podaj c"
    let c = float (System.Console.ReadLine())
    match trojkat a b c with
    | Some (pole, obwod) -> printfn "Pole trojkata to: %.2f, a obwod to: %.2f" pole obwod
    | None -> printfn "Nie istnieje trojkat o bokach: %.2f, %.2f, %.2f" a b c
    
    
    // Zadanie 2.4
    printfn "Zadanie 2.4"
    printfn "Podaj adres email:"
    let email = System.Console.ReadLine()

    match RozdzielEmail email with
    | Some (ident, domena) ->
        printfn "Identyfikator użytkownika: %s" ident
        printfn "Domena: %s" domena
    | None -> printfn "Niepoprawny format adresu email."



    // Zadanie 2.5
    printfn "Zadanie 2.5"
    printfn "Podaj adres email:"
    let email = System.Console.ReadLine()
    
    match PczEmail email with
    | Some (ident, domena) ->
        printfn "Identyfikator użytkownika: %s" ident
        printfn "Domena: %s" domena
    | None -> printfn "Niepoprawny format adresu email."

    // Zadanie 2.6
    printfn "Zadanie 2.6 – Odleglosc w przestrzeni 3D"
    printfn "Podaj wspolrzedne pierwszego punktu (x1, y1, z1):"
    let x1 = float (Console.ReadLine())
    let y1 = float (Console.ReadLine())
    let z1 = float (Console.ReadLine())

    printfn "Podaj wspolrzedne drugiego punktu (x2, y2, z2):"
    let x2 = float (Console.ReadLine())
    let y2 = float (Console.ReadLine())
    let z2 = float (Console.ReadLine())

    let odleglosc = Odleglosc3D (x1, y1, z1) (x2, y2, z2)
    printfn "Odleglosc Euklidesowa: %.2f" odleglosc


    // Zadanie 2.7
    printfn "\nZadanie 2.7 – Czy punkt lezy w okregu?"
    printfn "Podaj srodek okregu (x, y):"
    let sx = float (Console.ReadLine())
    let sy = float (Console.ReadLine())

    printfn "Podaj promien okregu:"
    let r = float (Console.ReadLine())

    printfn "Podaj punkt do sprawdzenia (x, y):"
    let px = float (Console.ReadLine())
    let py = float (Console.ReadLine())

    let wewnatrz = PunktWOkregu ((sx, sy), r, (px, py))
    if wewnatrz then
        printfn "Punkt znajduje sie wewnatrz okregu."
    else
        printfn "Punkt znajduje sie POZA okregiem."


    // Zadanie 2.8
    printfn "\nZadanie 2.8 – Operacje na ulamkach (krotki)"
    printfn "Podaj pierwszy ulamek (licznik i mianownik):"
    let a1 = int (Console.ReadLine())
    let b1 = int (Console.ReadLine())

    printfn "Podaj drugi ulamek (licznik i mianownik):"
    let a2 = int (Console.ReadLine())
    let b2 = int (Console.ReadLine())

    let (n1, d1) = dodaj (a1, b1) (a2, b2)
    printfn "Suma: %d/%d" n1 d1

    let (n2, d2) = odejmij (a1, b1) (a2, b2)
    printfn "Roznica: %d/%d" n2 d2

    let (n3, d3) = mnoz (a1, b1) (a2, b2)
    printfn "Iloczyn: %d/%d" n3 d3

    let (n4, d4) = dziel (a1, b1) (a2, b2)
    printfn "Iloraz: %d/%d" n4 d4


    // Zadanie 2.9
    printfn "\nZadanie 2.9 – Operacje na ulamkach (rekordy)"
    let u1 = { Licznik = a1; Mianownik = b1 }
    let u2 = { Licznik = a2; Mianownik = b2 }

    let s = dodajUl u1 u2
    let r = odejmijUl u1 u2
    let m = mnozUl u1 u2
    let d = dzielUl u1 u2

    printfn "Suma: %d/%d" s.Licznik s.Mianownik
    printfn "Roznica: %d/%d" r.Licznik r.Mianownik
    printfn "Iloczyn: %d/%d" m.Licznik m.Mianownik
    printfn "Iloraz: %d/%d" d.Licznik d.Mianownik

    // zadanie 2.10
    printf "Podaj dzień, miesiąc, rok (oddzielone spacją): "
    let dzien, miesiac, rok = 
        let parts = System.Console.ReadLine().Split() |> Array.map int
        parts.[0], parts.[1], parts.[2]
    printfn "Dzień tygodnia: %s" (obliczDzienTygodnia { Dzien = dzien; Miesiac = miesiac; Rok = rok })

    // zadanie 2.11
    printf "Podaj dwie liczby do dzielenia: (po spacji)"
    let a, b =
        let parts = System.Console.ReadLine().Split() |> Array.map float
        parts.[0], parts.[1]
    match bezpieczneDzielenie a b with
    | Some x -> printfn "Wynik: %f" x
    | None -> printfn "Nie można dzielić przez 0"

    // zadanie 2.12
    printf "Podaj numer VIN: "
    let vin = System.Console.ReadLine()
    match dekodujVIN vin with
    | Some v -> printfn "WMI: %s, VDS: %s, VIS: %s" v.WMI v.VDS v.VIS
    | None -> printfn "Nieprawidłowy VIN"

    // zadanie 2.13
    printf "Podaj 3 boki trójkąta (oddzielone spacją): "
    let a, b, c = 
        let parts = System.Console.ReadLine().Split() |> Array.map float
        parts.[0], parts.[1], parts.[2]
    match poleIObwodTrojkata a b c with
    | Some (pole, obwod) -> printfn "Pole: %.2f, Obwód: %.2f" pole obwod
    | None -> printfn "Z podanych wartości nie da się stworzyć trójkąta"

    // zadanie 2.14
    printf "Podaj współczynniki a, b, c równania kwadratowego: "
    let a, b, c = 
        let parts = System.Console.ReadLine().Split() |> Array.map float
        parts.[0], parts.[1], parts.[2]
    match rozwiazRownanieKwadratowe a b c with
    | Brak -> printfn "Brak rozwiązań"
    | Jedno x -> printfn "Jedno rozwiązanie: x = %.2f" x
    | Dwa (x1, x2) -> printfn "Dwa rozwiązania: x1 = %.2f, x2 = %.2f" x1 x2

    0