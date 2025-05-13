package budynek;


public class BudynekMieszkalny extends Budynek {
    private int liczbaMieszkancow = 0;


    public int getLiczbaMieszkancow() {
        return liczbaMieszkancow;
    }

    public void setLiczbaMieszkancow(int liczbaMieszkancow) {
        this.liczbaMieszkancow = liczbaMieszkancow;
    }

    public BudynekMieszkalny(String adres, int liczbaMieszkancow) {
    super(adres);  // jawne wywołanie konstruktora z klasy Budynek
    this.liczbaMieszkancow = liczbaMieszkancow;
    }

     @Override // oznacza, że funkcja wypiszInfo() z klasy bazowej jest zastąpiona funkcją z klasy
               // potomnej. Dzieje się to tylko wówczas, gdy obie funkcje mają identyczne nazwy i parametry.
    public void wypiszInfo() {
        System.out.println(adres + " " + liczbaMieszkancow);
    }
}
