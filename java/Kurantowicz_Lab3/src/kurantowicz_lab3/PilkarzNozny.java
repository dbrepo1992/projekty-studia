/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package kurantowicz_lab3;

/**
 *
 * @author barte
 */
public class PilkarzNozny extends Pilkarz {

    public PilkarzNozny(String imie, String nazwisko, String dataUr, String pozycja, String klub) {
        super(imie, nazwisko, dataUr, pozycja, klub);
    }

    @Override
    public void strzelGola() {
        super.strzelGola(); // Wywołanie metody z klasy bazowej
        System.out.println("Nożny strzelił!"); // Dodatkowy komunikat
    }
}

