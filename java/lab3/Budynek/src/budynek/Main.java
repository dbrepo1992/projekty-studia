package budynek;

public class Main {
    public static void main(String[] args) {
    Budynek b = new Budynek("ul. Kwaitowa 10");
    System.out.println("Budynek: " + b.getAdres());
    BudynekMieszkalny bm = new BudynekMieszkalny("Polna 123", 4);
    System.out.println("Budynek: " + bm.getAdres() + ", " + bm.getLiczbaMieszkancow());
    }

}
