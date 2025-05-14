package osoba;

public class Ocena extends Student {
    private String nazwaPrzedmiotu;
    private String data;
    private double wartosc;


    public Ocena(String nazwaPrzedmiotu, String data, double wartosc){
        this.nazwaPrzedmiotu = nazwaPrzedmiotu;
        this.data = data;
        this.wartosc = wartosc;
    }

    public String getNazwaPrzedmiotu() {
        return nazwaPrzedmiotu;
    }

    public void setNazwaPrzedmiotu(String nazwaPrzedmiotu) {
        this.nazwaPrzedmiotu = nazwaPrzedmiotu;
    }

    public String getData() {
        return data;
    }

    public void setData(String data) {
        this.data = data;
    }

    public double getWartosc() {
        return wartosc;
    }

    public void setWartosc(double wartosc) {
        this.wartosc = wartosc;
    }

    @Override
    public void wypiszInfo(){
        System.out.println("Nazwa przedmiotu: " + nazwaPrzedmiotu);
        System.out.println("Data: " + data);
        System.out.println("Wartosc: " + wartosc);
    }

}
