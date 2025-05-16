package katalog;

public class Autor {
    private String imie;
    private String nazwisko;

    public Autor(){

    }

    public Autor(String imie_, String nazwisko_){
        this.imie = imie_;
        this.nazwisko = nazwisko_;
    }

    public String getImie() {
        return imie;
    }

    public void setImie(String imie) {
        this.imie = imie;
    }

    public String getNazwisko() {
        return nazwisko;
    }

    public void setNazwisko(String nazwisko) {
        this.nazwisko = nazwisko;
    }

    public void wypiszInfo() {
    System.out.println("Imię: " + imie);
    System.out.println("Nazwisko: " + nazwisko);
    }

}
