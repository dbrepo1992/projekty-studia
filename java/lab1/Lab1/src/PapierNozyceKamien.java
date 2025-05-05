// Scanner znajduje się w pakiecie java.util, więc musimy go zaimportować, żeby kompilator wiedział, skąd go wziąć.
// Bez tego importu program zgłosi błąd kompilacji w miejscu, gdzie używasz new Scanner(System.in).
import java.util.Scanner;



public class PapierNozyceKamien {

    // Tablica wypełniona elementami do wyboru w grze
    // static są jak zmienne globalne w C++, możesz się do nich odwołać w każdej chwili bez tworzenia obiektu klasy.
    static String nazwy[] = { "papier", "nozyce", "kamien" };



    // Funkcja zwraca nazwę przedmiotu w zależności od wybranego kodu
    // Funkcja statyczna, która zwraca tekst (String) i przyjmuje jako argument liczbę całkowitą (int).
    // Dzięki tej funkcji zamiast wyświetlać liczby w grze (np. 0, 1, 2), możemy łatwo wypisywać ich opisy: papier, nożyce, kamień.
    static String podajNazwe(int id) {
    return nazwy[id]; // --> zwraca element z tablicy nazwy odpowiadający indeksowi id. Np. jeśli id == 1, to funkcja zwróci "nozyce".
    }


    // W celu uzyskania losowej wartości ze zbioru (0,1,2) liczbę tę należy pomnożyć przez 3 i zamienić na liczbę całkowitą.
    // Math.random() – zwraca liczbę zmiennoprzecinkową z zakresu [0.0, 1.0), czyli zawsze mniejszą od 1.
    // Math.random() * 3 – daje liczbę z zakresu [0.0, 3.0), np. 1.83, 0.25, 2.79...
    // (int)(...) – rzutowanie na typ int, czyli obcięcie części po przecinku (np. 1.83 → 1). Ostatecznie zwracana wartość to 0, 1 lub 2 – czyli dokładnie to, czego potrzebujemy.
    static int losujPrzedmiot() {
    return (int)(Math.random() * 3);
    }



    // Funkcja zwraca wskazany przez gracza przedmiot
    // Scanner sc = new Scanner(System.in); – umożliwia pobieranie danych wpisanych z klawiatury.
    // do...while – pętla, która zapętla pytanie, dopóki gracz nie wpisze poprawnej wartości.
    // sc.nextInt() – pobiera liczbę całkowitą wprowadzoną przez gracza.

    static int pytanieOPrzedmiot() {
        Scanner sc = new Scanner(System.in);
        int przedmiot;

        // Warunek przedmiot < 0 || przedmiot > 2 zabezpiecza przed wpisaniem np. 5, -1, czy liter.
        do {
        System.out.print("Jaki wybierasz przedmiot? ");
        System.out.println("0 - papier, 1 - nozyce, 2 - kamien:");
        przedmiot = sc.nextInt();
        } while (przedmiot < 0 || przedmiot > 2);

        return przedmiot;
    }





    static int liczWygrana(int przedmiotGracza, int przedmiotKomputera) {
        if (przedmiotGracza == przedmiotKomputera) {
            return 0; // remis
        } else if (
            (przedmiotGracza == 0 && przedmiotKomputera == 2) || // papier bije kamień
            (przedmiotGracza == 1 && przedmiotKomputera == 0) || // nożyce biją papier
            (przedmiotGracza == 2 && przedmiotKomputera == 1)    // kamień bije nożyce
        ) {
            return 1; // gracz wygrywa
        } else {
            return -1; // gracz przegrywa
        }
    }


    // Funkcja przyjmuje aktualny stan punktów (punkty) – np. 1, 0, -1, 2, -2.
    static void wypiszWynik(int punkty) {
        if (punkty == 0) {
            System.out.println("Remis");
        } else if (punkty > 0) {
            System.out.println("Gracz wygrywa o " + punkty + " zwycięstwa(ą)");
        } else {
            System.out.println("Gracz przegrywa o " + (-punkty) + " wygrane(ą)");
        }
    }

    public static void main(String[] args) {
        int punkty = 0;

        while (punkty < 2 && punkty > -2) { //while (punkty < 2 && punkty > -2) – gra toczy się dopóki nikt nie ma przewagi 2 punktów.
            int przedmiotGracza = pytanieOPrzedmiot();
            System.out.println("Gracz wybrał: " + podajNazwe(przedmiotGracza));

            int przedmiotKomputera = losujPrzedmiot();
            System.out.println("Komputer wybrał: " + podajNazwe(przedmiotKomputera));

            int wynik = liczWygrana(przedmiotGracza, przedmiotKomputera);
            punkty += wynik;

            // Informacja o wyniku rundy
            if (wynik == 1) {
                System.out.println("Gracz wygrał tę rundę!");
            } else if (wynik == -1) {
                System.out.println("Gracz przegrał tę rundę!");
            } else {
                System.out.println("Remis w tej rundzie.");
            }

            wypiszWynik(punkty);
            System.out.println(); // pusty wiersz dla przejrzystości
        }

        // Koniec gry – ogłoszenie zwycięzcy
        if (punkty == 2) {
            System.out.println("🎉 Gracz wygrał całą grę!");
        } else {
            System.out.println("💻 Komputer wygrał całą grę.");
        }
    }
    }





