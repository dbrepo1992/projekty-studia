/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;
import java.util.ArrayList;
import java.util.List;
/**
 *
 * @author barte
 */
public class Student extends Osoba {
    private int rok;
    private int grupa;
    private int nrIndeksu;
    private List<Ocena> oceny = new ArrayList<>();
    public Student(String imie, String nazwisko, String dataUr, int rok, int grupa, int nrIndeksu) {
    super(imie, nazwisko, dataUr);
    this.rok = rok;
    this.grupa = grupa;
    this.nrIndeksu = nrIndeksu;
    }
    @Override
    public void wypisz() {
    System.out.println("Student - Imie: " + getImie() + ", nazwisko: " + getNazwisko() + ", data urodzenia: " + getDataUr() + ", rok: " + rok + ", grupa " + grupa + ", nrIndeksu " + nrIndeksu);
    this.wypiszOceny();
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
    public void wypiszOceny() {
    for (Ocena ocena : oceny) {
    ocena.wypisz();
    }
    }
    public void dodajOcene(String data, String przedmiot, double wartosc) {
    Ocena nowaOcena = new Ocena(przedmiot, data, wartosc);
    oceny.add(nowaOcena);
    }

    public void usunOcene(String nazwaPrzedmiotu, String data, double wartosc){
        for (int i=0; i<oceny.size(); ) {
            Ocena o = oceny.get(i);
            if ( o.getPrzedmiot()== nazwaPrzedmiotu &&
            o.getData() == data &&
            o.getWartosc() == wartosc ) {
            oceny.remove(i);
        }
        else {
            i++;
        }
    }
    }
    public void usun(String nazwaPrzedmiotu){
        for (int i=0; i<oceny.size(); ) {
            Ocena o = oceny.get(i);
            if ( o.getPrzedmiot()== nazwaPrzedmiotu ) {
            oceny.remove(i);
        }
        else {
            i++;
        }
    }
    }
    public void usunOceny(){
        for (int i=0; i<oceny.size(); ) {
            oceny.remove(i);
        }
    }
}


