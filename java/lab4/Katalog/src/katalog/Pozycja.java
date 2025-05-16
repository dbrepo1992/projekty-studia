package katalog;

public interface Pozycja {
    protected String tytul;
    protected int id;
    protected String wydawnictwo;
    protected int rokWydania;

    public Pozycja() {

    }

    public Pozycja(String tytul, int id, String wydawnictwo, int rokWydania) {

    }

    public void WypiszInfo() {
        
    }
}
