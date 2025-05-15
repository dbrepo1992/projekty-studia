package figurageometryczna;

public class Main {
    public static void main(String[] args) {
        FiguraGeometryczna f1 = new Kolo(10);
        System.out.println( f1.getNazwa() + ", pole: " + f1.obliczPole() );
        FiguraGeometryczna f2 = new Prostokat(2, 3);
        System.out.println( f2.getNazwa() + ", pole: " + f2.obliczPole() );
        FiguraGeometryczna f3 = new Trojkat(5, 6);
        System.out.println( f3.getNazwa() + ", pole: " + f3.obliczPole() );
        
    }

}
