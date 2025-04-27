#include <iostream>



class punkt {
    private:
    double x_, y_, z_;

public:
    // Konstruktor domyślny
    punkt() : x_(0), y_(0), z_(0) {}

    // Konstruktor z parametrami
    punkt(const double& a1, const double& a2, const double& a3) : x_(a1), y_(a2), z_(a3) {}

    // Metody dostępowe zwracające referencje (do modyfikacji)
    double& x() { return x_; }
    double& y() { return y_; }
    double& z() { return z_; }

    // Metody dostępowe const (do odczytu z obiektów const)
    double x() const { return x_; }
    double y() const { return y_; }
    double z() const { return z_; }
};

class prostokat : public punkt {
    double a_, b_;

public:
    // Konstruktor domyślny
    prostokat() : punkt(), a_(0), b_(0) {}

    // Konstruktor z parametrami (x,y,z,a,b)
    prostokat(double x, double y, double z, double a, double b)
        : punkt(x, y, z), a_(a), b_(b) {}

    // Konstruktor przyjmujący punkt (bazowy) oraz wymiary a,b
    prostokat(const punkt& p, double a, double b)
        : punkt(p), a_(a), b_(b) {}

    double& a() { return a_; }
    double& b() { return b_; }

    double a() const { return a_; }
    double b() const { return b_; }

    double pole() const { return a_ * b_; }
};

class graniastoslup : public prostokat {
    double h_;

public:
    // Konstruktor domyślny
    graniastoslup() : prostokat(), h_(0) {}

    // Konstruktor z parametrami (x,y,z,a,b,h)
    graniastoslup(double x, double y, double z, double a, double b, double h)
        : prostokat(x, y, z, a, b), h_(h) {}

    // Konstruktor przyjmujący punkt
    graniastoslup(const punkt& p, double a, double b, double h)
        : prostokat(p, a, b), h_(h) {}

    // Konstruktor przyjmujący prostokat
    graniastoslup(const prostokat& pr, double h)
        : prostokat(pr), h_(h) {}

    double& h() { return h_; }
    double h() const { return h_; }

    double objetosc() const { return pole() * h_; }
};

int main() {
    punkt p1, p2(1, 2, 3);
    const punkt p3(1.1, 2.2, 3.3);

    std::cout << p1.x() << std::endl;  // 0
    std::cout << p2.x() << std::endl;  // 1
    std::cout << p3.x() << std::endl;  // 1.1

    std::cout << p3.x() << '\t' << p3.y() << '\t' << p3.z() << std::endl; // 1.1    2.2    3.3

    p1.x() = 1; p1.y() = 10; p1.z() = 100;
    std::cout << p1.x() << '\t' << p1.y() << '\t' << p1.z() << std::endl; // 1    10   100

    prostokat pr1, pr2(1, 2, 3, 10.5, 20.5);
    const prostokat pr3(p2, 5, 5);

    pr1.x() = 2; pr1.y() = 20; pr1.z() = 200; pr1.a() = 10; pr1.b() = 10;
    std::cout << pr1.x() << '\t' << pr1.y() << '\t' << pr1.z() << '\t'
         << pr1.a() << '\t' << pr1.b() << '\t' << std::endl;
    std::cout << pr1.pole() << std::endl;

    std::cout << pr3.x() << '\t' << pr3.y() << '\t' << pr3.z() << '\t'
         << pr3.a() << '\t' << pr3.b() << '\t' << std::endl;
    std::cout << pr3.pole() << std::endl;

    graniastoslup g1, g2(1, 2, 3, 10.5, 20.5, 30.5), g3(p2, 100, 200, 300);
    const graniastoslup g4(pr3, 5);

    std::cout << g4.x() << '\t' << g4.y() << '\t' << g4.z() << '\n'
         << g4.a() << '\t' << g4.b() << '\t' << g4.h() << '\n'
         << g4.objetosc() << std::endl;

    g1.a() = 10; g1.b() = 10; g1.h() = 10;

    std::cout << g1.x() << '\t' << g1.y() << '\t' << g1.z() << '\n'
         << g1.a() << '\t' << g1.b() << '\t' << g1.h() << '\n'
         << g1.objetosc() << std::endl;

    return 0;
}
