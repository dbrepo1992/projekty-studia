
package figurageometryczna;


public abstract class FiguraGeometryczna {
    protected String nazwa = null;
    public abstract double obliczPole(); // wymusza implementację tej metody w klasach potomnych (Kwadrat, Kolo, itp.).

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }


}
