class K1{           // W klasie K1 składowa p1 jest wskaźnikiem do dwuelementowej dynamicznej tablicy obiektów typu string
    string * p1;
    public:
    K1() {
        p1 = new string[2];
    }

    K1(const string& s1, const string& s2) {
        p1 = new string[2];
        p1[0]=s1;
        p1[1]=s2;
    }
    //..            // Klasa K2 posiada pole typu K1.
}

class K2{           // Klasy wyposażyć w zbiór niezbędnych metod gwarantujących poprawność funkcjonowania ich obiektów(tworzenie, kopiowanie, przypisywanie, ...).
    K1 dane;
    public:         // Do testowania poprawności tych klas wykorzystać instrukcje zamieszczone poniżej.
    // ...
}

K2 o1, o2;
const K2* wsk1 = new K2("Ala", "Ola");
const K2 o3(*wsk1);

cout << "o2 : " << o2 << endl;
cout << "o3 : " << o3 << endl;
cout << "*******" << endl;
delete wsk1;
wsk1 = 0;

wsk1 = new K2(o3);
o2 = *wsk1;
cout << "o1 : " << o1 << endl;
cout << "o2 : " << o2 << endl;
cout << "********" << endl;
delete wsk1;
wsk1 = 0;

o1 = K2("Ewa", "Iza");
cout << o1[0] << ". " << o1[1] << endl;
o1.[1] = "Jan";
cout << o1[0] << ", " << o1[1] << endl;
