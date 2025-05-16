package katalog;

public class Czasopismo extends Pozycja{
    private int numer;

    public Czasopismo(){
        super(); // wywołanie konstruktora domyślnego klasy Pozycja
        this.numer = 0;
    }

    public Czasopismo(String tytul_, int id_, String wydawnictwo_, int rokWydania_, int numer_){
        super(tytul_, id_, wydawnictwo_, rokWydania_);
        this.numer = numer_;
    }


    public int getNumer() {
        return numer;
    }

    public void setNumer(int numer) {
        this.numer = numer;
    }
        @Override
    public void WypiszInfo(){
        System.out.println("Tytuł: " + tytul);
        System.out.println("ID: " + id);
        System.out.println("Wydawnictwo: " + wydawnictwo);
        System.out.println("Rok wydania: " + rokWydania);
        System.out.println("Numer: " + numer);
    }
}
