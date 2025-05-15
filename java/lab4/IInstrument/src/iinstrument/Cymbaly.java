package iinstrument;

public class Cymbaly implements IInstrument{
    @Override
    public void graj(){
        System.out.println("Bim bam bum");
    }

    @Override
    public String getNazwa() {
        return "Cymbaly";
    }
}
