package uczelnia;

import java.util.ArrayList;
import java.util.List;

public class Wydzial {
    private String nazwa = "";
    private String adres = "";
    private List <Przedmiot> p ;
    private List <Student> s;
    private List<Wykladowca> w;


    public dodajJednostke(String nazwa, String adres) {
        this.nazwa = nazwa;
        this.adres = adres;
    }
}
