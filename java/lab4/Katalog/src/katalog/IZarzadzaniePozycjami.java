package katalog;

public interface IZarzadzaniePozycjami {
    void DodajPozycje(Pozycja p);
    Pozycja ZnajdzPozycjePoTytule(String tytul);
    Pozycja ZnajdzPozycjePoId(int id);
    void WypiszWszystkiePozycje();
}
