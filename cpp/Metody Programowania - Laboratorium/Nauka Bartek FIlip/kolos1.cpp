#include <iostream>
#include <fstream>

using namespace std;

class K1{
    string * p1;
    public:
};
class K2{
    K1 txt[2];
    w1;
    public:

};


int main() {
K2 ob1, ob2;
    const K2 * wsk1 = new K2("Ala", "Koala", 15);
    const K2 ob3(wsk1);
    delete wsk1;
    wsk1=0;

    const K2 wsk2 = new K2(ob3);
    ob2=wsk2;
    cout << ob1 <wsk2;
    delete wsk2;
    wsk2=0;

    cout << ob2;
    cout << (ob2+10);
    cout << "  3  \n" << endl;

    K2 tab[4];
    // ... <- odczyt danych

    for (int i=0; i<4; i++) {
        tab[i]+=1;
        cout << tab[i];
    }
    cout << "**  4  \n" << endl;

    tab[1] = tab[1] + " Kowalska";
    tab[3] = "Bocian " + tab[3];

    for(int i=0; i<4; i++) {
        cout << tab[i];
    }

    cout << "  5  *\n" << endl;
};
