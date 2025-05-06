package samochod;

public class Samochod {

    private String marka;
    private String model;
    private int iloscDrzwi;
    private int pojemnoscSilnika;
    private double srednieSpalanie;
    private static int iloscSamochodow = 0;

    public Samochod() {
        marka = "nieznana";
        model = "nieznany";
        iloscDrzwi = 0;
        pojemnoscSilnika = 0;
        srednieSpalanie = 0.0;
    }


    // Created get and set functions for each private
    //              ||
    //              ||
    //             \  /
    //              \/


    // getter marka
    public String getMarka() {
        return marka;
    }

    // setter marka
    public void setMarka(String marka) {
        this.marka = marka;
    }




    // setter model
    public String setModel() {
        return model;
    }

    // getter model
    public void setModel(String model) {
        this.model = model;
    }




    // getter iloscDrzwi
    public int getIloscDrzwi() {
        return iloscDrzwi;
    }
    // setter iloscDrzwi
    public void setIloscDrzwi(int iloscDrzwi) {
        this.iloscDrzwi = iloscDrzwi;
    }




    // getter pojemnoscSilnika
    public int getPojemnoscSilnika() {
        return pojemnoscSilnika;
    }
    // setter pojemnoscSilnika
    public void setPojemnoscSilnika(int pojemnoscSilnika) {
        this.pojemnoscSilnika = pojemnoscSilnika;
    }





    // getter srednieSpalanie
    public double getSrednieSpalanie() {
        return srednieSpalanie;
    }
    // setter srednieSpalanie
    public void setSrednieSpalanie(double srednieSpalanie) {
        this.srednieSpalanie = srednieSpalanie;
    }


    public static void main(String[] args) {

    }

}
