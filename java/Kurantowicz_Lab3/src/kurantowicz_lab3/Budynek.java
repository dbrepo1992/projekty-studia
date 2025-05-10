/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class Budynek {
protected String adres;
public Budynek(String adres) {
this.adres = adres;
}
public String getAdres() {
return adres;
}
public void setAdres(String adres) {
this.adres = adres;
}
public void wypiszInfo() {
System.out.println(adres);
}
}

