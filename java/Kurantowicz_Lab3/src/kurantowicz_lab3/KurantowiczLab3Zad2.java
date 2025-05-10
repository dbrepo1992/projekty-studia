/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class KurantowiczLab3Zad2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
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
        ((Student)o2).dodajOcene("Progamowanie obiektowe", "2020-04-24", 5);
        ((Student)o2).dodajOcene("Bazy danych", "2020-04-14", 5);

        o2.wypisz();

        s.dodajOcene("Bazy danych", "2020-03-20", 5);
        s.dodajOcene("Matematyka", "2020-03-15", 3);
        s.dodajOcene("Matematyka", "2020-03-20", 2);
        s.wypisz();

        s.usunOcene("Matematyka", "2020-03-15", 3);
        s.wypisz();
        s.dodajOcene("Matematyka", "2020-03-15", 4);
        s.usun("Matematyka");

        s.wypisz();

        s.dodajOcene("Matematyka", "2020-03-15", 4);
        s.usunOceny();

        s.wypisz();
    }
    
}
