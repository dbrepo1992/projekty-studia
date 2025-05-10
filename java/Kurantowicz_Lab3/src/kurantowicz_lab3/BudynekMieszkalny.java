/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class BudynekMieszkalny extends Budynek {
   
    
    public BudynekMieszkalny(String adres, int liczbaMieszkancow) {
    super(adres);
    this.liczbaMieszkancow = liczbaMieszkancow;
    }
    private int liczbaMieszkancow = 0;
    public int getLiczbaMieszkancow() {
    return liczbaMieszkancow;
    }
    public void setLiczbaMieszkancow(int liczbaMieszkancow) {
    this.liczbaMieszkancow = liczbaMieszkancow;
    } 
    @Override
    public void wypiszInfo() {
    System.out.println(adres + liczbaMieszkancow);
    }
}