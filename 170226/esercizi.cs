using System;

class Program 
{
    static void Main(string[] args)
    {
        // --- ESERCIZIO 1: Somma di Due Numeri ---
        int num1 = 10;
        int num2 = 20;
        int sommaSemplice = num1 + num2;
        Console.WriteLine("1. Somma di due numeri: " + sommaSemplice);

        // --- ESERCIZIO 2: Calcolo di un Prezzo Scontato ---
        double prezzoOriginale = 50.0d;
        double sconto = 0.20d; // 20%
        double prezzoFinale = prezzoOriginale * (1 - sconto);
        Console.WriteLine("2. Prezzo scontato: " + prezzoFinale);

        // --- ESERCIZIO 3: Controllo di un Numero Positivo ---
        float numeroFloat = -15.5f;
        bool esPositivo = numeroFloat > 0;
        Console.WriteLine("3. Il numero è positivo? " + esPositivo);

        // --- ESERCIZIO 4: Somma tra Intero e Float (con Input) ---
        Console.WriteLine("4. Inserisci un intero:");
        int interoUtente = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Inserisci un float (es. 3,14):");
        float floatUtente = float.Parse(Console.ReadLine());
        
        // Widening: l'intero viene promosso a float automaticamente
        float sommaMista = interoUtente + floatUtente;
        Console.WriteLine("Risultato somma: " + sommaMista);

        // --- ESERCIZIO 5: Età e Altezza con Casting ---
        Console.WriteLine("5. Inserisci la tua età:");
        int eta = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Inserisci la tua altezza (es. 1,75):");
        float altezza = float.Parse(Console.ReadLine());
        
        // Narrowing: forziamo il float in un int (perdiamo i decimali)
        int altezzaTroncata = (int)altezza;
        int sommaFinale = eta + altezzaTroncata;
        
        Console.WriteLine($"Età: {eta}, Altezza troncata: {altezzaTroncata}");
        Console.WriteLine("Somma finale (Casting): " + sommaFinale);
        
        Console.WriteLine("Esercizi completati!");
    }
}