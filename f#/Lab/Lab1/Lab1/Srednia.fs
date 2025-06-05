module Srednia

let ObliczSrednia () =
    let rec petla suma licznik =
        printfn "Podaj liczbe (ujemna konczy):"
        let wejscie = int (System.Console.ReadLine())
        if wejscie < 0 then
            if licznik = 0 then
                printfn "Nie podano zadnej liczby dodatniej."
            else
                let wynik = float suma / float licznik
                printfn "Srednia wynosi: %.2f" wynik
        else
            petla (suma + wejscie) (licznik + 1)
    petla 0 0
