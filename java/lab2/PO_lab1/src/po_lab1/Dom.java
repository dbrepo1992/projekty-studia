package po_lab1;


public class Dom {

    final int iloscOkien = 10;       // stała przypisana raz na zawsze. Nie można zmienić jej wartości.
    private double metraz = 200;     // pole przechowujące powierzchnię domu (domyślnie 200 m²).
    private String adres;            // pole przechowujące adres domu (brak wartości na start = null).


    // Konstruktor bezparametrowy (domyślny)
    // Konstruktor nazywa się tak samo jak klasa.Ustawia domyślny adres, jeśli użytkownik nie poda innego.
    public Dom() {
        adres = "nieznany";
    }



    // Konstruktor z parametrem
    // Pozwala przy tworzeniu obiektu przekazać adres.
    // this.adres – oznacza, że przypisujemy wartość do pola obiektu, a nie do parametru metody.
    public Dom(String adres) {
        this.adres = adres;
    }


    // Gettery i settery, funkcje dostępu i zmiany, czyli funkcje umożliwiające dostęp do wartości zmiennej
    // prywatnej oraz możliwość jej zmiany. Zmienna prywatna (private) nie jest dostępna poza klasą.
    // Więc aby ją zmodyfikować należy wykorzystać tzw. funkcje get i set.
    public double getMetraz() { // zwraca bieżący metraż domu.(używamy double ponieważ potrzebujemy liczb zmiennoprzecinkowych)
        return metraz;
    }

    public void setMetraz(double metraz) { // pozwala go zmienić.
        this.metraz = metraz;
    }


    // Analogicznie dla funkcji getAdres i setAdres (tylko tutaj używamy stringa ponieważ potrzebujemy ciągu znaków)
    public String getAdres() {
        return adres;
    }

    public void setAdres(String adres) {
        this.adres = adres;
    }

    // metodę obliczPodatek(), która przyjmuje jako parametr wartość podatku za metr kwadratowy zgodnie ze wzorem podatek = podatekZaMetr * metraz
    public double obliczPodatek(double podatekZaMetr) {
        return podatekZaMetr * metraz;
    }
}
