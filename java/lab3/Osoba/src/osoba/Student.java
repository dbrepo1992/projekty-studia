package osoba;

public class Student extends Osoba{
private int rok;
private int grupa;
private int nrIndeksu;

public Student(String imie, String nazwisko, String dataUrodzenia, int rok, int grupa, int nrIndeksu) {
    super(imie, nazwisko, dataUrodzenia);
    this.rok = rok;
    this.grupa = grupa;
    this.nrIndeksu = nrIndeksu;
}

public int getRok() {
    return rok;
}

public void setRok(int rok) {
    this.rok = rok;
}
public int getGrupa() {
    return grupa;
}

public void setGrupa(int grupa) {
    this.grupa = grupa;
}
public int getNrIndeksu() {
    return nrIndeksu;
}

public void setNrIndeksu(int nrIndeksu) {
    this.nrIndeksu = nrIndeksu;
}

@Override
public void wypiszInfo() {
    super.wypiszInfo();
    System.out.println("Rok: " + rok);
    System.out.println("Grupa: " + grupa);
    System.out.println("Nr Indeksu: " + nrIndeksu);
}


}
