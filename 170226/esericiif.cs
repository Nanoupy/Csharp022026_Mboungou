using System;

class Program 
{
    static void Main(string[] args)
    {
        // 1. CONTROLLO ETÀ (MAGGIORENNE O MINORENNE)
    
        Console.WriteLine("--- ESERCIZIO 1: Età ---");
        const int MAGGIORE_ETA = 18; // Uso di una costante
        
        Console.Write("Inserisci la tua età: ");
        int etaUtente = int.Parse(Console.ReadLine()); // Conversione esplicita da string a int

        if (etaUtente >= MAGGIORE_ETA)
        {
            Console.WriteLine($"Con {etaUtente} anni sei: Maggiorenne.");
        }
        if (etaUtente < MAGGIORE_ETA)
        {
            Console.WriteLine($"Con {etaUtente} anni sei: Minorenne.");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 2. CALCOLO PREZZO SCONTATO (Sconto 10% se > 100€)
        Console.WriteLine("--- ESERCIZIO 2: Sconto ---");
        Console.Write("Inserisci il prezzo del prodotto: ");
        double prezzoOriginale = double.Parse(Console.ReadLine());
        
        double prezzoFinale = prezzoOriginale; // Assegnazione iniziale

        if (prezzoOriginale > 100)
        {
            // Operatore aritmetico per calcolare lo sconto
            double sconto = prezzoOriginale * 0.10;
            prezzoFinale = prezzoOriginale - sconto;
            Console.WriteLine("Sconto del 10% applicato!");
        }

        // Stampa con formattazione della stringa
        Console.WriteLine($"Prezzo finale da pagare: {prezzoFinale}€");

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 3. MEDIA ARITMETICA E PROVA
        Console.WriteLine("--- ESERCIZIO 3: Media Voti ---");
        Console.WriteLine("Inserisci tre numeri interi:");
        
        Console.Write("Numero 1: ");
        int n1 = int.Parse(Console.ReadLine());
        
        Console.Write("Numero 2: ");
        int n2 = int.Parse(Console.ReadLine());
        
        Console.Write("Numero 3: ");
        int n3 = int.Parse(Console.ReadLine());

        // Casting esplicito (double) per non perdere i decimali nella divisione
        double media = (double)(n1 + n2 + n3) / 3;

        Console.WriteLine($"Valore esatto della media: {media:F2}"); // F2 formatta a 2 decimali

        if (media >= 60)
        {
            Console.WriteLine("Esito: Hai superato la prova!");
        }
        if (media < 60)
        {
            Console.WriteLine("Esito: Prova fallita.");
        }

        Console.WriteLine("\nFine degli esercizi.");
    }
}