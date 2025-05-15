package iinstrument;

public class Beben implements IInstrument {
    @Override
    public void graj() {
        System.out.println( "Bum bum bum");
    }

    @Override
    public String getNazwa() {
        return "Beben";
        }
}
