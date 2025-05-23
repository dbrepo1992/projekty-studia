// ========================
// Zadanie 6.1 – Porównanie klas (z DateTime zamiast Stopwatch)
// ========================

using System;
using System.Collections.Generic;

class ParaInt
{
    public int Pierwszy { get; }
    public int Drugi { get; }

    public ParaInt(int pierwszy, int drugi)
    {
        Pierwszy = pierwszy;
        Drugi = drugi;
    }
}

class Para<T>
{
    public T Pierwszy { get; }
    public T Drugi { get; }

    public Para(T pierwszy, T drugi)
    {
        Pierwszy = pierwszy;
        Drugi = drugi;
    }
}

// ========================
// Zadanie 6.2 – Klasa z ograniczeniem class, new()
// ========================

class Klasa<T> where T : class, new()
{
    public T Wartosc { get; }

    public Klasa(T wartosc)
    {
        Wartosc = wartosc;
    }

    public T NowaWartosc()
    {
        return new T();
    }
}

class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
}

// ========================
// Zadanie 6.3 – Klonowanie wartości
// ========================

class KlasaKopiowalna<T> where T : class, ICloneable, new()
{
    public T Wartosc { get; }

    public KlasaKopiowalna(T wartosc)
    {
        Wartosc = wartosc;
    }

    public T NowaWartosc()
    {
        return new T();
    }

    public T Kopia()
    {
        return (T)Wartosc.Clone();
    }
}

// ========================
// Zadanie 6.4 – Klasa Osoba z IComparable wg wieku
// ========================

class OsobaPorownywalna : IComparable<OsobaPorownywalna>
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public int Wiek { get; set; }

    public int CompareTo(OsobaPorownywalna inna)
    {
        return this.Wiek.CompareTo(inna.Wiek);
    }
}

// ========================
// Zadanie 6.5 – Generyczne drzewo binarne
// ========================

class Wezel<T> where T : IComparable<T>
{
    public T Wartosc;
    public Wezel<T> Lewy;
    public Wezel<T> Prawy;

    public Wezel(T wartosc)
    {
        Wartosc = wartosc;
    }
}

class DrzewoBST<T> where T : IComparable<T>
{
    private Wezel<T> korzen;

    public void Dodaj(T wartosc)
    {
        korzen = DodajRek(korzen, wartosc);
    }

    private Wezel<T> DodajRek(Wezel<T> wezel, T wartosc)
    {
        if (wezel == null) return new Wezel<T>(wartosc);
        if (wartosc.CompareTo(wezel.Wartosc) < 0)
            wezel.Lewy = DodajRek(wezel.Lewy, wartosc);
        else
            wezel.Prawy = DodajRek(wezel.Prawy, wartosc);
        return wezel;
    }

    public void InOrder()
    {
        InOrderRek(korzen);
        Console.WriteLine();
    }

    private void InOrderRek(Wezel<T> wezel)
    {
        if (wezel == null) return;
        InOrderRek(wezel.Lewy);
        Console.Write("{0} ", wezel.Wartosc);
        InOrderRek(wezel.Prawy);
    }
}

// ========================
// Zadanie 6.6 – Kolekcja obiektów różnych typów
// ========================

class Kolekcja
{
    private Dictionary<string, object> slownik = new Dictionary<string, object>();

    public void Dodaj(string klucz, object wartosc)
    {
        slownik[klucz] = wartosc;
    }

    public T Pobierz<T>(string klucz)
    {
        return (T)slownik[klucz];
    }
}

// ========================
// Zadanie 6.7 – Kowariancja i kontrawariancja
// ========================

class OsobaB { }
class Student : OsobaB { }
class Pracownik : OsobaB { }

interface Pobieranie<out T>
{
    T Pobierz();
}

interface Przechowywanie<in T>
{
    void Przechowaj(T wartosc);
}

class MagazynDanychoStudentach : Pobieranie<Student>, Przechowywanie<Student>
{
    public Student Pobierz() { return new Student(); }
    public void Przechowaj(Student wartosc) { }
}

class MagazynDanychOPracownikach : Pobieranie<Pracownik>
{
    public Pracownik Pobierz() { return new Pracownik(); }
}

class MagazynDanychoOsobach : Pobieranie<OsobaB>, Przechowywanie<OsobaB>
{
    public OsobaB Pobierz() { return new OsobaB(); }
    public void Przechowaj(OsobaB wartosc) { }
}

// ========================
// Main 
// ========================

class ProgramAll
{
    static void Main(string[] args)
    {
        // 6.1
        const int N = 100_000_000;
        long wynik = 0;

        var p1 = new ParaInt(1, 2);
        DateTime start1 = DateTime.Now;
        for (int i = 0; i < N; i++) wynik = p1.Pierwszy + p1.Drugi;
        DateTime end1 = DateTime.Now;
        Console.WriteLine("ParaInt: {0} ms", (end1 - start1).TotalMilliseconds);

        var p2 = new Para<int>(1, 2);
        DateTime start2 = DateTime.Now;
        for (int i = 0; i < N; i++) wynik = p2.Pierwszy + p2.Drugi;
        DateTime end2 = DateTime.Now;
        Console.WriteLine("Para<T>: {0} ms", (end2 - start2).TotalMilliseconds);

        // 6.2
        var osoba = new Osoba();
        osoba.Imie = "Ala";
        osoba.Nazwisko = "Kot";
        var klasa = new Klasa<Osoba>(osoba);
        Console.WriteLine("Osoba: {0} {1}", klasa.Wartosc.Imie, klasa.Wartosc.Nazwisko);

        // 6.4
        var osoby = new List<OsobaPorownywalna>();
        osoby.Add(new OsobaPorownywalna { Imie = "Ala", Nazwisko = "Kowalska", Wiek = 20 });
        osoby.Add(new OsobaPorownywalna { Imie = "Jan", Nazwisko = "Nowak", Wiek = 25 });
        osoby.Sort();
        Console.WriteLine("Osoby posortowane wg wieku:");
        foreach (var o in osoby)
        {
            Console.WriteLine("{0} ({1})", o.Imie, o.Wiek);
        }

        // 6.5
        var drzewo = new DrzewoBST<int>();
        drzewo.Dodaj(5);
        drzewo.Dodaj(2);
        drzewo.Dodaj(8);
        drzewo.InOrder();

        // 6.6
        var kolekcja = new Kolekcja();
        kolekcja.Dodaj("pierwsza", 42);
        kolekcja.Dodaj("druga", 3.14);
        kolekcja.Dodaj("trzecia", "test");
        Console.WriteLine(kolekcja.Pobierz<int>("pierwsza"));
        Console.WriteLine(kolekcja.Pobierz<string>("trzecia"));

        // 6.7
        Pobieranie<OsobaB> m1 = new MagazynDanychoStudentach();
        Przechowywanie<Student> m2 = new MagazynDanychoOsobach();
    }
}
