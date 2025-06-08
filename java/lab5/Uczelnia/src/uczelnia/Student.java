package uczelnia;

import java.util.ArrayList;
import java.util.List;

public class Student extends Osoba {
    private String kierunek = "";
    private String specjalnosc = "";
    private int rok = 0;
    private int grupa = 0;
    private int nrIndeksu = 0;
    private List<OcenaKoncowa> oceny;

    public Student(){};

    public Student(String imie, String nazwisko, String dataUrodzenia, String kierunek, String specjalnosc, int rok, int grupa, int nrIndeksu) {
        super(imie, nazwisko, dataUrodzenia);
        this.kierunek = kierunek;
        this.specjalnosc = specjalnosc;
        this.rok = rok;
        this.grupa = grupa;
        this.nrIndeksu = nrIndeksu;
    }

    @Override
    public void wypiszInfo() {
        System.out.println("Student: " + imie + " " + nazwisko);
        for (OcenaKoncowa ocena: oceny) {
            ocena.wypiszInfo();
        }
    }

    public void infoOceny(){
        this.oceny = new ArrayList<>();
    }

    public void dodajOcene(OcenaKoncowa ocena) {
        oceny.add(ocena);
    }

    public List<OcenaKoncowa> getOceny() {
        return oceny;
    }


}
