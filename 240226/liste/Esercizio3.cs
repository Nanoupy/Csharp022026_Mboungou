using System;
using System.Collections.Generic;

class Esercizio3 // ordinamento e valori unici 
{
    static void Main()
    {
        // a. Crea una lista con almeno 15 numeri casuali tra 1 e 20
        List<int> listaNumeri = new List<int>();
        Random rnd = new Random();

        for (int i = 0; i < 15; i++)
        {
            listaNumeri.Add(rnd.Next(1, 21));
        }

        // b. Stampa la lista originale
        Console.WriteLine("Lista originale con duplicati:");
        foreach (int n in listaNumeri) Console.Write(n + " ");

        // c. Rimuove i duplicati mantenendo solo i valori unici
        List<int> listaUnica = new List<int>();
        foreach (int n in listaNumeri)
        {
            if (listaUnica.Contains(n) == false) // Se non c'è già
            {
                listaUnica.Add(n); //lo aggiungo
            }
        }
        // d. Ordina la lista in ordine crescente
        listaUnica.Sort();

        // e. Stampa la lista finale
        Console.WriteLine("\n\nLista finale (unici e ordinati):");
        foreach (int n in listaUnica) Console.Write(n + " ");
    }
}