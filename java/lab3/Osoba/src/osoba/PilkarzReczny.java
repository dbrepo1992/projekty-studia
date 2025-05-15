package osoba;

public class PilkarzReczny extends Pilkarz {

    public PilkarzReczny(String imie, String nazwisko, String dataUrodzenia, String pozycja, String klub){
        super(imie, nazwisko, dataUrodzenia, pozycja, klub);
    }

    @Override
    public void strzelGola() {
        super.strzelGola(); // wywołuje metodę z klasy bazowej.Używane poza konstruktorem, czyli np. w strzelGola()
        System.out.println("Reczny strzelil gola!");
    }
}
