package figurageometryczna;

public class Prostokat extends FiguraGeometryczna{
    private double bok1 = 0.0;
    private double bok2 = 0.0;

    public Prostokat(double bok1, double bok2) {
        this.bok1 = bok1;
        this.bok2 = bok2;
        nazwa = "Prostokat";
    }

    @Override
    public double obliczPole(){
            return bok1 * bok2;
    }
}
