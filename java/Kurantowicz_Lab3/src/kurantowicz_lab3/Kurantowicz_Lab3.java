/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package kurantowicz_lab3;
import java.util.ArrayList;
import java.util.List;
/**
 *
 * @author barte
 */

public class Kurantowicz_Lab3 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Budynek b = new Budynek("ul. Kwiatowa 10");
        System.out.println("Budynek: " + b.getAdres());
        
        BudynekMieszkalny bm = new BudynekMieszkalny("ul. Polna 123", 4);
        System.out.println("Budynek mieszkalny: " + bm.getAdres() + ", " +
        bm.getLiczbaMieszkancow());
        Budynek b2 = new BudynekMieszkalny("ul. Zielona 2", 8);
        b2.wypiszInfo();

        
        List<Budynek> listaBudynkow = new ArrayList<Budynek>();
        listaBudynkow.add(b); //dodanie budynku b do listy
        listaBudynkow.add(0, bm); //dodanie budynku bm na pozycję 0
        int liczbaBudynkow = listaBudynkow.size(); //liczba elementow listy
        Budynek b3 = listaBudynkow.get(1); //dostęp do elementu o indeksie 1
        //pętla wykonujaca funkcje wypiszInfo() na wszystkich budynkach
        //w liscie
        for (Budynek budynek : listaBudynkow) {
        budynek.wypiszInfo();
        }
        listaBudynkow.remove(0); //usuniecie bunynku nr 0
        listaBudynkow.clear(); //wyczyszczenie listy
        
    }
    
}
