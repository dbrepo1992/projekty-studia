package iinstrument;

import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        IInstrument a = new Akordeon();
        IInstrument b = new Beben();
        IInstrument c = new Cymbaly();
        IInstrument t = new Traba();

         List<IInstrument> orkiestra = new ArrayList<IInstrument>();
        orkiestra.add(a);
        orkiestra.add(b);
        orkiestra.add(c);
        orkiestra.add(t);

        System.out.print("Orkiestra w składzie: ");
        for (IInstrument instrument : orkiestra) {
            System.out.print( instrument.getNazwa() + ", " );
        }
        System.out.println();
        for (IInstrument instrument : orkiestra) {
            instrument.graj();
        }
    }

}
