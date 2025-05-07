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
    public String getModel() {
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

    private double obliczSpalanie(double dlugoscTrasy) {
        return((srednieSpalanie * dlugoscTrasy) / 100.0);
    }


    public double obliczKosztPrzejazdu (double dlugoscTrasy, double cenaPaliwa) {
        double spalanie = obliczSpalanie(dlugoscTrasy);
        return spalanie * cenaPaliwa;
    }


    // public – metoda dostępna spoza klasy (np. z main()).
    // void – nie zwraca żadnej wartości.
    // Nie przyjmuje parametrów – działa na polach obiektu, którego dotyczy.
    // Każda linia System.out.println(...) wypisuje jedno pole wraz z opisem
    public void wypiszInfo() {
        System.out.println("Marka: " + marka);
        System.out.println("Model: " + model);
        System.out.println("Ilość drzwi: " + iloscDrzwi);
        System.out.println("Pojemność silnika: " + pojemnoscSilnika + " cm3");
        System.out.println("Średnie spalanie: " + srednieSpalanie + " l/100km");
        System.out.printf("Koszt przejazdu: %.2f zł%n: ", obliczKosztPrzejazdu(30.5, 4.85)); // Dobrą praktyką jest formatowanie liczb do dwóch miejsc po przecinku,
    }
    // System.out.println(...) – standardowe wypisywanie.Wypisuje dane na konsolę i automatycznie dodaje znak nowej linii na końcu (\n).
    // Nie formatuje danych – wszystko wypisuje tak, jak mu przekażesz.

    // System.out.printf(...) – wypisywanie sformatowane
    // Działa podobnie jak printf w C/C++.
    // Pozwala kontrolować ilość miejsc po przecinku, wyrównanie, format daty, itd.
    // Nie dodaje automatycznie nowej linii – jeśli chcesz nową linię, użyj %n (zalecane) lub \n.





    public static void wypiszIloscSamochodow() {
        System.out.println("Ilosc samochodów: " + iloscSamochodow);
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
        s1.wypiszInfo();
        s1.setMarka("Fiat" );
        s1.setModel( "126p" );
        s1.setIloscDrzwi( 2 );
        s1.setPojemnoscSilnika( 650 );
        s1.setSrednieSpalanie( 6.0 );
        s1.wypiszInfo();
        Samochod s2 = new Samochod("Syrena", "105", 2, 800, 7.6);
        s2.wypiszInfo();
        Samochod.wypiszIloscSamochodow();
    }

}
