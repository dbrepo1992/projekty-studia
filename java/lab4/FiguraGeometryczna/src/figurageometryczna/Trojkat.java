package figurageometryczna;

public class Trojkat extends FiguraGeometryczna {
    private double podstawa = 0.0;
    private double wysokosc = 0.0;

    public Trojkat(double podstawa, double wysokosc) {
        this.podstawa = podstawa;
        this.wysokosc = wysokosc;
        nazwa = "trojkat";
    }
        @Override
        public double obliczPole(){
            return (podstawa * wysokosc) / 2;
        }
}


