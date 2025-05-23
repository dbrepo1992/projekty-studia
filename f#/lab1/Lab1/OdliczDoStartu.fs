module OdliczDoStartu

let OdliczDoStartu minuty = // Zadanie 1.28
    let rec odlicz m =
        if m > 0 then
            printfn "Do startu pozostalo %d minut" m
            odlicz (m - 1)
        else
            printfn "START!"
    odlicz minuty
