package osoba;

public class PilkarzNozny extends Pilkarz {

    public PilkarzNozny(String imie, String nazwisko, String dataUrodzenia, String pozycja, String klub) {
        super(imie, nazwisko, dataUrodzenia, pozycja, klub);
    }

    @Override
    public void strzelGola() {
        super.strzelGola();
        System.out.println("Nozny strzelil gola!");
    }
}
