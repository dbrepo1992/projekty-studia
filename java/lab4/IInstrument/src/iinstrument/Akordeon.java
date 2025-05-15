package iinstrument;

public class Akordeon implements IInstrument {

    @Override
    public void graj(){
        System.out.println("Raa raa ri raa");
    }

    @Override
    public String getNazwa(){
        return "Akordeon";
    }

}
