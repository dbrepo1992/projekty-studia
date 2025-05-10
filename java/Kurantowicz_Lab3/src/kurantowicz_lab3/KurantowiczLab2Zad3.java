/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class KurantowiczLab2Zad3 {

    /**
     * @param args the command line arguments
     */
    public static void main(String [] args) {
    Osoba o = new Osoba("Adam", "Adamowski", "1990-02-02");
    Osoba o2= new Student("Marek", "Markowski", "1980-01-01", 2, 3, 12345);
    Osoba o3= new Pilkarz("Jan", "Jankowski", "2000-12-12", "napastnik", "FC Barcelona");
    o.wypisz();
    o2.wypisz();
    o3.wypisz();
    Student s = new Student("Kamil", "Kaminski", "1999-08-03", 2, 5, 12121);
    Pilkarz p = new Pilkarz("Damian", "Daminski", "2001-04-04", "obronca", "AC Milan");
    s.wypisz();
    p.wypisz();
    ((Pilkarz)o3).strzelGola();
    p.strzelGola();
    p.strzelGola();
    o3.wypisz();
    p.wypisz();
    
    PilkarzNozny pn1 = new PilkarzNozny("Jan", "Kowalski", "1990-01-01", "Napastnik", "FC Barcelona");
    PilkarzReczny pr1 = new PilkarzReczny("Adam", "Nowak", "1992-05-15", "Rozgrywający", "PSG");

    pr1.wypisz();
    pn1.wypisz();

    pn1.strzelGola(); // Nożny strzelił!
    pr1.strzelGola(); // Ręczny strzelił!

    pr1.wypisz();
    pn1.wypisz();
   }
    
}
