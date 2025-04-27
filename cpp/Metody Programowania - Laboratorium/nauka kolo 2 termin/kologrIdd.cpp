#include <iostream>
#include <string>
#include <fstream>

using namespace std;

// Klasa K1 – ma tylko tablicę dwuelementową stringów.
class K1 {
    string tab[2];
public:
    // Konstruktor domyślny – ustawia "brak" w obu polach.
    K1() {
        tab[0] = "brak";
        tab[1] = "brak";
    }

    // Konstruktor przyjmujący dwa stringi.
    K1(const string &s1, const string &s2) {
        tab[0] = s1;
        tab[1] = s2;
    }

    // Operator indeksowy do odczytu/zapisu.
    // Gdy indeks jest niepoprawny, zwracamy statyczny napis błędu,
    // dzięki czemu np. "cout << ob1.w1()[2];" wypisze ten komunikat.
    string& operator[](int i) {
        static string out_of_range = "Blad - indeks poza zakresem";
        if(i < 0 || i > 1) {
            return out_of_range;
        }
        return tab[i];
    }

    // Wersja const dla obiektów stałych.
    const string& operator[](int i) const {
        static const string out_of_range = "Blad - indeks poza zakresem";
        if(i < 0 || i > 1) {
            return out_of_range;
        }
        return tab[i];
    }
};

// Klasa K2 – zawiera wskaźnik do K1 (alokowany dynamicznie) i pole double.
class K2 {
    K1 *w1_;   // wskaźnik na obiekt klasy K1
    double w2_;

public:
    // Konstruktor domyślny – tworzy K1 z "brak" i ustawia w2_=0.
    K2() {
        w1_ = new K1();  // tab = ["brak","brak"]
        w2_ = 0.0;
    }

    // Konstruktor z dwoma stringami i double.
    K2(const string &s1, const string &s2, double d) {
        w1_ = new K1(s1,s2);
        w2_ = d;
    }

    // Destruktor – zwalnia dynamiczny obiekt K1.
    ~K2() {
        delete w1_;
    }

    // Konstruktor kopiujący – musi skopiować w1_ głęboko.
    K2(const K2 &other) {
        w1_ = new K1(*other.w1_); // skopiuj obiekt K1
        w2_ = other.w2_;
    }

    // Operator przypisania – również głęboka kopia.
    K2& operator=(const K2 &other) {
        if(this != &other) {
            delete w1_;                // usuń dotychczasowe w1_
            w1_ = new K1(*other.w1_);  // alokuj nowe i skopiuj
            w2_ = other.w2_;
        }
        return *this;
    }

    // Dostęp do obiektu K1 przez metodę w1() – zwraca referencję
    // (żeby np. móc pisać ob.w1()[0] = "coś").
    K1& w1() {
        return *w1_;
    }
    const K1& w1() const {
        return *w1_;
    }

    // Dostęp do skalarnego pola w2_:
    double& w2() {
        return w2_;
    }
    double w2() const {
        return w2_;
    }

    // operator+= (dodaje wartość d do w2_)
    K2& operator+=(double d) {
        w2_ += d;
        return *this;
    }

    // operator<< do wypisywania w postaci "w1_[0] w1_[1] w2_"
    friend ostream& operator<<(ostream &os, const K2 &obj) {
        os << obj.w1()[0] << " " << obj.w1()[1] << " " << obj.w2();
        return os;
    }

    // operator+ (K2 + double) – zwraca nowy obiekt z w2_ powiększonym o d
    friend K2 operator+(const K2 &left, double d) {
        K2 temp(left);
        temp.w2_ += d;
        return temp;
    }
};

// operator+ (string + K2)
// Ma tworzyć nowy obiekt K2, gdzie w1_[0] będzie "string + stare w1_[0]",
// a pozostałe pola skopiowane z K2.
K2 operator+(const string &s, const K2 &right) {
    K2 temp(right);
    // Doklejamy s do pierwszego stringa w tablicy obiektu right.
    temp.w1()[0] = s + temp.w1()[0];
    return temp;
}

/*
// Przykładowy main z instrukcjami testowymi:
int main() {
    K2 ob1, ob2("Ala","Ela",2.71);
    const K2 *wsk1 = new const K2; // domyślny: "brak","brak",0

    // Powinno wypisać:  "brak brak 0 Ala Ela 2.71 brak brak 0"
    cout << ob1 << " " << ob2 << " " << *wsk1 << endl;

    // ob1 = ob2 = *wsk1 => najpierw ob2 = *wsk1, potem ob1 = ob2
    ob1 = ob2 = *wsk1;
    delete wsk1;
    // Powinno wypisać:  "brak brak 0 brak brak 0"
    cout << ob1 << " " << ob2 << endl;

    // Ustawiamy ob1 i ob2
    ob1 = K2("pies","kot",3.14);
    ob1.w1()[0] = "moja ocena średnia";
    ob2.w2() = 2.50;

    // Powinno wypisać:
    //  pies kot 3.14
    //  ---
    //  moja ocena średnia to 2.5
    cout << ob1 << "---\n" << ob2 << endl;

    // Dodajemy 0.5 => 3.0
    ob2 += 0.5;
    // Powinno wypisać:  "moja ocena średnia to 3"
    cout << ob2 << endl;

    // Próba dostępu do [2] => wypisze "Błąd - indeks poza zakresem"
    cout << ob1.w1()[2] << endl;

    // Łączenie string + K2 + double => "teraz moja ocena średnia to 3.5"
    ob1 = string("teraz ") + ob2 + 0.5;
    cout << ob1 << endl;

    return 0;
}
*/

int main() {
    K2 ob1, ob2("Ala", "Ela", 2.71);
    const K2 *wsk1 = new const K2;  // tworzy obiekt z konstruktorem domyślnym
    cout << ob1 << "\n" << ob2 << endl;

    ob1 = ob2 = *wsk1;
    delete wsk1;
    cout << ob1 << "\n" << ob2 << endl;

    ob1 = K2("pies", "kot", 3.14);
    ob2.w1()[0] = "moja ocena srednia";
    ob2.w1()[1] = "to";
    ob2.w2() = 2.50;
    cout << ob1 << "\n" << ob2 << endl;

    ob2 += 0.5;
    cout << ob2 << endl;

    // UWAGA: tutaj jest wyjście poza zakres [2] => brak kontroli
    cout << ob1.w1()[2] << endl;
    //
    ob1 = "teraz " + ob2 + 0.5;
    cout << ob1 << endl;

    return 0;
}

