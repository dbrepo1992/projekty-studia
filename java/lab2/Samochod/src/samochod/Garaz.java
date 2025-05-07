package samochod;


    // Analogicznie do Samochod robimy wszystko dla Garaz

    public class Garaz {
        private String adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Garaz [] samochody;  // <-- typ tablicowy, przechowujący obiekty klasy Samochod.
    }


    public Garaz() {
        this.adres = "nieznany";
        this.pojemnosc = 0;
       // this.liczbaSamochodow; // <-- liczbaSamochodow zostało już zainicjowane i nie jest konieczne przypisanie mu wartości w ciele konstruktora.
        this.samochody = null;
    }

    public Garaz(String adres_, int pojemnosc_) {
        this.adres = adres_;
        this.pojemnosc = pojemnosc_;
        this.samochody = new Garaz[pojemnosc_]; // <-- alokujemy miejsce na samochody.
    }

    public void wprowadzSamochod(Garaz s) {   // public – metoda dostępna spoza klasy, void – nie zwraca nic.Samochod s – to samochód, który próbujemy wprowadzić do garażu
        if (liczbaSamochodow >= pojemnosc) { // Sprawdza, czy aktualna liczba samochodów osiągnęła maksymalną pojemność
            System.out.println("Garaz jest pelny. Nie mozna dodac kolejnego samochodu.");
        } else {
            samochody[liczbaSamochodow] = s; // Dodajemy samochód na pierwsze wolne miejsce w tablicy – indeks to liczbaSamochodow
            liczbaSamochodow++; // Zwiększamy licznik, bo właśnie dodaliśmy nowy samochód
            System.out.println("Samochod zostal wprowadzony do garazu.");
        }
    }

    public String getAdres() {
        return adres;
    }

    public void setAdres(String adres) {
        this.adres = adres;
    }

    public int getPojemnosc() {
        return pojemnosc;
    }


    public void setPojemnosc(int pojemnosc) {
        this.pojemnosc = pojemnosc;
        samochody = new Garaz[pojemnosc]; // alokacja tablicy
    }




    public static void main(String[] args) {


        // Miejsce w pamięci jest rezerwowane w momencie wywołania konstruktora przez słowo kluczowe new.
        // Tworzony jest obiekt klasy Samochod w pamięci (na sterta),
        // Java rezerwuje miejsce na jego pola (marka, model, iloscDrzwi, itd.),
        // Następnie wywołuje odpowiedni konstruktor, który te pola inicjalizuje (czyli wypełnia je wartościami).
        // Można to porównać do:
        // new = budujemy nowy samochód (baza)
        // konstruktor = konfigurujemy ten samochód (marka, model, silnik, itd.)

        Garaz s1 = new Garaz();
        s1.wypiszInfo();
        s1.setMarka("Fiat" );
        s1.setModel( "126p" );
        s1.setIloscDrzwi( 2 );
        s1.setPojemnoscSilnika( 650 );
        s1.setSrednieSpalanie( 6.0 );
        s1.wypiszInfo();
        Garaz s2 = new Garaz("Syrena", "105", 2, 800, 7.6);
        s2.wypiszInfo();
        Garaz.wypiszIloscSamochodow();

        Garaz g = new Garaz("ul. Garażowa 5", 2);
        Garaz s1 = new Garaz("Fiat", "126p", 2, 650, 6.5);
        Garaz s2 = new Garaz("Toyota", "Yaris", 4, 1200, 5.4);

        g.wprowadzSamochod(s1);
        g.wprowadzSamochod(s2);
        g.wprowadzSamochod(new Garaz()); // <-- Tu pojawi się komunikat, że garaż jest pełny

    }

}
