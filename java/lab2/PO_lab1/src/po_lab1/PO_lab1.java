package po_lab1;


public class PO_lab1 {




    public static void main(String[] args) {
        Dom d = new Dom();
        Dom d2 = new Dom("ul. Testowa 1");
        d.setAdres("ul. Adresowa 10");
        d.setMetraz(150);
        double podatek = d.obliczPodatek(40.50);
        double podatek2 = d2.obliczPodatek(40.50);
        System.out.println("Adres:" + d.getAdres() + " metraz:" + d.getMetraz() + " podatek:" + podatek);
        System.out.println("Adres:" + d2.getAdres() + " metraz:" + d2.getMetraz() + " podatek:" + podatek2);
    }

}
