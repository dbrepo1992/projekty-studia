open System
open Odliczanie // Import modułu do obsługi zadania 28
open Collatz    // Import modułu do obsługi zadania 29
open Srednia    // Import modułu do obsługi zadania 30

let poleKola r =    // Zadanie 1.1 – oblicza pole koła na podstawie promienia
    Math.PI * r * r

let PierwiastkiRownania a b c = // Zadanie 1.2 – rozwiązanie równania kwadratowego
    let delta = b * b - 4.0 * a * c
    if delta > 0.0 then
        let x1 = (-b + sqrt delta) / (2.0 * a)
        let x2 = (-b - sqrt delta) / (2.0 * a)
        printfn "Równanie ma dwa rozwiązania rzeczywiste: x1 = %.2f, x2 = %.2f" x1 x2
    elif delta = 0.0 then
        let x = -b / (2.0 * a)
        printfn "Równanie ma jedno rozwiązanie: x = %.2f" x
    else
        printfn "Brak rozwiązań w zbiorze liczb rzeczywistych."

let BudowaTrojkata a b c = // Zadanie 1.3 – sprawdza możliwość utworzenia trójkąta z danych boków
    let a = abs (float a)
    let b = abs (float b)
    let c = abs (float c)

    if (min a b + min b c) > (max a (max b c)) then
        printfn "Z podanych boków można zbudować trójkąt."
    else
        printfn "Nie można zbudować trójkąta z podanych boków."

let PoleTrojkata a b c = // Zadanie 1.4 – oblicza pole trójkąta za pomocą wzoru Herona
    let a = abs (float a)
    let b = abs (float b)
    let c = abs (float c)

    if (min a b + min b c) > (max a (max b c)) then
        let p = (a+b+c)/2.0
        let Pole = sqrt(p*(p-a)*(p-b)*(p-c))
        printfn "Pole trójkąta o bokach %.2f, %.2f, %.2f wynosi %.2f" a b c Pole
    else
        printfn "Nie można zbudować trójkąta z podanych boków."

let SumaPierwszychLiczb n = // Zadanie 1.5 – oblicza sumę pierwszych n liczb naturalnych
    let rec sumaN n =
        if n <= 0 then 0
        else n + sumaN (n - 1)
    let Suma = sumaN n
    printfn "Suma pierwszych %d liczb naturalnych to: %d" n Suma

let x_do_n x n = // Zadanie 1.6 – potęgowanie liczby x do potęgi n (dla n >= 0)
    if x < 0 || n < 0 then printfn "Błąd: liczby muszą być nieujemne."
    else
        let rec potega x n =
            if n <= 0 then 1.0
            else x * potega x (n - 1)
        let wynik = potega x n
        printfn "%d podniesione do potęgi %d to %.2f" x n wynik

let fibbo n = // Zadanie 1.7 – oblicza n-tą liczbę ciągu Fibonacciego
    let rec fibonacci n =
        if n <= 0 then 0
        elif n = 1 then 1
        else fibonacci (n - 1) + fibonacci (n - 2)
    let wynik = fibonacci n
    printfn "%d. element ciągu Fibonacciego to %d" n wynik

let DwumianNewtona n k = // Zadanie 1.8 – oblicza wartość dwumianu Newtona (symbol Newtona)
    if n < 0 || k < 0 || k > n then
        printfn "Błąd: n i k muszą być nieujemne oraz spełniać warunek k <= n."
    else
        let rec silnia x =
            if x <= 1 then 1
            else x * silnia (x - 1)

        let wynik = silnia n / (silnia k * silnia (n - k))
        printfn "Wartość dwumianu Newtona dla n = %d i k = %d wynosi %d" n k wynik

let JestPierwsza n = // Zadanie 1.9 – sprawdza, czy liczba n jest pierwsza
    if n < 2 then
        printfn "Liczba %d nie jest liczbą pierwszą." n
    else
        let rec dzielenie d =
            if d * d > n then true
            elif n % d = 0 then false
            else dzielenie (d + 1)

        if dzielenie 2 then
            printfn "Liczba %d jest liczbą pierwszą." n
        else
            printfn "Liczba %d nie jest liczbą pierwszą." n


let losujSzostkiProcent () = // Zadanie 1.10 – symulacja rzutów kostką i obliczenie procentu szóstek
    let rand = Random()
    let rzuty = 1000
    let mutable liczbaSzostek = 0

    for _ in 1 .. rzuty do
        let wynik = rand.Next(1, 7) 
        if wynik = 6 then
            liczbaSzostek <- liczbaSzostek + 1

    let prawdopodobienstwo = float liczbaSzostek / float rzuty * 100.0
    printfn "Szóstka wypadła %d razy na %d prób." liczbaSzostek rzuty
    printfn "Oszacowane prawdopodobieństwo: %.2f%%" prawdopodobienstwo

let losuj2SzostkiProcent () = // Zadanie 1.11 – symulacja rzutu dwiema kostkami i liczenie podwójnych szóstek
    let rand = Random()
    let rzuty = 1000
    let mutable podwojneSzostki = 0

    for _ in 1 .. rzuty do
        let k1 = rand.Next(1, 7)
        let k2 = rand.Next(1, 7)
        if k1 = 6 && k2 = 6 then
            podwojneSzostki <- podwojneSzostki + 1

    let prawdopodobienstwo = float podwojneSzostki / float rzuty * 100.0
    printfn "Podwójna szóstka wypadła %d razy na %d prób." podwojneSzostki rzuty
    printfn "Oszacowane prawdopodobieństwo: %.2f%%" prawdopodobienstwo

let NWDziel a b = // Zadanie 1.12 – obliczanie największego wspólnego dzielnika
    let rec NWD a b = 
        if b = 0 then a
        else NWD b (a % b)
    let wynik = NWD a b
    printfn "NWD dla %d i %d wynosi: %d" a b wynik

let e = 1e-7  // Dokładność obliczeń dla szeregów w zadaniach 13 i 14

let Szereg1 () = // Zadanie 1.13.1 – suma szeregu 1/n^2
    let rec Licz i =
        let wyraz = 1.0 / float(i * i)
        if wyraz < e then 0.0
        else wyraz + Licz (i + 1)
    let wynik = Licz 1
    printfn "Suma szeregu (1/n^2): %.10f" wynik

let Szereg2 () = // Zadanie 1.13.2 – suma szeregu z naprzemiennym znakiem i silnią
    let rec Licz i =
        let wyraz = (float(-1) ** float(i)) / float(fakt i)
        if abs wyraz < e then 0.0
        else wyraz + Licz (i + 1)
    and fakt n =
        if n <= 1 then 1 else n * fakt (n - 1)
    let wynik = Licz 1
    printfn "Suma szeregu z silniami: %.10f" wynik

let Szereg3 () = // Zadanie 1.13.3 – suma szeregu 1/n(n+1)
    let rec Licz i =
        let wyraz = 1.0 / float(i * (i + 1))
        if wyraz < e then 0.0
        else wyraz + Licz (i + 1)
    let wynik = Licz 1
    printfn "Suma szeregu 1/(n(n+1)): %.10f" wynik

let Szereg4 () = // Zadanie 1.13.4 – suma szeregu: (-2)^n / n!
    let rec Oblicz i suma potega silnia =
        let wyraz = potega / silnia
        if abs wyraz < e then suma
        else Oblicz (i + 1) (suma + wyraz) (potega * -2.0) (silnia * float i)
    let wynik = Oblicz 1 0.0 -2.0 1.0
    printfn "Suma szeregu (-2)^n/n!: %.10f" wynik

let Szereg1Tail () = // Zadanie 1.14.1 – wersja ogona szeregu 1/n^2
    let rec Pomoc i suma =
        let wyraz = 1.0 / float(i * i)
        if wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz)
    let wynik = Pomoc 1 0.0
    printfn "Szereg 1 (z ogonem): %.10f" wynik

let Szereg2Tail () = // Zadanie 1.14.2 – wersja ogona szeregu z silniami
    let rec Pomoc i suma znak silnia =
        let wyraz = znak / silnia
        if abs wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz) (-znak) (silnia * float i)
    let wynik = Pomoc 1 0.0 -1.0 1.0
    printfn "Szereg 2 (z ogonem): %.10f" wynik

let Szereg3Tail () = // Zadanie 1.14.3 – wersja ogona szeregu 1/n(n+1)
    let rec Pomoc i suma =
        let wyraz = 1.0 / float(i * (i + 1))
        if wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz)
    let wynik = Pomoc 1 0.0
    printfn "Szereg 3 (z ogonem): %.10f" wynik

let Szereg4Tail () = // Zadanie 1.14.4 – wersja ogona szeregu (-2)^n/n!
    let rec Pomoc i suma potega silnia =
        let wyraz = potega / silnia
        if abs wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz) (potega * -2.0) (silnia * float i)
    let wynik = Pomoc 1 0.0 -2.0 1.0
    printfn "Szereg 4 (z ogonem): %.10f" wynik

let PrzelicztemperaturyCF t = // Zadanie 1.15 – konwersja temperatury z C na F
    let T = 32.0 + t * 9.0 / 5.0
    printfn "%.2f°C to %.2f°F" t T

let PrzelicztemperaturyFC t = // Zadanie 1.16 – konwersja temperatury z F na C
    let T = (t - 32.0) * 5.0 / 9.0
    printfn "%.2f°F to %.2f°C" t T


let CzyPalindrom (slowo: string) = // Zadanie 1.17 – sprawdza, czy słowo jest palindromem
    let odwrocone = new string(Array.rev (slowo.ToCharArray()))
    if slowo = odwrocone then
        printfn "Słowo '%s' jest palindromem." slowo
    else
        printfn "Słowo '%s' nie jest palindromem." slowo

let LiczZnak tekst znak = // Zadanie 1.18 – liczy wystąpienia znaku w tekście
    let ile = tekst |> Seq.filter (fun c -> c = znak) |> Seq.length
    printfn "Znak '%c' wystąpił %d razy w podanym tekście." znak ile

let LiczbaWyrazow (tekst: string) = // Zadanie 1.19 – liczy liczbę wyrazów w tekście
    let wyrazy = tekst.Split([|' '; '\t'; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    printfn "W tekście znajduje się %d wyrazów." wyrazy.Length

let LiczbaCiagowCyfr tekst = // Zadanie 1.20 – liczy ciągi cyfr występujące pod rząd
    let rec zlicz lista czyWCiagu ile =
        match lista with
        | [] -> if czyWCiagu then ile + 1 else ile
        | x::xs ->
            if System.Char.IsDigit x then
                if czyWCiagu then zlicz xs true ile
                else zlicz xs true (ile + 1)
            else
                zlicz xs false ile
    let wynik = zlicz (List.ofSeq tekst) false 0
    printfn "W tekście znaleziono %d ciągów cyfr występujących pod rząd." wynik

let Przywitaj imie nazwisko = // Zadanie 1.21 – prosty komunikat powitalny
    printfn "Witaj %s %s!" imie nazwisko

let SprawdzRok rok = // Zadanie 1.22 – sprawdza, czy rok jest przestępny
    if rok % 4 = 0 then
        printfn "Rok %d jest przestępny." rok
    else
        printfn "Rok %d nie jest przestępny." rok

let rodzajTrojkata a b c = // Zadanie 1.23 – określa typ trójkąta
    let a = abs (float a)
    let b = abs (float b)
    let c = abs (float c)

    if (min a b + min b c) > (max a (max b c)) then
        if a = b && b = c then
            printfn "Trójkąt jest równoboczny."
        elif a = b || b = c || a = c then
            printfn "Trójkąt jest równoramienny."
        elif a * a + b * b = c * c || a * a + c * c = b * b || b * b + c * c = a * a then
            printfn "Trójkąt jest prostokątny."
        else
            printfn "Trójkąt jest różnoboczny."
    else
        printfn "Z podanych boków nie można zbudować trójkąta."

let SprawdzPesel (pesel: string) = // Zadanie 1.24 – walidacja i analiza numeru PESEL
    if pesel.Length = 11 then 
        let mutable poprawnyPesel = true
        for i in 0..10 do 
            if not (Char.IsDigit(pesel.[i])) then
                poprawnyPesel <- false
        if poprawnyPesel then
            let rok = pesel.[0..1]
            let miesiac = pesel.[2..3]
            let dzien = pesel.[4..5]
            let dataUrodzenia =
                if int rok < 26 then 
                    sprintf "20%s-%s-%s" rok miesiac dzien
                else
                    sprintf "19%s-%s-%s" rok miesiac dzien
            let plec = 
                if (int(pesel.[8].ToString())) % 2 = 0 then "Kobieta"
                else "Mężczyzna"
            printfn "Data urodzenia: %s" dataUrodzenia
            printfn "Płeć: %s" plec
        else
            printfn "Nieprawidłowy numer PESEL!"
    else
        printfn "Nieprawidłowy numer PESEL!"

let SzyfrCezaraKoduj (tekst:string) przesuniecie = // Zadanie 1.25 – szyfrowanie Cezara
    let mutable wynik = ""
    for i in 0..tekst.Length - 1 do
        let znak = tekst.[i]
        if System.Char.IsLetter(znak) then
            let baza = if System.Char.IsUpper(znak) then int 'A' else int 'a'
            let kodowany = (int znak - baza + przesuniecie) % 26 + baza
            wynik <- wynik + string(char kodowany)
        else
            wynik <- wynik + string znak
    printfn "Zakodowany tekst: %s" wynik



let SzyfrCezaraOdkoduj (tekst:string) przesuniecie = // Zadanie 1.26
    let mutable wynik = ""
    for i in 0..tekst.Length - 1 do
        let znak = tekst.[i]
        if System.Char.IsLetter(znak) then
            let baza = if System.Char.IsUpper(znak) then int 'A' else int 'a'
            let odkodowany = (int znak - baza - przesuniecie + 26) % 26 + baza
            wynik <- wynik + string(char odkodowany)
        else
            wynik <- wynik + string znak
    printfn "Odkodowany tekst: %s" wynik


let PokazGodzine minuty = // Zadanie 1.27
    if minuty < 0 || minuty >= 1440 then
        printfn "Nie ma takiej godziny w ciagu doby!"
    else
        let godzina = minuty / 60
        let minuta = minuty % 60
        printfn "Godzina: %02d:%02d" godzina minuta



// Zadanie 1.3
// Zadanie 1.3


    

[<EntryPoint>]
///////////////////////////////Zadanie 1
let main argv =
    printfn "Zadanie 1.1"
    let promien = 5.0         
    let pole = poleKola promien
    printfn "Pole koła o promieniu %.2f wynosi %.2f" promien pole 
///////////////////////////////Zadanie 2
    printfn "Zadanie 1.2"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    PierwiastkiRownania a b c
///////////////////////////////Zadanie 3
    printfn "Zadanie 1.3"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    BudowaTrojkata a b c
///////////////////////////////Zadanie 4
    printfn "Zadanie 1.4"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    PoleTrojkata a b c
///////////////////////////////Zadanie 5
    printfn "Zadanie 1.5"
    printfn "Podaj n: "
    let n = int (System.Console.ReadLine())
    SumaPierwszychLiczb n
///////////////////////////////Zadanie 6
    printfn "Zadanie 1.6"
    printfn "Podaj x: "
    let x = int (System.Console.ReadLine())
    printfn "Podaj n: "
    let n = int (System.Console.ReadLine())
    x_do_n x n
///////////////////////////////Zadanie 7
    printfn "Zadanie 1.7"
    printfn "Podaj numer wyrazu ciągu Fibonacciego:"
    let n = int (System.Console.ReadLine())
    fibbo n
///////////////////////////////Zadanie 8
    printfn "Zadanie 1.8"
    printfn "Podaj n:"
    let n = int (System.Console.ReadLine())
    printfn "Podaj k:"
    let k = int (System.Console.ReadLine())
    DwumianNewtona n k
///////////////////////////////Zadanie 9
    printfn "Zadanie 1.9"
    printfn "Podaj liczbe do sprawdzenia:"
    let n = int (System.Console.ReadLine())
    JestPierwsza n
///////////////////////////////Zadanie 10
    printfn "Zadanie 1.10"
    losujSzostkiProcent ()
///////////////////////////////Zadanie 11
    printfn "Zadanie 1.11"
    losuj2SzostkiProcent ()
///////////////////////////////Zadanie 12
    printfn "Zadanie 1.12"
    printfn "Podaj a:"
    let a = int (System.Console.ReadLine())
    printfn "Podaj b:"
    let b = int (System.Console.ReadLine())
    NWDziel a b
///////////////////////////////Zadanie 1.13
    printfn "Zadanie 1.13"
    Szereg1 ()
    Szereg2 ()
    Szereg3 ()
    Szereg4 ()
///////////////////////////////Zadanie 1.14
    printfn "Zadanie 1.14"
    Szereg1Tail ()
    Szereg2Tail ()
    Szereg3Tail ()
    Szereg4Tail ()
///////////////////////////////Zadanie 15
    printfn "Zadanie 1.15"
    printfn "Podaj temperature C:"
    let t = float (System.Console.ReadLine())
    PrzelicztemperaturyCF t
///////////////////////////////Zadanie 16
    printfn "Zadanie 1.16"
    printfn "Podaj temperature F:"
    let t = float (System.Console.ReadLine())
    PrzelicztemperaturyFC t
///////////////////////////////Zadanie 17
    // Zadanie 1.17
    printfn "Zadanie 1.17"
    printfn "Podaj slowo:"
    let slowo = System.Console.ReadLine()
    CzyPalindrom slowo

    // Zadanie 1.18
    printfn "Zadanie 1.18"
    printfn "Podaj tekst:"
    let tekst18 = System.Console.ReadLine()
    printfn "Podaj znak do zliczenia:"
    let znakStr = System.Console.ReadLine()
    let znak = if znakStr.Length > 0 then znakStr.[0] else ' '
    LiczZnak tekst18 znak

    // Zadanie 1.19
    printfn "Zadanie 1.19"
    printfn " Podaj tekst:"
    let tekst19 = System.Console.ReadLine()
    LiczbaWyrazow tekst19

    // Zadanie 1.20
    printfn "Zadanie 1.20"
    printfn "Podaj tekst (z ciagami cyfr):"
    let tekst20 = System.Console.ReadLine()
    LiczbaCiagowCyfr tekst20

///////////////////////////////Zadanie 21
    printfn "Zadanie 1.21"
    printfn "Podaj imie:"
    let imie = System.Console.ReadLine()
    printfn "Podaj nazwisko:"
    let nazwisko = System.Console.ReadLine()
    Przywitaj imie nazwisko
///////////////////////////////Zadanie 22
    printfn "Zadanie 1.22"
    printfn "Podaj rok:"
    let rok = int(System.Console.ReadLine())
    SprawdzRok rok
///////////////////////////////Zadanie 23
    printfn "Zadanie 1.23"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    rodzajTrojkata a b c
///////////////////////////////Zadanie 24
    printfn "Zadanie 1.24"
    printfn "Podaj pesel (np 0000000000): "
    let pesel = System.Console.ReadLine()
    SprawdzPesel pesel
//////////////////////////////////// Zadanie 25
    printfn "Zadanie 1.25"
    printfn "Podaj tekst do zakodowania:"
    let tekstKod = System.Console.ReadLine()
    printfn "Podaj przesuniecie:"
    let przesKod = int (System.Console.ReadLine())
    SzyfrCezaraKoduj tekstKod przesKod

//////////////////////////////////// Zadanie 26
    printfn "Zadanie 1.26"
    printfn "Podaj tekst do odkodowania:"
    let tekstDekod = System.Console.ReadLine()
    printfn "Podaj przesuniecie:"
    let przesDekod = int (System.Console.ReadLine())
    SzyfrCezaraOdkoduj tekstDekod przesDekod

//////////////////////////////////// Zadanie 27
    printfn "Zadanie 1.27"
    printfn "Podaj liczbe minut od polnocy:"
    let minuty = int (System.Console.ReadLine())
    PokazGodzine minuty


//////////////////////////////////// Zadanie 28
    printfn "Zadanie 1.28"
    printfn "Podaj liczbe minut do startu:"
    let minuty = int (System.Console.ReadLine())
    OdliczDoStartu minuty

//////////////////////////////////// Zadanie 1.29
    printfn "Zadanie 29"
    printfn "Podaj liczbe calkowita dodatnia:"
    let start = int (System.Console.ReadLine())
    CollatzStart start

//////////////////////////////////// Zadanie 1.30
    printfn "Zadanie 30"
    ObliczSrednia()


    0