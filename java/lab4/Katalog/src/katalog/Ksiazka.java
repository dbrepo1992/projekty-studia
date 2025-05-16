package katalog;

public class Ksiazka extends Pozycja {
    private int liczbaStron;
    private Autor autor;

    public Ksiazka() {
        super();
    }

    public Ksiazka(String tytul_, int id_, String wydawnictwo_, int rokWydania_, int liczbaStron_, Autor autor) {
        super(tytul_, id_, wydawnictwo_, rokWydania_);
        this.liczbaStron = liczbaStron_;
        this.autor = autor;
    }

    public int getLiczbaStron() {
        return liczbaStron;
    }

    public void setLiczbaStron(int liczbaStron) {
        this.liczbaStron = liczbaStron;
    }



    public void DodajAutora(Autor autor){
        this.autor = autor;
    }

    @Override
    public void WypiszInfo() {
    System.out.println("Tytuł: " + tytul);
    System.out.println("ID: " + id);
    System.out.println("Wydawnictwo: " + wydawnictwo);
    System.out.println("Rok wydania: " + rokWydania);
    System.out.println("Liczba stron: " + liczbaStron);
    if (autor != null) {
        autor.wypiszInfo();
        }
    }
}
