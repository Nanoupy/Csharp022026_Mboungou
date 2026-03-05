using System;
using System.Collections.Generic;

class Esercizio2 // filtro e ricerca liste 
{
    static void Main()
    {
        // a. Genera una lista di 10 numeri casuali tra 1 e 100
        List<int> listaCasuale = new List<int>();
        Random generatore = new Random();

        for (int i = 0; i < 10; i++)
        {
            listaCasuale.Add(generatore.Next(1, 101));
        }

        // b. Stampa la lista
        Console.WriteLine("Lista casuale generata:");
        foreach (int n in listaCasuale) Console.Write(n + " ");

        // c. Chiede all’utente un numero da cercare
        Console.Write("\n\nChe numero vuoi cercare? ");
        int numeroCercato = int.Parse(Console.ReadLine());

        // d. Controlla posizione (indice)
        int posizione = listaCasuale.IndexOf(numeroCercato);
        if (posizione != -1)
        {
            Console.WriteLine("Numero trovato alla posizione (indice): " + posizione);
        }
        else
        {
            Console.WriteLine("Messaggio: Numero non trovato.");
        }

        // e. Restituisce tutti i numeri pari
        List<int> listaPari = new List<int>();
        foreach (int n in listaCasuale)
        {
            if (n % 2 == 0) 
            {
                listaPari.Add(n);
            }
        }

        Console.WriteLine("Numeri pari trovati: " + listaPari.Count);
        foreach (int p in listaPari) Console.Write(p + " ");
    }
}