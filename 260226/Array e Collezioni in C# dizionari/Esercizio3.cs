// gestione magazzino con menu 
using System;
using System.Collections.Generic;

class Magazzino
{
    static void Main()
    {
        Dictionary<string, int> inventario = new Dictionary<string, int>();
        string scelta = "";

        while (scelta != "5")
        {
            Console.WriteLine("\n--- MENU MAGAZZINO ---");
            Console.WriteLine("1. Aggiungi/Aggiorna Prodotto");
            Console.WriteLine("2. Rimuovi Prodotto");
            Console.WriteLine("3. Cerca Prodotto");
            Console.WriteLine("4. Stampa Inventario");
            Console.WriteLine("5. Esci");
            Console.Write("Scelta: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Nome prodotto: ");
                    string nome = Console.ReadLine();
                    Console.Write("Quantità da aggiungere: ");
                    int qta = int.Parse(Console.ReadLine());
                    if (inventario.ContainsKey(nome))
                        inventario[nome] += qta;
                    else
                        inventario[nome] = qta;
                    break;

                case "2":
                    Console.Write("Nome prodotto da rimuovere: ");
                    string daRimuovere = Console.ReadLine();
                    if (inventario.Remove(daRimuovere))
                        Console.WriteLine("Prodotto rimosso.");
                    else
                        Console.WriteLine("Prodotto non trovato.");
                    break;

                case "3":
                    Console.Write("Cerca prodotto: ");
                    string cerca = Console.ReadLine();
                    if (inventario.ContainsKey(cerca))
                        Console.WriteLine($"Disponibilità: {inventario[cerca]} pezzi.");
                    else
                        Console.WriteLine("Non in magazzino.");
                    break;

                case "4":
                    Console.WriteLine("\nINVENTARIO COMPLETO:");
                    foreach (var p in inventario)
                        Console.WriteLine($"{p.Key}: {p.Value} pezzi");
                    break;
            }
        }
    }
} 