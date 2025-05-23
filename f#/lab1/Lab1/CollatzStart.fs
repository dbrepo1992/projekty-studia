module CollatzStart

let CollatzStart n =
    let rec petla liczba krok =
        printfn "%d. %d" krok liczba
        if liczba > 1 then
            let nowa =
                if liczba % 2 = 0 then liczba / 2
                else 3 * liczba + 1
            petla nowa (krok + 1)
    petla n 1
