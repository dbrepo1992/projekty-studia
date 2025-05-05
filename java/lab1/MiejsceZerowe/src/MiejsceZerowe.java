import java.util.Scanner;

public class MiejsceZerowe {

    // Obsługuje przypadki: równanie liniowe (a == 0), jedno miejsce (delta == 0), dwa miejsca (delta > 0), brak miejsc (delta < 0).
    // Zwracana tablica ma długość 0, 1 lub 2.
    static double[] obliczMiejscaZerowe(double a, double b, double c) {
        if (a == 0) {
            if (b != 0) {
                return new double[]{ -c / b }; // równanie liniowe
            } else {
                return new double[0]; // brak rozwiązania (np. 0x = 5 lub 0x = 0)
            }
        }

        double delta = b * b - 4 * a * c;

        if (delta > 0) {
            double x1 = (-b - Math.sqrt(delta)) / (2 * a);
            double x2 = (-b + Math.sqrt(delta)) / (2 * a);
            return new double[]{ x1, x2 };
        } else if (delta == 0) {
            double x0 = -b / (2 * a);
            return new double[]{ x0 };
        } else {
            return new double[0]; // brak miejsc zerowych
        }
    }

    public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);
    boolean kontynuuj = true;

    while (kontynuuj) {
        System.out.println("Podaj współczynniki równania kwadratowego ax^2 + bx + c = 0"); // Pyta o współczynniki a, b, c

        System.out.print("a = ");
        double a = scanner.nextDouble();

        System.out.print("b = ");
        double b = scanner.nextDouble();

        System.out.print("c = ");
        double c = scanner.nextDouble();

        double[] miejscaZerowe = obliczMiejscaZerowe(a, b, c); // Wywołuje funkcję obliczMiejscaZerowe

        if (miejscaZerowe.length == 2) { // Wypisuje wynik
            System.out.println("Znaleziono dwa miejsca zerowe:");
            System.out.println("x1 = " + miejscaZerowe[0]);
            System.out.println("x2 = " + miejscaZerowe[1]);
        } else if (miejscaZerowe.length == 1) {
            System.out.println("Znaleziono jedno miejsce zerowe:");
            System.out.println("x = " + miejscaZerowe[0]);
        } else {
            System.out.println("Brak miejsc zerowych.");
        }

        System.out.print("Czy chcesz wykonać kolejne obliczenia? (t/n): "); // Pyta, czy użytkownik chce kontynuować (t/n)
        String odp = scanner.next();
        if (!odp.equalsIgnoreCase("t")) {
            kontynuuj = false;
        }
    }

    System.out.println("Dziękujemy za skorzystanie z programu!");
}
}
