package osoba;

public class Osoba {
protected String imie;
protected String nazwisko;
protected String dataUrodzenia;

public Osoba(String imie, String nazwisko, String dataUrodzenia) {
    this.imie = imie;
    this.nazwisko = nazwisko;
    this.dataUrodzenia = dataUrodzenia;
}

public String getImie(){
    return imie;
}

public void setImie(String imie){
    this.imie = imie;
}

public String getNazwisko() {
    return nazwisko;
}

public void setNazwisko(String nazwisko) {
    this.nazwisko = nazwisko;
}

public String getDataUrodzenia() {
    return dataUrodzenia;
}

public void setDataUrodzenia(String dataUrodzenia) {
    this.dataUrodzenia = dataUrodzenia;
}

public void wypiszInfo() {
    System.out.println("Imie: " + imie);
    System.out.println("Nazwisko: " + nazwisko);
    System.out.println("Data urodzenia: " + dataUrodzenia);
}

}
