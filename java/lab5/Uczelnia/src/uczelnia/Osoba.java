package uczelnia;

public class Osoba {
    protected String imie = "";
    protected String nazwisko = "";
    protected String dataUrodzenia = "";

    public Osoba(String imie, String nazwisko, String dataUrodzenia) {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.dataUrodzenia = dataUrodzenia;
    }
}
