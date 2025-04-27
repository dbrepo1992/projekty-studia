#include<iostream>

using namespace std;

/*
  Wszędzie gdzie znajdziesz ???_xx poeksperymentuj
*/

class punkt{
  double x_, y_, z_;

public:
  //*  ???_01  Zobacz co się stanie jeśli nie zdefiniujesz konstruktora domyślnego
  punkt(): x_(0), y_(0), z_(0){}
  // */
  punkt(const double& a1, const double& a2, const double& a3 ): x_(a1), y_(a2), z_(a3){}

    double& x() { return x_; }; // ???_02
    double& y() { return y_; };
    double& z() { return z_; };
  /*
  Dalej musisz popracować samodzielnie
  */

  double x() const { return x_; };
  double y() const { return y_; };
  double z() const { return z_; };

};

class prostokat : public punkt{
  private:
    double a_,b_;

  public:
    prostokat() : punkt(), a_(0), b_(0){}

    // Konstruktor 5-argumentowy
    prostokat(const double& a1, const double& a2, const double& a3,
      const double& a4, const double& a5 )
: punkt(a1, a2, a3 ), a_(a4), b_(a5) {}

      // Konstruktor przyjmujący punkt (p2) oraz a, b
      prostokat(const punkt &p, double a, double b)
      : punkt(p), a_(a), b_(b) {}

    double& a() {return a_; };
    double& b() {return b_; };


    double a() const {return a_; };
    double b() const {return b_; };

    double pole() const { return a_*b_;}
};

class graniastoslup : public prostokat{
  private:
    double h_;

  public:
  graniastoslup() : prostokat(), h_(0){}

   // Konstruktor 6-argumentowy
   graniastoslup(const double& a1, const double& a2, const double& a3,
    const double& a4, const double& a5, const double& a6)
: prostokat(a1, a2, a3, a4, a5 ), h_(a6) {}

    graniastoslup(const prostokat &p, double h)
    : prostokat(p), h_(h){}

    // Konstruktor przyjmujący punkt (p2) oraz a, b
    graniastoslup(const punkt &pt, double a, double b, double h)
    : prostokat(pt, a, b), h_(h) {}

     // Getter/setter dla h_
     double& h()       { return h_; }
     double  h() const { return h_; }

     // Jedyna poprawna definicja objetosc()
     double objetosc() const {
         // korzysta z prostokat::pole() * h
         return pole() * h_;
     }

};



int main(){

  punkt p1, p2(1,2,3);         // ???_01
  const punkt p3(1.1,2.2,3.3);
  cout << p1.x() << endl;
  cout << p2.x() << endl;

                          // ???_02 zobacz czy uda się wyświetlić wartość składowej x_ obiektu p3
  cout << p3.x() << endl;     // Jeśli się nie kompiluje to zwróć uwagę na fakt, że definicja obiektu p3
  // */                       // jest inna niż definicja obiektów p1 i p2.


  // Teraz przenoś komentarz linijka po linijce. Odkomentuj jedną - góra dwie instrukcje
    // i zastanów się jakie funkcjonalności powinna posiadać klasa, by kod mógł się skompilować i wykonać.
    // Zawsze musisz wiedzieć co ma robić jakaś funkcja
    // jak należy ją zadeklarować i jak zdefiniować.
    // Zawsze pamiętaj o typie bądź typach argumentów formalnych
    // i czy funkcja ma coś zwrócić, jeśli tak to w jaki sposób.

  cout << p3.x() << '\t' << p3.y() << '\t' << p3.z() << endl;

  p1.x()=1; p1.y()=10; p1.z()=100;  // ???_03  Zastanów się co tu się dzieje. Jeśli wiesz to dobrze.
                                    // Jeśli nie to pamiętaj, że operator przypisania jest funkcją.
                                    // Chociaż go nie zdefiniowałeś to jest dostępny.
                                    // W tej klasie będzie działał perfekcyjnie (nie zawsze jednak tak jest).
                                    // Zastanów się jaki jest typ lewego i prawego argumentu tego operatora (tej funkcji).

  cout << p1.x() << '\t' << p1.y() << '\t' << p1.z() << endl;



  prostokat pr1, pr2(1,2,3,10.5, 20.5); // Definiując pięcioargumentowy konstruktor klasy prostokat
                                        // pamiętaj, że klasa punkt ma swoje konstruktory.

  const prostokat pr3(p2,5,5);

  pr1.x()=2; pr1.y()=20; pr1.x()=200; pr1.a()= 10; pr1.b()=10;
  cout << pr1.x() << '\t' << pr1.y() << '\t' << pr1.z() << '\t'
       << pr1.a() << '\t' << pr1.b() << '\t' << endl;
  cout << pr1.pole() << endl;


  cout << pr3.x() << '\t' << pr3.y() << '\t' << pr3.z() << '\t'
       << pr3.a() << '\t' << pr3.b() << '\t' << endl;

  cout << pr3.pole() << endl;           // ???_04
                                        // Jeśli zobaczyłeś poprawny wynik na ekranie to dobrze.
                                        // Jeśli miałeś kłopoty ze skompilowaniem tej linii kodu
                                        // to najwyraźniej spartoliłeś* metodę pole(). (*) spartolić to nie jest brzydkie słowo - zobacz w słowniku.
                                        // Ja domyślam się dlaczego.
                                        // Ty jednak musisz popracować sam.
                                        // Wskazówka - wróć do problemu ???_02.
                                        // Jeśli znalazłeś sam rozwiązanie problemu ???_04
                                        // nigdy już nie zapomnisz dlaczego nie chciało się skompilować ;).

  graniastoslup g1, g2(1,2,3,10.5,20.5,30.5), g3(p2,100,200,300);
  const graniastoslup g4(pr3,5);

  cout << g4.x() << '\t' << g4.y() << '\t' << g4.z() << '\n'
       << g4.a() << '\t' << g4.b() << '\t' << g4.h() << '\n'
       << g4.objetosc() << endl;

  g1.a()=10; g1.b()=10; g1.h()=10;

  cout << g1.x() << '\t' << g1.y() << '\t' << g1.z() << '\n'
       << g1.a() << '\t' << g1.b() << '\t' << g1.h() << '\n'
       << g1.objetosc() << endl;


  return 0;
}
