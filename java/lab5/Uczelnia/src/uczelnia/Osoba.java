package uczelnia;
// Klasa abstrakcyjna – nie da się utworzyć jej bezpośrednio (czyli: new Osoba(...) nie zadziała).
// Służy jako szablon dla klas pochodnych (Student, Wykladowca).
public abstract class Osoba implements IInfo {
    protected String imie = "";
    protected String nazwisko = "";
    protected String dataUrodzenia = "";

    public Osoba(String imie, String nazwisko, String dataUrodzenia) {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.dataUrodzenia = dataUrodzenia;
    }

    public abstract void wypiszInfo();
}
