/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class Pilkarz extends Osoba {
    private String pozycja;
    private String klub;
    private int liczbaGoli;
    public Pilkarz(String imie, String nazwisko, String dataUr, String pozycja, String klub) {
    super(imie, nazwisko, dataUr);
    this.pozycja = pozycja;
    this.klub = klub;
    this.liczbaGoli = 0;
    }
    @Override
    public void wypisz() {
    System.out.println("Piłkarz - Imie: " + getImie() + " nazisko: " + getNazwisko() + " data urodzenia: " + getDataUr() + " pozycja: " + pozycja + " klub " + klub + " liczba goli " + liczbaGoli);
    }
    public void strzelGola() {
        liczbaGoli++;
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
    
}
