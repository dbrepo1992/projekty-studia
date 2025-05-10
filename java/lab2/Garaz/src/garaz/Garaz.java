package garaz;

// Analogicznie do Samochod robimy wszystko dla Garaz

    public class Garaz {
        private String adres;
        private int pojemnosc;
        private int liczbaSamochodow = 0;
        private Samochod [] samochody;  // <-- typ tablicowy, przechowujący obiekty klasy Samochod.



    public Garaz() {
        this.adres = "nieznany";
        this.pojemnosc = 0;
       // this.liczbaSamochodow; // <-- liczbaSamochodow zostało już zainicjowane i nie jest konieczne przypisanie mu wartości w ciele konstruktora.
        this.samochody = null;
    }

    public Garaz(String adres_, int pojemnosc_) {
        this.adres = adres_;
        this.pojemnosc = pojemnosc_;
        this.samochody = new Samochod[pojemnosc_]; // <-- alokujemy miejsce na samochody.
    }

    public void wprowadzSamochod(Samochod s) {   // public – metoda dostępna spoza klasy, void – nie zwraca nic.Samochod s – to samochód, który próbujemy wprowadzić do garażu
        if (liczbaSamochodow >= pojemnosc) { // Sprawdza, czy aktualna liczba samochodów osiągnęła maksymalną pojemność
            System.out.println("Garaz jest pelny. Nie mozna dodac kolejnego samochodu.");
        } else {
            samochody[liczbaSamochodow] = s; // Dodajemy samochód na pierwsze wolne miejsce w tablicy – indeks to liczbaSamochodow
            liczbaSamochodow++; // Zwiększamy licznik, bo właśnie dodaliśmy nowy samochód
            System.out.println("Samochod zostal wprowadzony do garazu.");
        }
    }

    public Samochod wyprowadzSamochod() {
    if (liczbaSamochodow == 0) {
        System.out.println("Garaż jest pusty. Nie można wyprowadzić samochodu.");
        return null;
    } else {
        // Ostatnio dodany samochód znajduje się pod indeksem liczbaSamochodow - 1
        Samochod wyprowadzany = samochody[liczbaSamochodow - 1];
        samochody[liczbaSamochodow - 1] = null; // usuwamy referencję
        liczbaSamochodow--; // zmniejszamy licznik
        System.out.println("Samochód został wyprowadzony z garażu.");
        return wyprowadzany;
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
        samochody = new Samochod[pojemnosc]; // alokacja tablicy
    }

    public void wypiszInfo() {
        System.out.println("Adres: " + adres);
        System.out.println("Pojemnosc: " + pojemnosc);
        System.out.println("Liczba samochodow w garazu: " + liczbaSamochodow);

        if (liczbaSamochodow ==0) {
            System.out.println("Brak samochodow w garazu.");
        } else {
            System.out.println("Samochody w garazu.");
            for (int i = 0; i < liczbaSamochodow; i++) {
                System.out.println("Samochod nr " + (i + 1) + ":");
                samochody[i].wypiszInfo();
                System.out.println();
            }
        }
    }
}
