using System;
using System.Collections.Generic; // Necessario per usare List

class Esercizio1 //Gestione Base delle liste 
{
    static void Main()
    {
        // a. Crea una lista di interi vuota
        List<int> numeri = new List<int>();

        // b. Chiede all’utente di inserire 5 numeri interi
        // c. Aggiunge i numeri nella lista
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Inserisci un numero intero: ");
            int input = int.Parse(Console.ReadLine());
            numeri.Add(input); // Aggiunge alla lista
        }

        // d. Chiede e rimuove un numero dalla lista
        Console.Write("\nQuale numero vuoi rimuovere? ");
        int numeroDaRimuovere = int.Parse(Console.ReadLine());
        
        if (numeri.Contains(numeroDaRimuovere))
        {
            numeri.Remove(numeroDaRimuovere); 
            Console.WriteLine("Numero rimosso!");
        }
        else
        {
            Console.WriteLine("Numero non trovato.");
        }

        // e. Stampa tutti i numeri presenti in lista
        Console.WriteLine("\nNumeri attualmente in lista:");
        foreach (int n in numeri)
        {
            Console.WriteLine(n);
        }
    }
}