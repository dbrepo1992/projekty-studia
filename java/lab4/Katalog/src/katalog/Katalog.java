package katalog;

import java.util.ArrayList;
import java.util.List;


public class Katalog {
    private String dzialTematyczny;
    private List<Pozycja> pozycje = new ArrayList<>();

    public Katalog() {
        this.dzialTematyczny = "nieznany";
    }

    public Katalog(String dzialTematyczny_) {
        this.dzialTematyczny = dzialTematyczny_;
    }

    public String getDzialTematyczny() {
        return dzialTematyczny;
    }

    public void setDzialTematyczny(String dzialTematyczny) {
        this.dzialTematyczny = dzialTematyczny;
    }


    public void DodajPozycje(Pozycja p) {
        if (p != null) pozycje.add(p);
    }


    public Pozycja ZnajdzPozycjePoTytule(String tytul) {
        for (Pozycja p : pozycje) {
            if (p.getTytul().equalsIgnoreCase(tytul)) {
                return p;
            }
        }
        return null;
    }


    public Pozycja ZnajdzPozycjePoId(int id) {
        for (Pozycja p : pozycje) {
            if (p.getId() == id) {
                return p;
            }
        }
        return null;
    }


    public void WypiszWszystkiePozycje() {
        for (Pozycja p : pozycje) {
            p.WypiszInfo();
        }
    }

}
