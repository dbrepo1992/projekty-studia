package katalog;

import java.util.ArrayList;
import java.util.List;

public class Biblioteka implements IZarzadzaniePozycjami {
    private List<Katalog> katalogi = new ArrayList<>();

    // implementacja z interfejsu – ale nie używana
    @Override
    public void DodajPozycje(Pozycja p) {
        // Możesz zostawić pustą lub zaimplementować np. dodanie do domyślnego katalogu
    }

    // Twoja własna metoda – do obsługi dodawania z nazwą działu
    public void DodajPozycje(String dzialTematyczny, Pozycja pozycja) {
        Katalog katalog = znajdzKatalogPoDziale(dzialTematyczny);
        if (katalog == null) {
            katalog = new Katalog(dzialTematyczny);
            katalogi.add(katalog);
        }
        katalog.DodajPozycje(pozycja);
    }

    private Katalog znajdzKatalogPoDziale(String dzialTematyczny) {
        for (Katalog k : katalogi) {
            if (k.getDzialTematyczny().equalsIgnoreCase(dzialTematyczny)) {
                return k;
            }
        }
        return null;
    }

    public String znajdzKatalogDlaPozycji(Pozycja szukana) {
    for (Katalog k : katalogi) {
        for (Pozycja pozycje : k.getPozycje()) {
            if (pozycje.equals(szukana)) {
                return k.getDzialTematyczny();
                }
            }
        }
    return "Nie znaleziono katalogu";
    }


    @Override
    public Pozycja ZnajdzPozycjePoTytule(String tytul) {
        for (Katalog k : katalogi) {
            Pozycja p = k.ZnajdzPozycjePoTytule(tytul);
            if (p != null) return p;
        }
        return null;
    }

    @Override
    public Pozycja ZnajdzPozycjePoId(int id) {
        for (Katalog k : katalogi) {
            Pozycja p = k.ZnajdzPozycjePoId(id);
            if (p != null) return p;
        }
        return null;
    }

    @Override
    public void WypiszWszystkiePozycje() {
        for (Katalog k : katalogi) {
            k.WypiszWszystkiePozycje();
        }
    }
}
