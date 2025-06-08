package uczelnia;

// interface to w Java zbiór metod bez implementacji,
// które muszą zostać zaimplementowane przez klasy,
// które ten interfejs "implementują".

public interface IInfo {
    public void wypiszInfo(); //to deklaracja metody — każda klasa, która implementuje IInfo,
    // musi mieć swoją wersję metody wypiszInfo().
}

// Ten interfejs pozwala,
// żeby wiele różnych klas (np. Student, Ocena, Przedmiot) miało
// wspólną metodę info() do wypisywania informacji o sobie,
// ale każda klasa robi to po swojemu.
