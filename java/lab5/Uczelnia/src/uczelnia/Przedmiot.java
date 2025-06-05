package uczelnia;


public class Przedmiot implements IInfo {
    private String nazwa = "";
    private String kierunek = "";
    private String specjalnosc = "";
    private int semestr = 0;
    private int liczbaGodzin = 0;


    public Przedmiot(String nazwa, String kierunek, String specjalnosc, int semestr, int liczbaGodzin) {
        this.nazwa = nazwa;
        this.kierunek = kierunek;
        this.specjalnosc = kierunek;
        this.semestr = semestr;
        this.liczbaGodzin = liczbaGodzin;
    }

    public String getNazwa(){
        return nazwa;
    }

    public void setNazwa(String nazwa){
        this.nazwa = nazwa;
    }

    public String getKierunek(){
        return kierunek;
    }

    public void setKierunek(String kierunek){
        this.kierunek = kierunek;
    }

    public String getSpecjalnosc(){
        return specjalnosc;
    }

    public void setSpecjalnosc(String specjalnosc){
        this.specjalnosc = specjalnosc;
    }

    public int getSemestr(){
        return semestr;
    }

    public void setSemestr(int semestr){
        this.semestr = semestr;
    }

    public int getLiczbaGodzin(){
        return liczbaGodzin;
    }

    public void setLiczbaGodzin(int liczbaGodzin){
        this.liczbaGodzin = liczbaGodzin;
    }

    @Override
    public void wypiszInfo(){
        System.out.println("Przedmiot: " + nazwa);
        System.out.println("Kierunek: " + kierunek);
        System.out.println("Specjalnosc: " + specjalnosc);
        System.out.println("Semestr: " + semestr);
        System.out.println("Liczba: " + liczbaGodzin);
    }
}
