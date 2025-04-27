#include <iostream>
#include <string>

using namespace std;

/******************************************************
 *  1. Klasa abstrakcyjna pojazd
 ******************************************************/
class pojazd
{
public:
    // Wirtualny destruktor dla klasy bazowej
    virtual ~pojazd() {}

    // Metoda czysto wirtualna (sprawia, że klasa jest abstrakcyjna)
    virtual void info(std::ostream &out) const = 0;

    // Operator << wywołujący polimorficznie metodę info()
    friend std::ostream& operator<<(std::ostream &out, const pojazd &p)
    {
        p.info(out);
        return out;
    }
};

/******************************************************
 *  2. Klasa samochod dziedzicząca po pojazd
 ******************************************************/
class samochod : public pojazd
{
protected:
    string marka;
    string model;

public:
    // Konstruktor domyślny
    samochod() : marka("nieznana"), model("nieznany")
    {
    }

    // Konstruktor z parametrami
    samochod(const string &m, const string &mo)
        : marka(m), model(mo)
    {
    }

    // Wirtualny destruktor
    virtual ~samochod()
    {
    }

    // Implementacja metody info() z klasy pojazd
    virtual void info(std::ostream &out) const override
    {
        out << "Samochod: " << marka << " " << model << endl;
    }
};

/******************************************************
 *  3. Klasa autobus dziedzicząca po samochod
 ******************************************************/
class autobus : public samochod
{
private:
    bool pietrowy;   // czy autobus jest piętrowy
    int I_miejsc;    // liczba miejsc dla pasażerów

public:
    // Konstruktor domyślny
    autobus()
        : samochod(), pietrowy(false), I_miejsc(0)
    {
    }

    // Konstruktor wywołujący konstruktor klasy bazowej (samochod)
    autobus(const string &m, const string &mo, bool p, int ile_miejsc)
        : samochod(m, mo), pietrowy(p), I_miejsc(ile_miejsc)
    {
    }

    // Przeładowanie operatora przypisania dla typu int
    // (zmienia liczbę miejsc w autobusie)
    autobus &operator=(int nowa_liczba_miejsc)
    {
        I_miejsc = nowa_liczba_miejsc;
        return *this;
    }

    // Nadpisanie metody info() (klasa bazowa -> pojazd -> samochod)
    virtual void info(std::ostream &out) const override
    {
        out << "Autobus: "
            << marka << " " << model
            << ", pietrowy: " << (pietrowy ? "tak" : "nie")
            << ", liczba miejsc: " << I_miejsc << endl;
    }
};

/******************************************************
 *  4. Nowa klasa sterowiec dziedzicząca po pojazd
 ******************************************************/
class sterowiec : public pojazd
{
private:
    string nazwa;
    int objetosc;    // Objętość sterowca (przykładowo w metrach sześciennych)

public:
    // Konstruktor domyślny
    sterowiec()
        : nazwa("Nieznany"), objetosc(0)
    {
    }

    // Konstruktor z parametrami
    sterowiec(const string &n, int o)
        : nazwa(n), objetosc(o)
    {
    }

    // Nadpisanie abstrakcyjnej metody info()
    virtual void info(std::ostream &out) const override
    {
        out << "Sterowiec: " << nazwa
            << ", o objetosci: " << objetosc << " m^3" << endl;
    }
};

/******************************************************
 *  Funkcja main z kodem testującym zarówno
 *  z zadania poprzedniego (zadanie 3), jak i nowym
 ******************************************************/
int main()
{
    // --- Kod z zadania poprzedniego (3) ---
    {
        cout << "===== Test z zadania poprzedniego (3) =====" << endl;

        samochod s1;
        s1.info(cout);  // Samochod: nieznana nieznany

        samochod s2("Audi", "A5");
        s2.info(cout);  // Samochod: Audi A5
        cout << "===============================\n";

        autobus a1;
        a1.info(cout);  // Autobus: nieznana nieznany, pietrowy: nie, liczba miejsc: 0

        autobus a2("Wrightbus", "New Routemaster", true, 62);
        a2.info(cout);  // Autobus: Wrightbus New Routemaster, ...
        a2 = 87;        // Przeładowany operator= zmienia liczbę miejsc
        a2.info(cout);

        cout << "=======================\n";
        samochod *s3 = new autobus("Ikarus", "200", false, 160);
        s3->info(cout);
        static_cast<autobus*>(s3)->info(cout);
        delete s3;

        cout << "************* 3.0 *******************\n\n";
    }

    // --- Kod testujący z nowego zadania (4) ---
    {
        cout << "===== Test z zadania (4) - polimorficzne wypisywanie przez operator<< =====\n";

        // Tworzenie różnych obiektów
        samochod s1("Seat", "Leon");
        cout << s1;  // operator<< wykorzystuje pojazd::info() (polimorficznie)

        autobus a1;
        cout << a1;

        autobus a2("Wrightobus", "New routemaster", true, 62);
        cout << a2;

        sterowiec st1;
        cout << st1;

        sterowiec st2("Zeppelin NT", 8225);
        cout << st2;

        cout << "=====================\n";
        // Tablica wskaźników do pojazdów
        pojazd* tab[] = {
            &s1,   // samochod
            &a1,   // autobus
            &a2,   // autobus
            &st1,  // sterowiec
            &st2   // sterowiec
        };

        for(size_t i=0; i<5; ++i) {
            cout << *tab[i]; // Każdy wywoła właściwe info() w zależności od typu obiektu
        }

        cout << "************************* 4.0 *****************\n";
    }

    return 0;
}
