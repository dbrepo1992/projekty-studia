package samochod;

public class Samochod {

    // (Pola obiektu klasy to te zmienne, które są zadeklarowane na początku klasy i należą do każdego utworzonego obiektu.)
    //              ||
    //              ||
    //             \  /
    //              \/

    private String marka; // < -- (To jest pole obiektu. Każdy samochód (Samochod) ma swoją własną marka.)
    private String model;
    private int iloscDrzwi;
    private int pojemnoscSilnika;
    private double srednieSpalanie;
    private static int iloscSamochodow = 0;


    // Default constructor
    public Samochod() {
        this.marka = "nieznana"; // (przypisanie domyślnej wartości do pola instancji.)
        this.model = "nieznany";
        this.iloscDrzwi = 0;
        this.pojemnoscSilnika = 0;
        this.srednieSpalanie = 0.0;
        iloscSamochodow++; // we increase number of cars (dostęp do statycznego pola klasy, zwiększającego licznik obiektów.)
    }

    // Constructor with all data as params (Parametry konstruktora to zmienne lokalne, które są przekazywane do konstruktora)
    // String marka_  // to jest parametr. On istnieje tylko w momencie tworzenia obiektu i znika, gdy konstruktor się zakończy.
    public Samochod(String marka_, String model_, int iloscDrzwi_, int pojemnoscSilnika_, double srednieSpalanie_) {
        this.marka = marka_;    // (Słowo kluczowe [this] odnosi się do pola obiektu – odróżnia je od nazwy parametru.)
        this.model = model_;    // (this.model → odnosi się do pola obiektu (czyli model samochodu, który właśnie tworzysz).model_ → to nazwa parametru, który użytkownik podał jako argument w new Samochod(...))
        this.iloscDrzwi = iloscDrzwi_;
        this.pojemnoscSilnika = pojemnoscSilnika_;  // Podkreślnik (_) jest częścią nazwy parametru. To tylko konwencja, która pomaga odróżnić parametr od pola.
        this.srednieSpalanie = srednieSpalanie_;    // oznacza: „ustaw pole marka (należące do obiektu) na wartość parametru marka_.

        iloscSamochodow++;
    }



    // Created get and set functions for each private
    //              ||
    //              ||
    //             \  /
    //              \/


    // getter marka
    public String getMarka() {
        return marka;
    }

    // setter marka
    public void setMarka(String marka) {
        this.marka = marka;
    }




    // setter model
    public String setModel() {
        return model;
    }

    // getter model
    public void setModel(String model) {
        this.model = model;
    }




    // getter iloscDrzwi
    public int getIloscDrzwi() {
        return iloscDrzwi;
    }
    // setter iloscDrzwi
    public void setIloscDrzwi(int iloscDrzwi) {
        this.iloscDrzwi = iloscDrzwi;
    }




    // getter pojemnoscSilnika
    public int getPojemnoscSilnika() {
        return pojemnoscSilnika;
    }
    // setter pojemnoscSilnika
    public void setPojemnoscSilnika(int pojemnoscSilnika) {
        this.pojemnoscSilnika = pojemnoscSilnika;
    }



    // getter srednieSpalanie
    public double getSrednieSpalanie() {
        return srednieSpalanie;
    }
    // setter srednieSpalanie
    public void setSrednieSpalanie(double srednieSpalanie) {
        this.srednieSpalanie = srednieSpalanie;
    }


    public static void main(String[] args) {


        // Miejsce w pamięci jest rezerwowane w momencie wywołania konstruktora przez słowo kluczowe new.
        // Tworzony jest obiekt klasy Samochod w pamięci (na sterta),
        // Java rezerwuje miejsce na jego pola (marka, model, iloscDrzwi, itd.),
        // Następnie wywołuje odpowiedni konstruktor, który te pola inicjalizuje (czyli wypełnia je wartościami).
        // Można to porównać do:
        // new = budujemy nowy samochód (baza)
        // konstruktor = konfigurujemy ten samochód (marka, model, silnik, itd.)

        Samochod s1 = new Samochod();
        Samochod s2 = new Samochod("Toyota", "Corolla", 4, 1600, 6.5);
    }

}
