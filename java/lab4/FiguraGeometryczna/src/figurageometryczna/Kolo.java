package figurageometryczna;

public class Kolo extends FiguraGeometryczna {
    private double promien;


    public Kolo(double promien) {
        nazwa = "Kolo";
        this.promien = promien;
    }

    @Override
    public double obliczPole(){
            return 3.14 *promien * promien;
    }
}

