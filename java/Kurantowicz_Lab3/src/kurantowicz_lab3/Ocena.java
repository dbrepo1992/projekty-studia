/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;
/**
 *
 * @author barte
 */
public class Ocena {
    private double wartosc;
    private String przedmiot;
    private String data;
    
    public Ocena(){}
    public Ocena(String przedmiot, String data, double wartosc) {
        this.wartosc=wartosc;
        this.przedmiot=przedmiot;
        this.data=data;
    }
    public double getWartosc() {
        return wartosc;
        }
    public void setWartosc(double wartosc) {
        this.wartosc = wartosc;
        }
    public String getPrzedmiot() {
        return przedmiot;
        }
    public void setPrzedmiot(String przedmiot) {
        this.przedmiot = przedmiot;
        }
    public String getData() {
        return data;
        }
    public void setData(String data) {
        this.data = data;
        }
    
    public void wypisz() {
    System.out.println("Ocena : " + wartosc + " z przedmiotu: " + przedmiot + " data wystawienia oceny : " + data);
    }
}