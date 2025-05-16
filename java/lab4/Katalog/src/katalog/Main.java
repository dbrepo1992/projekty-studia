package katalog;

public class Main {
    public static void main(String[] args) {
        // Tworzymy katalog
        Katalog katalog = new Katalog("Literatura i Nauka");

        // Tworzymy autorów
        Autor autor1 = new Autor("Adam", "Mickiewicz");
        Autor autor2 = new Autor("Maria", "Curie-Skłodowska");

        // Tworzymy książki
        Ksiazka ksiazka1 = new Ksiazka("Pan Tadeusz", 101, "PWN", 1834, 340, autor1);
        Ksiazka ksiazka2 = new Ksiazka("O promieniotwórczości", 102, "PWN", 1903, 220, autor2);

        // Tworzymy czasopisma
        Czasopismo czasopismo1 = new Czasopismo("Przyroda Polska", 201, "Wiedza i Życie", 2023, 5);
        Czasopismo czasopismo2 = new Czasopismo("Matematyka", 202, "Delta", 2024, 3);

        // Dodajemy pozycje do katalogu
        katalog.DodajPozycje(ksiazka1);
        katalog.DodajPozycje(ksiazka2);
        katalog.DodajPozycje(czasopismo1);
        katalog.DodajPozycje(czasopismo2);

        // Wypisujemy wszystkie pozycje
        System.out.println("=== Wszystkie pozycje w katalogu ===");
        katalog.WypiszWszystkiePozycje();

        // Szukamy pozycji po tytule
        System.out.println("\n=== Szukamy pozycji po tytule ===");
        Pozycja znalezionaTytul = katalog.ZnajdzPozycjePoTytule("Pan Tadeusz");
        if (znalezionaTytul != null) {
            znalezionaTytul.WypiszInfo();
        } else {
            System.out.println("Nie znaleziono pozycji o podanym tytule.");
        }

        // Szukamy pozycji po ID
        System.out.println("\n=== Szukamy pozycji po ID ===");
        Pozycja znalezionaId = katalog.ZnajdzPozycjePoId(202);
        if (znalezionaId != null) {
            znalezionaId.WypiszInfo();
        } else {
            System.out.println("Nie znaleziono pozycji o podanym ID.");
        }

        // Szukamy pozycji, która nie istnieje
        System.out.println("\n=== Szukamy nieistniejącej pozycji ===");
        Pozycja brak = katalog.ZnajdzPozycjePoTytule("Nieistniejący tytuł");
        if (brak == null) {
            System.out.println("Pozycja nie została znaleziona.");
        }
    }
}


