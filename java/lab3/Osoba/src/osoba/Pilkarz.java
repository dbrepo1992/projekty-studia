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

public void setPozycja() {
    this.pozycja = pozycja;
}
public String getKlub() {
    return klub;
}

public void setKlub() {
    this.klub = klub;
}

@Override
public void wypiszInfo(){
    System.out.println("Pozycja: " + pozycja);
    System.out.println("Klub: " + klub);
}

public void strzelGola(){

}
}

