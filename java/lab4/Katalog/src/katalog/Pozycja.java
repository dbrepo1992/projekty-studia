package katalog;

public abstract class Pozycja {
    protected String tytul;
    protected int id;
    protected String wydawnictwo;
    protected int rokWydania;

    public Pozycja() {

    }

    public Pozycja(String tytul, int id, String wydawnictwo, int rokWydania) {
        this.tytul = tytul;
        this.id = id;
        this.wydawnictwo = wydawnictwo;
        this.rokWydania = rokWydania;
    }


    public String getTytul() {
    return tytul;
    }


    public int getId() {
    return id;
    }


    public abstract void WypiszInfo();
}
