#include <iostream>
#include <string>
#include <fstream>

using namespace std;

class K1 {
    string *p1;
public:
    // Konstruktor domyślny
    K1() {
        p1 = new string[2];
    }

    // Konstruktor z dwoma stringami
    K1(const string &s1, const string &s2) {
        p1 = new string[2];
        p1[0] = s1;
        p1[1] = s2;
    }

    // Konstruktor kopiujący
    K1(const K1 &other) {
        p1 = new string[2];
        p1[0] = other.p1[0];
        p1[1] = other.p1[1];
    }

    // Destruktor
    ~K1() {
        delete[] p1;
    }

    // Operator przypisania
    K1& operator=(const K1 &other) {
        if (this != &other) {
            p1[0] = other.p1[0];
            p1[1] = other.p1[1];
        }
        return *this;
    }

    // Dostęp do elementów (opcjonalnie)
    string& operator[](int i) {
        return p1[i];
    }

    const string& operator[](int i) const {
        return p1[i];
    }
};

class K2 {
    K1 w1;
    double w2;
public:
    // Konstruktor domyślny
    K2(): w2(0.0) {}

    // Konstruktor z parametrami (dwa napisy i double)
    K2(const string &s1, const string &s2, double d): w1(s1,s2), w2(d) {}

    // Konstruktor kopiujący
    K2(const K2 &other): w1(other.w1), w2(other.w2) {}

    // Operator przypisania
    K2& operator=(const K2 &other) {
        if (this != &other) {
            w1 = other.w1;
            w2 = other.w2;
        }
        return *this;
    }

    // Operatory arytmetyczne dla w2
    friend K2 operator-(const K2 &obj, double val) {
        K2 temp(obj);
        temp.w2 -= val;
        return temp;
    }

    friend K2 operator+(const K2 &obj, double val) {
        K2 temp(obj);
        temp.w2 += val;
        return temp;
    }

    // operator += dla int
    K2& operator+=(int val) {
        w2 += val;
        return *this;
    }

    // Operatory łączenia stringów:
    // K2 + string -> dodajemy do w1[1]
    friend K2 operator+(const K2 &obj, const string &str) {
        K2 temp(obj);
        temp.w1[1] += str;
        return temp;
    }

    // string + K2 -> dodajemy do w1[0]
    friend K2 operator+(const string &str, const K2 &obj) {
        K2 temp(obj);
        temp.w1[0] = str + temp.w1[0];
        return temp;
    }

    // Operator << do wyświetlania
    friend ostream& operator<<(ostream &os, const K2 &obj) {
        os << obj.w1[0] << " " << obj.w1[1] << " " << obj.w2 << "\n";
        return os;
    }
};

int main() {
    K2 ob1, ob2;
    const K2 *wsk1 = new K2("kawa", "z mlekiem", 4.50);
    const K2 ob3(*wsk1);
    delete wsk1;
    wsk1=0;

    const K2 *wsk2 = new K2(ob3);
    ob2 = *wsk2;
    cout << ob1 << *wsk2;
    delete wsk2;
    wsk2=0;

    cout << ob2;
    cout << (ob2 - 1.25) ; // operacja dotyczy składowej w2
    cout << "*****   3   *****\n" << endl;

    K2 tab[4];

    // odczyt danych z pliku data.txt
    {
        ifstream fin("data.txt");
        if (fin) {
            for (int i=0; i<4; i++) {
                string s1, s2;
                double d;
                fin >> s1 >> s2 >> d;
                tab[i] = K2(s1, s2, d);
            }
        }
        fin.close();
    }

    for (int i=0; i<4; ++i){
        tab[i] += 1;    // modyfikujemy w2
        cout << tab[i];
    }
    cout << "*****   4   *****\n" << endl;

    tab[1] = tab[1] + " with sugar";  // dodajemy napis do w1[1]
    tab[3] = "hot " + tab[3];         // dodajemy napis do w1[0]

    for (int i=0; i<4; ++i)
        cout << tab[i];

    cout << "*****   5   *****\n" << endl;

    return 0;
}
