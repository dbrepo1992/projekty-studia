package budynek;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        // Utworzenie budynku
        Budynek b = new Budynek("ul. Kwiatowa 10");
        System.out.println("Budynek: " + b.getAdres());

        // Utworzenie budynku mieszkalnego
        BudynekMieszkalny bm = new BudynekMieszkalny("ul. Polna 123", 4);
        System.out.println("Budynek mieszkalny: " + bm.getAdres() + ", " + bm.getLiczbaMieszkancow());

        // Polimorfizm: referencja typu Budynek, obiekt BudynekMieszkalny
        Budynek b2 = new BudynekMieszkalny("ul. Zielona 2", 8);
        b2.wypiszInfo();  // Wywoła się wersja z klasy BudynekMieszkalny (override)

        // Lista budynków
        List<Budynek> listaBudynkow = new ArrayList<>();
        listaBudynkow.add(b);
        listaBudynkow.add(0, bm);

        // Liczba elementów
        System.out.println("\nLiczba budynków w liście: " + listaBudynkow.size());

        // Iteracja i wypisywanie
        for (Budynek bud : listaBudynkow) {
            bud.wypiszInfo();
        }

        // Usuwanie i czyszczenie
        listaBudynkow.remove(0);
        listaBudynkow.clear();
        System.out.println("\nLista po czyszczeniu, liczba budynków: " + listaBudynkow.size());
    }
}
