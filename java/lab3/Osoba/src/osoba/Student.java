package osoba;

import java.util.ArrayList;
import java.util.List;

public class Student extends Osoba{
    private int rok;
    private int grupa;
    private int nrIndeksu;
    private List<Ocena> oceny = new ArrayList<>();

    public Student(){
        super();
        this.rok = 1900;
        this.grupa = 0;
        this.nrIndeksu = 0;
    }

    public Student(String imie, String nazwisko, String dataUrodzenia, int rok, int grupa, int nrIndeksu) {
        super(imie, nazwisko, dataUrodzenia);
        this.rok = rok;
        this.grupa = grupa;
        this.nrIndeksu = nrIndeksu;
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


    @Override
    public void wypiszInfo() {
        super.wypiszInfo();
        System.out.println("Rok: " + rok);
        System.out.println("Grupa: " + grupa);
        System.out.println("Nr Indeksu: " + nrIndeksu);

        if (oceny.isEmpty()) {
        System.out.println("Brak ocen.");
        } else {
        System.out.println("Oceny:");
        for (Ocena ocena : oceny) {
            System.out.println("- " + ocena.getNazwaPrzedmiotu() + ": " + ocena.getWartosc());
            }
        }
    }

    //  metoda dodająca ocenę
    public void dodajOcene(String nazwaPrzedmiotu, String data, double wartosc) {
        Ocena nowaOcena = new Ocena(nazwaPrzedmiotu, data, wartosc);
        oceny.add(nowaOcena);
    }

    public void wypiszOceny() {
        for (Ocena ocena : oceny) {
        ocena.wypiszInfo();
        }
    }


    public void wypiszOceny(String nazwaPrzedmiotu) {
        boolean znaleziono = false;
        for (Ocena ocena : oceny) {
            if(ocena.getNazwaPrzedmiotu().equalsIgnoreCase(nazwaPrzedmiotu)) {
                System.out.println("Ocena z " + nazwaPrzedmiotu + ": " + ocena.getWartosc());
                znaleziono = true;
            }
        }

        if (!znaleziono) {
            System.out.println("Brak ocen z przedmiotu: " + nazwaPrzedmiotu);
        }
    }


    public void usunOcene(String nazwaPrzedmiotu, String data, double wartosc) {
    for (int i=0; i<oceny.size(); ) {
        Ocena o = oceny.get(i);
        if ( o.getNazwaPrzedmiotu() == nazwaPrzedmiotu &&
            o.getData() == data &&
            o.getWartosc() == wartosc ) {
                oceny.remove(i);
            } else {
                i++;
            }
        }
    }

    public void usunOceny(){
        oceny.clear();
        System.out.println("Wszystkie oceny zostały usunięte.");
    }

    public void usunOceny(String nazwaPrzedmiotu) {
        oceny.removeIf(ocena -> ocena.getNazwaPrzedmiotu().equalsIgnoreCase(nazwaPrzedmiotu));
        System.out.println("Usunięto wszystkie oceny z przedmiotu: " + nazwaPrzedmiotu);
    }

}
