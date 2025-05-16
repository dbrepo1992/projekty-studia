package katalog;

public class Main {
    public static void main(String[] args) {
        Autor autor1 = new Autor("Adam", "Mickiewicz");
        Autor autor2 = new Autor("Henryk", "Sienkiewicz");
        Autor autor3 = new Autor("Maria", "Konopnicka");

        Ksiazka ksiazka1 = new Ksiazka("Pan Tadeusz", 101, "PWN", 1834, 300, autor1);
        Ksiazka ksiazka2 = new Ksiazka("Quo Vadis", 102, "PWN", 1896, 280, autor2);
        Ksiazka ksiazka3 = new Ksiazka("Roty", 103, "Czytelnik", 1908, 150, autor3);
        Czasopismo czas1 = new Czasopismo("National Geographic", 201, "NG Polska", 2024, 5);
        Czasopismo czas2 = new Czasopismo("Scientific American", 202, "Prószyński i S-ka", 2023, 12);

        Biblioteka biblioteka = new Biblioteka();
        biblioteka.DodajPozycje("Literatura Polska", ksiazka1);
        biblioteka.DodajPozycje("Literatura Polska", ksiazka2);
        biblioteka.DodajPozycje("Literatura Polska", ksiazka3);
        biblioteka.DodajPozycje("Czasopisma", czas1);
        biblioteka.DodajPozycje("Czasopisma", czas2);

        System.out.println("\n== Wszystkie pozycje w bibliotece ==");
        biblioteka.WypiszWszystkiePozycje();

        // Szukanie po tytule
        String tytulSzukany = "Quo Vadis";
        System.out.println("\n== Szukam pozycji o tytule: " + tytulSzukany + " ==");
        Pozycja znaleziona = biblioteka.ZnajdzPozycjePoTytule(tytulSzukany);
        if (znaleziona != null) {
            znaleziona.WypiszInfo();
            String dzial = biblioteka.znajdzKatalogDlaPozycji(znaleziona);
            System.out.println("Znaleziono w dziale: " + dzial);
        } else {
            System.out.println("Nie znaleziono pozycji o podanym tytule.");
        }

        // Szukanie po ID
        int szukaneId = 202;
        System.out.println("\n== Szukam pozycji o ID: " + szukaneId + " ==");
        Pozycja znalezionaPoId = biblioteka.ZnajdzPozycjePoId(szukaneId);
        if (znalezionaPoId != null) {
            znalezionaPoId.WypiszInfo();
            String dzial = biblioteka.znajdzKatalogDlaPozycji(znalezionaPoId);
            System.out.println("Znaleziono w dziale: " + dzial);
        } else {
            System.out.println("Nie znaleziono pozycji o podanym ID.");
        }
    }
}
