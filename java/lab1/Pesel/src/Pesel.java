import java.util.Scanner;

public class Pesel {

    // Wyjaśnienie:
    // Numer PESEL składa się z 11 cyfr.
    // Pierwsze 10 cyfr (pozycje 0–9) mają przypisane wagi: 1 3 7 9 1 3 7 9 1 3
    // Ostatnia cyfra (pozycja 10) to cyfra kontrolna, którą sprawdzimy na końcu.
    static int[] wagi = {1, 3, 7, 9, 1, 3, 7, 9, 1, 3};

    static int[] pytanieOPesel() {
        Scanner s = new Scanner(System.in);
        String peselText;
        int[] pesel = new int[11];

        while (true) {
            System.out.println("Podaj numer PESEL:");
            peselText = s.nextLine();

            // Sprawdzenie długości i czy wszystkie znaki są cyframi
            if (peselText.length() == 11 && peselText.matches("\\d{11}")) { //sprawdza, czy ciąg zawiera dokładnie 11 cyfr (\\d to cyfra, {11} – 11 razy).
                for (int i = 0; i < 11; i++) {
                    pesel[i] = peselText.charAt(i) - '0'; //Jeśli dane są poprawne, konwertujemy każdą cyfrę do liczby (char - '0').
                }
                break; // poprawny pesel, wychodzimy z pętli
            } else {
                System.out.println("Błędny numer PESEL. Upewnij się, że wpisujesz dokładnie 11 cyfr.");
            }
        }
        return pesel;
    }



    // Mnożymy 10 pierwszych cyfr przez odpowiednie wagi.
    // Liczymy: 10 - (suma % 10), a potem sprawdzamy, czy wynik zgadza się z 11. cyfrą.


    static boolean weryfikacja(int[] pesel) {
        int suma = 0;
        for (int i = 0; i < 10; i++) {
            suma += pesel[i] * wagi[i];
        }
        int kontrolna = (10 - (suma % 10)) % 10; // uwzględniamy przypadek kontrolna == 10
        return kontrolna == pesel[10];
    }


    // 10. cyfra (indeks 9) mówi o płci.
    // Parzysta → kobieta, nieparzysta → mężczyzna.
    static int plec(int[] pesel) {
        return (pesel[9] % 2 == 1) ? 1 : 2; // 1 – mężczyzna, 2 – kobieta
    }

    // Pierwsze 6 cyfr PESEL-a to: RRMMDD
    // Miesiąc zawiera zakodowaną informację o stuleciu – dlatego musimy ją odczytać i skorygować.
    // Zwracamy datę jako sformatowany ciąg "rrrr-mm-dd".

    static String data(int[] pesel) {
        int rok = pesel[0] * 10 + pesel[1];
        int miesiac = pesel[2] * 10 + pesel[3];
        int dzien = pesel[4] * 10 + pesel[5];

        int stulecie = 1900;

        if (miesiac >= 1 && miesiac <= 12) {
            stulecie = 1900;
        } else if (miesiac >= 21 && miesiac <= 32) {
            stulecie = 2000;
            miesiac -= 20;
        } else if (miesiac >= 41 && miesiac <= 52) {
            stulecie = 2100;
            miesiac -= 40;
        } else if (miesiac >= 61 && miesiac <= 72) {
            stulecie = 2200;
            miesiac -= 60;
        } else if (miesiac >= 81 && miesiac <= 92) {
            stulecie = 1800;
            miesiac -= 80;
        }

        rok += stulecie;

        return String.format("%04d-%02d-%02d", rok, miesiac, dzien);
    }



    static public void main(String [] args) {
        int [] pesel = pytanieOPesel();
        boolean poprawny = weryfikacja(pesel);
        if (poprawny) {
        System.out.println("Twoj PESEL jest poprawny");
        int plec = plec(pesel);
        if (plec==1) {
        System.out.println("Jestes mezczyzna");
        } else {
        System.out.println("Jestes kobietą");
        }
        System.out.println("Data urodzenia: " + data(pesel) );
        }
        }
    }
