package iinstrument;

public class Traba implements IInstrument {
    @Override
    public void graj() {
        System.out.println("Tra ta ta");
    }

    @Override
    public String getNazwa() {
        return "Traba";
    }
}
