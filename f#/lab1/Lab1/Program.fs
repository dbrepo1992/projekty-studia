open System
open OdliczDoStartu // Plik do zadania 28
open CollatzStart    // Plik do zadania 29
open ObliczSrednia    // Plik do zadania 30


let poleKola r =    //Zadanie 1.1
    Math.PI * r * r


let rozwiazRownanieKwadratowe wspA wspB wspC = // Zadanie 1.2 - rozwiązanie równania kwadratowego
    let wyrDelta = wspB * wspB - 4.0 * wspA * wspC
    if wyrDelta > 0.0 then
        let pierw1 = (-wspB + sqrt wyrDelta) / (2.0 * wspA)
        let pierw2 = (-wspB - sqrt wyrDelta) / (2.0 * wspA)
        printfn "Równanie posiada dwa pierwiastki: x1 = %.2f oraz x2 = %.2f" pierw1 pierw2
    elif wyrDelta = 0.0 then
        let jedenPierw = -wspB / (2.0 * wspA)
        printfn "Równanie ma jeden pierwiastek: x = %.2f" jedenPierw
    else
        printfn "Brak pierwiastków rzeczywistych"



let czyMozliwyTrojkat bokA bokB bokC = // Zadanie 1.3 - sprawdzenie możliwości utworzenia trójkąta
    let bok1 = abs (float bokA)
    let bok2 = abs (float bokB)
    let bok3 = abs (float bokC)

    if (min bok1 bok2 + min bok2 bok3) > (max bok1 (max bok2 bok3)) then
        printfn "Mozna zbudowac trojkat"
    else
        printfn "Nie mozna utworzyc trojkata o podanych bokach"

let obliczPoleTrojkata bokA bokB bokC = // Zadanie 1.4 - obliczanie pola trójkąta (wzór Herona)
    let dlugA = abs (float bokA)
    let dlugB = abs (float bokB)
    let dlugC = abs (float bokC)

    if (min dlugA dlugB + min dlugB dlugC) > (max dlugA (max dlugB dlugC)) then
        let polowaObwodu = (dlugA + dlugB + dlugC) / 2.0
        let pole = sqrt(polowaObwodu * (polowaObwodu - dlugA) * (polowaObwodu - dlugB) * (polowaObwodu - dlugC))
        printfn "Pole trojkata o bokach: %.2f, %.2f, %.2f wynosi %.2f" dlugA dlugB dlugC pole
    else
        printfn "Nie istnieje trojkat o podanych bokach"

        
let obliczSumeNaturalnych ilosc = // Zadanie 1.5 - suma kolejnych liczb naturalnych
    let rec sumaDo n =
        if n <= 0 then 0
        else n + sumaDo (n - 1)
    let wynikSuma = sumaDo ilosc
    printfn "Suma %d pierwszych liczb naturalnych to %d" ilosc wynikSuma



let podniesDoPotegi x n = // Zadanie 1.6 - potęgowanie liczby naturalnej
    if x < 0 || n < 0 then
        printfn "Jedna z liczb znajduje sie poza zakresem!"
    else
        let rec poteguj x n =
            if n <= 0 then 1.0 // Zwraca 1.0, bo wynik ma być typu float
            else x * poteguj x (n - 1)
        let wynikPotegi = poteguj (float x) n
        printfn "Wynik %d do potęgi %d to %.2f" x n wynikPotegi


let obliczFibonacciego n = // Zadanie 1.7 - wyliczanie n-tego elementu ciągu Fibonacciego
    let rec fib n =
        if n <= 0 then 0
        elif n = 1 then 1
        else fib (n - 1) + fib (n - 2)
    let element = fib n
    printfn "%d liczba ciagu Fibonacciego to = %d" n element
  


let wyliczDwumianNewtona n k = // Zadanie 1.8 - obliczanie wartości dwumianu Newtona
    if n < 0 || k < 0 || k > n then
        printfn "n i k muszą być nieujemne oraz k <= n"
    else
        let rec silnia x =
            if x <= 1 then 1
            else x * silnia (x - 1)

        let wynik = silnia n / (silnia k * silnia (n - k))
        printfn "Wynik dwumianu Newtona dla n = %d oraz k = %d to %d" n k wynik



let sprawdzCzyPierwsza n = // Zadanie 1.9 - sprawdzanie czy liczba jest pierwsza
    if n < 2 then
        printfn "Liczba %d nie jest pierwsza" n
    else
        let rec dzielenie d =
            if d * d > n then true
            elif n % d = 0 then false
            else dzielenie (d + 1)

        if dzielenie 2 then
            printfn "Liczba %d jest pierwsza" n
        else
            printfn "Liczba %d nie jest pierwsza" n


let symulujSzostkiJednaKostka () = // Zadanie 1.10 - symulacja rzucania jedną kostką i liczenie szóstek
    let rand = Random()
    let rzuty = 1000
    let mutable liczbaSzostek = 0

    for _ in 1 .. rzuty do
        let wynik = rand.Next(1, 7) 
        if wynik = 6 then
            liczbaSzostek <- liczbaSzostek + 1

    let prawdopodobienstwo = float liczbaSzostek / float rzuty * 100.0
    printfn "Wyrzucono szóstkę %d razy na %d rzutów." liczbaSzostek rzuty
    printfn "Prawdopodobieństwo wyrzucenia szóstki: %.2f%%" prawdopodobienstwo



let symulujSzostkiDwieKostki () = // Zadanie 1.11 - symulacja rzucania dwiema kostkami i liczenie podwójnych szóstek
    let rand = Random()
    let rzuty = 1000
    let mutable podwojneSzostki = 0

    for _ in 1 .. rzuty do
        let k1 = rand.Next(1, 7)
        let k2 = rand.Next(1, 7)
        if k1 = 6 && k2 = 6 then
            podwojneSzostki <- podwojneSzostki + 1

    let prawdopodobienstwo = float podwojneSzostki / float rzuty * 100.0
    printfn "Dwie szóstki wyrzucono %d razy na %d rzutów." podwojneSzostki rzuty
    printfn "Prawdopodobieństwo wyrzucenia dwóch szóstek: %.2f%%" prawdopodobienstwo



let znajdzNWD a b = // Zadanie 1.12 - obliczanie największego wspólnego dzielnika (NWD)
    let rec NWD a b = 
        if b = 0 then a
        else NWD b (a % b)
    let wynik = NWD a b
    printfn "Największy wspólny dzielnik %d i %d to %d" a b wynik


let e = 1e-7  // dokładność dla zadań 13 i 14

let obliczSumeSzeregu1 () = // Zadanie 1.13.1 - suma nieskończonego szeregu: ∑ 1/(i^2)
    let rec Licz i =
        let wyraz = 1.0 / float(i * i)
        if wyraz < e then 0.0
        else wyraz + Licz (i + 1)
    let wynik = Licz 1
    printfn "Suma szeregu 1 to: %.10f" wynik



let obliczSumeSzeregu2 () = // Zadanie 1.13.2 - suma szeregu naprzemiennego z odwrotnościami silni
    let rec Licz i =
        let wyraz = (float(-1) ** float(i)) / float(fakt i)
        if abs wyraz < e then 0.0
        else wyraz + Licz (i + 1)
    and fakt n =
        if n <= 1 then 1 else n * fakt (n - 1)
    let wynik = Licz 1
    printfn "Suma szeregu 2 to: %.10f" wynik



let obliczSumeSzeregu3 () = // Zadanie 1.13.3 - suma szeregu z wyrazami 1 / (i(i+1))
    let rec Licz i =
        let wyraz = 1.0 / float(i * (i + 1))
        if wyraz < e then 0.0
        else wyraz + Licz (i + 1)
    let wynik = Licz 1
    printfn "Suma szeregu 3 to: %.10f" wynik



let obliczSumeSzeregu4 () = // Zadanie 1.13.4 - suma szeregu potęgowanego z naprzemiennym znakiem
    let rec Oblicz i suma potega silnia =
        let wyraz = potega / silnia
        if abs wyraz < e then suma
        else Oblicz (i + 1) (suma + wyraz) (potega * -2.0) (silnia * float i)
    let wynik = Oblicz 1 0.0 -2.0 1.0
    printfn "Suma szeregu 4 to: %.10f" wynik


let obliczSzereg1ZOgona () = // Zadanie 1.14.1 - wersja ogonowa obliczania sumy szeregu 1
    let rec Pomoc i suma =
        let wyraz = 1.0 / float(i * i)
        if wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz)
    let wynik = Pomoc 1 0.0
    printfn "Szereg 1 (tail): %.10f" wynik



let obliczSzereg2ZOgona () = // Zadanie 1.14.2 - obliczanie sumy szeregu 2 z rekurencją ogonową
    let rec Pomoc i suma znak silnia =
        let wyraz = znak / silnia
        if abs wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz) (-znak) (silnia * float i)
    let wynik = Pomoc 1 0.0 -1.0 1.0
    printfn "Szereg 2 (tail): %.10f" wynik


let obliczSzereg3ZOgona () = // Zadanie 1.14.3 - wersja ogonowa sumowania szeregu 1 / (i(i+1))
    let rec Pomoc i suma =
        let wyraz = 1.0 / float(i * (i + 1))
        if wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz)
    let wynik = Pomoc 1 0.0
    printfn "Szereg 3 (tail): %.10f" wynik



let obliczSzereg4ZOgona () = // Zadanie 1.14.4 - ogonowa wersja sumowania szeregu potęgowego
    let rec Pomoc i suma potega silnia =
        let wyraz = potega / silnia
        if abs wyraz < e then suma
        else Pomoc (i + 1) (suma + wyraz) (potega * -2.0) (silnia * float i)
    let wynik = Pomoc 1 0.0 -2.0 1.0
    printfn "Szereg 4 (tail): %.10f" wynik



let konwertujCnaF t = // Zadanie 1.15 - konwersja temperatury z Celsjusza na Fahrenheita
    let T = 32.0 + t * 9.0 / 5.0
    printfn "%.2f stopni celsjusza to %.2f farenhaita" t T

let konwertujFnaC t = // Zadanie 1.16 - konwersja temperatury z Fahrenheita na Celsjusza
    let T = (t - 32.0) * 5.0 / 9.0
    printfn "%.2f stopni farenhaita to %.2f celsjusza" t T




let sprawdzPalindrom (slowo: string) = // Zadanie 1.17 - sprawdzenie czy słowo jest palindromem
    let odwrocone = new string(Array.rev (slowo.ToCharArray()))
    if slowo = odwrocone then
        printfn "Slowo '%s' jest palindromem" slowo
    else
        printfn "Slowo '%s' nie jest palindromem" slowo

let zliczWystapieniaZnaku tekst znak = // Zadanie 1.18 - zliczanie wystąpień znaku w tekście
    let ile = tekst |> Seq.filter (fun c -> c = znak) |> Seq.length
    printfn "Znak '%c' wystapil %d razy w tekscie" znak ile

let policzLiczbeWyrazow (tekst: string) = // Zadanie 1.19 - zliczanie wyrazów w tekście
    let wyrazy = tekst.Split([|' '; '\t'; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    printfn "W tekscie znajduje sie %d wyrazow" wyrazy.Length

let policzCiagiCyfr tekst = // Zadanie 1.20 - zliczanie grup cyfr występujących pod rząd
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
    printfn "W tekscie znaleziono %d ciagow cyfr wystepujacych pod rzad" wynik

let przywitajUzytkownika imie nazwisko = // Zadanie 1.21 - powitanie użytkownika
    printfn "Witaj '%s' '%s' " imie nazwisko

let sprawdzCzyRokPrzestepny rok = // Zadanie 1.22 - sprawdzenie roku przestępnego
    if rok % 4 = 0 then printfn "Rok %d jest przestepny!" rok
    else printfn "Rok %d nie jest przestepny!" rok



let okreslTypTrojkata a b c = // Zadanie 1.23 - określenie rodzaju trójkąta
    let a = abs (float a)
    let b = abs (float b)
    let c = abs (float c)

    if (min a b + min b c) > (max a (max b c)) then
        if a = b && b = c then
            printfn "Trojkat jest rownoboczny"
        elif a = b || b = c || a = c then
            printfn "Trojkat jest rownoramienny"
        elif a * a + b * b = c * c || a * a + c * c = b * b || b * b + c * c = a * a then
            printfn "Trojkat jest prostokatny"
        else
            printfn "Trojkat jest zwykly (roznoboczny)"
    else
        printfn "Nie ma trojkata o takich bokach"

let rozkodujPesel (pesel: string) = // Zadanie 1.24 - analiza numeru PESEL
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
                else "Mezczyzna"
            printfn "Data urodzenia: %s" dataUrodzenia
            printfn "Plec: %s" plec
        else
            printfn "Nieprawidlowy numer PESEL!"
    else
        printfn "Nieprawidlowy numer PESEL!"

let zakodujCezarem (tekst:string) przesuniecie = // Zadanie 1.25 - szyfrowanie Cezarem
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

let odkodujCezarem (tekst:string) przesuniecie = // Zadanie 1.26 - deszyfrowanie Cezarem
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



let wyswietlGodzineZMinut minuty = // Zadanie 1.27 - przekształcenie minut na godzinę i minutę
    if minuty < 0 || minuty >= 1440 then
        printfn "Nie ma takiej godziny w ciagu doby!"
    else
        let godzina = minuty / 60
        let minuta = minuty % 60
        printfn "Godzina: %02d:%02d" godzina minuta




    

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
    rozwiazRownanieKwadratowe a b c
///////////////////////////////Zadanie 3
    printfn "Zadanie 1.3"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    czyMozliwyTrojkat a b c
///////////////////////////////Zadanie 4
    printfn "Zadanie 1.4"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    obliczPoleTrojkata a b c
///////////////////////////////Zadanie 5
    printfn "Zadanie 1.5"
    printfn "Podaj n: "
    let n = int (System.Console.ReadLine())
    obliczSumeNaturalnych n
///////////////////////////////Zadanie 6
    printfn "Zadanie 1.6"
    printfn "Podaj x: "
    let x = int (System.Console.ReadLine())
    printfn "Podaj n: "
    let n = int (System.Console.ReadLine())
    podniesDoPotegi x n
///////////////////////////////Zadanie 7
    printfn "Zadanie 1.7"
    printfn "Podaj numer wyrazu ciągu Fibonacciego:"
    let n = int (System.Console.ReadLine())
    obliczFibonacciego n
///////////////////////////////Zadanie 8
    printfn "Zadanie 1.8"
    printfn "Podaj n:"
    let n = int (System.Console.ReadLine())
    printfn "Podaj k:"
    let k = int (System.Console.ReadLine())
    wyliczDwumianNewtona n k
///////////////////////////////Zadanie 9
    printfn "Zadanie 1.9"
    printfn "Podaj liczbe do sprawdzenia:"
    let n = int (System.Console.ReadLine())
    sprawdzCzyPierwsza n
///////////////////////////////Zadanie 10
    printfn "Zadanie 1.10"
    symulujSzostkiJednaKostka ()
///////////////////////////////Zadanie 11
    printfn "Zadanie 1.11"
    symulujSzostkiDwieKostki ()
///////////////////////////////Zadanie 12
    printfn "Zadanie 1.12"
    printfn "Podaj a:"
    let a = int (System.Console.ReadLine())
    printfn "Podaj b:"
    let b = int (System.Console.ReadLine())
    znajdzNWD a b
///////////////////////////////Zadanie 1.13
    printfn "Zadanie 1.13"
    obliczSumeSzeregu1 ()
    obliczSumeSzeregu2 ()
    obliczSumeSzeregu3 ()
    obliczSumeSzeregu4 ()
///////////////////////////////Zadanie 1.14
    printfn "Zadanie 1.14"
    obliczSzereg1ZOgona ()
    obliczSzereg2ZOgona ()
    obliczSzereg3ZOgona ()
    obliczSzereg4ZOgona ()
///////////////////////////////Zadanie 15
    printfn "Zadanie 1.15"
    printfn "Podaj temperature C:"
    let t = float (System.Console.ReadLine())
    konwertujCnaF t
///////////////////////////////Zadanie 16
    printfn "Zadanie 1.16"
    printfn "Podaj temperature F:"
    let t = float (System.Console.ReadLine())
    konwertujFnaC t
///////////////////////////////Zadanie 17
    // Zadanie 1.17
    printfn "Zadanie 1.17"
    printfn "Podaj slowo:"
    let slowo = System.Console.ReadLine()
    sprawdzPalindrom slowo

    // Zadanie 1.18
    printfn "Zadanie 1.18"
    printfn "Podaj tekst:"
    let tekst18 = System.Console.ReadLine()
    printfn "Podaj znak do zliczenia:"
    let znakStr = System.Console.ReadLine()
    let znak = if znakStr.Length > 0 then znakStr.[0] else ' '
    zliczWystapieniaZnaku tekst18 znak

    // Zadanie 1.19
    printfn "Zadanie 1.19"
    printfn " Podaj tekst:"
    let tekst19 = System.Console.ReadLine()
    policzLiczbeWyrazow tekst19

    // Zadanie 1.20
    printfn "Zadanie 1.20"
    printfn "Podaj tekst (z ciagami cyfr):"
    let tekst20 = System.Console.ReadLine()
    policzCiagiCyfr tekst20

///////////////////////////////Zadanie 21
    printfn "Zadanie 1.21"
    printfn "Podaj imie:"
    let imie = System.Console.ReadLine()
    printfn "Podaj nazwisko:"
    let nazwisko = System.Console.ReadLine()
    przywitajUzytkownika imie nazwisko
///////////////////////////////Zadanie 22
    printfn "Zadanie 1.22"
    printfn "Podaj rok:"
    let rok = int(System.Console.ReadLine())
    sprawdzCzyRokPrzestepny rok
///////////////////////////////Zadanie 23
    printfn "Zadanie 1.23"
    printfn "Podaj a: "
    let a = float (System.Console.ReadLine())
    printfn "Podaj b: "
    let b = float (System.Console.ReadLine())
    printfn "Podaj c: "
    let c = float (System.Console.ReadLine())
    okreslTypTrojkata a b c
///////////////////////////////Zadanie 24
    printfn "Zadanie 1.24"
    printfn "Podaj pesel (np 0000000000): "
    let pesel = System.Console.ReadLine()
    rozkodujPesel pesel
//////////////////////////////////// Zadanie 25
    printfn "Zadanie 1.25"
    printfn "Podaj tekst do zakodowania:"
    let tekstKod = System.Console.ReadLine()
    printfn "Podaj przesuniecie:"
    let przesKod = int (System.Console.ReadLine())
    zakodujCezarem tekstKod przesKod

//////////////////////////////////// Zadanie 26
    printfn "Zadanie 1.26"
    printfn "Podaj tekst do odkodowania:"
    let tekstDekod = System.Console.ReadLine()
    printfn "Podaj przesuniecie:"
    let przesDekod = int (System.Console.ReadLine())
    odkodujCezarem tekstDekod przesDekod

//////////////////////////////////// Zadanie 27
    printfn "Zadanie 1.27"
    printfn "Podaj liczbe minut od polnocy:"
    let minuty = int (System.Console.ReadLine())
    wyswietlGodzineZMinut minuty


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