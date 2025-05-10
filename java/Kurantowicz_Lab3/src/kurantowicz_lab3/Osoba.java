/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class Osoba {
    private String imie;
    private String nazwisko;
    private String dataUr;
    
    public Osoba() {
        imie = "nieznany";
        nazwisko = "nieznany";
        dataUr = "nieznany";
        }
    public Osoba(String imie, String nazwisko, String dataUr) {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.dataUr = dataUr;

    }
    public String getDataUr() {
        return dataUr;
        }
    public void setDataUr(String dataUr) {
        this.dataUr = dataUr;
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
    
    public void wypisz() {
        System.out.println("Imie: " + imie + ", Nazwisko: " + nazwisko + " Data urodzenia : " + dataUr);
    }
   
}
