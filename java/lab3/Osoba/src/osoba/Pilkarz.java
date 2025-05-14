package osoba;

public class Pilkarz extends Osoba {
private String pozycja;
private String klub;
private int liczbaGoli = 0;

public Pilkarz(String imie, String nazwisko, String dataUrodzenia, String pozycja, String klub) {
    super(imie, nazwisko, dataUrodzenia);
    this.pozycja = pozycja;
    this.klub = klub;
}

public String getPozycja() {
    return pozycja;
}

public void setPozycja(String pozycja) {
    this.pozycja = pozycja;
}
public String getKlub() {
    return klub;
}

public void setKlub(String klub) {
    this.klub = klub;
}

public int getLiczbaGoli() {
    return liczbaGoli;
}

public void setLiczbaGoli(int liczbaGoli) {
    this.liczbaGoli = liczbaGoli;
}

@Override
public void wypiszInfo(){
    super.wypiszInfo();
    System.out.println("Pozycja: " + pozycja);
    System.out.println("Klub: " + klub);
    System.out.println("liczba goli: " + liczbaGoli);
}

public void strzelGola(){
    liczbaGoli++;
}
}

