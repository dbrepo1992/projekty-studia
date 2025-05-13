package budynek;


public class Budynek {
    protected String adres;

    // konstruktor, który inicjuje nowo tworzony obiekt adresem.
    public Budynek (String adres) {
        this.adres = adres;
        }

    public String getAdres () {
        return adres;
        }

    public void setAdres(String adres) {
        this.adres = adres;
        }

        public void wypiszInfo () {
            System.out.println(adres);
        }

}
