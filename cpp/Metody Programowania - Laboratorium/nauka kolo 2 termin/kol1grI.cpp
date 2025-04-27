#include <iostream>
#include <string>

using namespace std;

// Klasa bazowa "samochod"
class samochod
{
protected:
    string marka;
    string model;

public:
    // Konstruktor domyślny
    samochod() : marka("nieznana"), model("nieznany")
    {
    }

    // Konstruktor przyjmujący markę i model
    samochod(const string &m, const string &mo) : marka(m), model(mo)
    {
    }

    // Wirtualny destruktor, aby umożliwić poprawne usuwanie obiektów przez wskaźnik bazowy
    virtual ~samochod()
    {
    }

    // Metoda wypisująca informację o samochodzie
    virtual void info(ostream &out) const
    {
        out << "Samochod: " << marka << " " << model << endl;
    }
};

// Klasa pochodna "autobus"
class autobus : public samochod
{
private:
    bool pietrowy;    // czy autobus jest piętrowy
    int I_miejsc;     // liczba miejsc dla pasażerów

public:
    // Konstruktor domyślny
    autobus() : samochod(), pietrowy(false), I_miejsc(0)
    {
    }

    // Konstruktor wywołujący konstruktor klasy bazowej
    autobus(const string &m, const string &mo, bool p, int ile_miejsc)
        : samochod(m, mo), pietrowy(p), I_miejsc(ile_miejsc)
    {
    }

    // Przeładowanie operatora przypisania dla liczby miejsc
    autobus &operator=(int nowa_liczba_miejsc)
    {
        I_miejsc = nowa_liczba_miejsc;
        return *this;
    }

    // Metoda wypisująca informację o autobusie (nadpisuje metodę bazową)
    virtual void info(ostream &out) const override
    {
        out << "Autobus: "
            << marka << " " << model
            << ", pietrowy: " << (pietrowy ? "tak" : "nie")
            << ", liczba miejsc: " << I_miejsc << endl;
    }
};

int main()
{
    // Kod testujący
    samochod s1;
    s1.info(cout);

    samochod s2("Audi", "A5");
    s2.info(cout);
    cout << "===============================\n";

    autobus a1;
    a1.info(cout);

    autobus a2("Wrightbus", "New Routemaster", true, 62);
    a2.info(cout);
    a2 = 87;  // wykorzystanie przeładowanego operatora=
    a2.info(cout);

    cout << "=======================\n";
    samochod *s3 = new autobus("Ikarus", "200", false, 160);
    s3->info(cout);

    // Rzutowanie, aby wywołać info specyficzne dla autobusu
    static_cast<autobus*>(s3)->info(cout);
    delete s3;

    cout << "************* 3.0 *******************\n";

    return 0;
}
