package osoba;

public class PilkarzReczny extends Pilkarz {

    public PilkarzReczny(String imie, String nazwisko, String dataUrodzenia, String pozycja, String klub){
        super(imie, nazwisko, dataUrodzenia, pozycja, klub);
    }

    @Override
    public void strzelGola() {
        super.strzelGola();
        System.out.println("Reczny strzelil gola!");
    }
}
