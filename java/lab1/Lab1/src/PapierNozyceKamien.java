import java.util.Scanner;

public class PapierNozyceKamien {

    // Tablica wypełniona elementami do wyboru w grze
    static String nazwy[] = { "papier", "nozyce", "kamien" };
    
    
    // Funkcja zwraca nazwę przedmiotu w zależności od wybranego kodu
    static String podajNazwe(int id) { 
    return nazwy[id]; 
    }
    
    
    // W celu uzyskania losowej wartości ze zbioru (0,1,2) liczbę tę należy pomnożyć przez 3 i zamienić na liczbę całkowitą. 
    static int losujPrzedmiot() { 
    return (int)(Math.random() * 3); 
    } 
    
    //Funkcja zwraca wskazany przez gracza przedmiot
    static int pytanieOPrzedmiot() { 
        Scanner sc = new Scanner(System.in); 
        int przedmiot; 
        System.out.print("Jaki wybierasz przedmiot? "); 
        System.out.println("0 - papier, 1 - nozyce, 2 - kamien:"); 
        przedmiot = sc.nextInt(); 
         
        
        if (przedmiot == 0) {
            System.out.println("Wybrałeś Papier");
        } else if (przedmiot == 1) {
            System.out.println("Wybrałeś Nozyce");
        } else if (przedmiot == 2) {
            System.out.println("Wybrałeś Kamien");
        } else {
            System.out.println("Pod tym numerem nie ma żadnego przedmiotu");
        }
        return przedmiot;
    }
    
    static int liczWygrana(int przedmiotGracza, int przedmiotKomputera)  {    
        if ( (przedmiotGracza==0 && przedmiotKomputera==2) || 
        (przedmiotGracza==1 && przedmiotKomputera==0) || 
        (przedmiotGracza==2 && przedmiotKomputera==1) ) { 
        return 1; 
        } else { 
        return -1; 
        }
}
        
        static void wypiszWynik(int punkty) { 
        if (punkty == 0) { 
        System.out.println("Remis"); 
        } else if (punkty > 0 ) { 
        System.out.println("Gracz wygrywa o " + punkty + " zwycięstwa(ą)"); 
        } else { 
        System.out.println("Gracz przegrywa o " + (-punkty) + " wygrane(ą)"); 
        } 
} 
            public static void main(String[] args) { 
        int punkty = 0; 
        int przedmiotGracza = pytanieOPrzedmiot(); 
        System.out.println("Gracz wybrał:" + podajNazwe(przedmiotGracza)); 
        int przedmiotKomputera = losujPrzedmiot(); 
        System.out.println("Wybralem:" + podajNazwe(przedmiotKomputera)); 
        punkty += liczWygrana(przedmiotGracza, przedmiotKomputera); 
        wypiszWynik(punkty); 
    } 
}
 
    
    


