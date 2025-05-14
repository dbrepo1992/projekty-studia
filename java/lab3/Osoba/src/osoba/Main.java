package osoba;


public class Main {
        public static void main(String[] args) {
            Osoba o = new Osoba("Adam", "Adamowski", "1990-02-02");
            Osoba o2= new Student("Marek", "Markowski", "1980-01-01", 2, 3, 12345);
            Osoba o3= new Pilkarz("Jan", "Jankowski", "2000-12-12", "napastnik", "FC Barcelona");
            o.wypiszInfo();
            o2.wypiszInfo();
            o3.wypiszInfo();
            Student s = new Student("Kamil", "Kaminski", "1999-08-03", 2, 5, 12121);
            Pilkarz p = new Pilkarz("Damian", "Daminski", "2001-04-04", "obronca", "AC Milan");
            s.wypiszInfo();
            p.wypiszInfo();
            ((Pilkarz)o3).strzelGola();
            p.strzelGola();
            p.strzelGola();
            o3.wypiszInfo();
            p.wypiszInfo();
            ((Student)o2).dodajOcene("Progamowanie obiektowe", "2020-04-24", 5);
            ((Student)o2).dodajOcene("Bazy danych", "2020-04-14", 5);
            o2.wypiszInfo();
            s.dodajOcene("Bazy danych", "2020-03-20", 5);
            s.dodajOcene("Matematyka", "2020-03-15", 3);
            s.dodajOcene("Matematyka", "2020-03-20", 2);
            s.wypiszInfo();
            s.usunOcene("Matematyka", "2020-03-15", 3);
            s.wypiszInfo();
            s.dodajOcene("Matematyka", "2020-03-15", 4);
            s.usunOceny("Matematyka");
            s.wypiszInfo();
            s.dodajOcene("Matematyka", "2020-03-15", 4);
            s.usunOceny();
            s.wypiszInfo();
            PilkarzReczny reczny = new PilkarzReczny("Tomasz", "Tracz", "1998-07-20", "skrzydłowy", "Vive Kielce");
            reczny.strzelGola();
            PilkarzNozny nozny = new PilkarzNozny("Robert", "Lewandowski", "1985-05-15", "Napastnik", "FC Barcelona");
            nozny.strzelGola();
    }
}
