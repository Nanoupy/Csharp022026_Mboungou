// conteggio frequenza parole 
using System;
using System.Collections.Generic;

class ContaParole
{
    static void Main()
    {
        Console.WriteLine("Inserisci una frase:");
        string frase = Console.ReadLine().ToLower();
        string[] parole = frase.Split(' ');
        Dictionary<string, int> frequenza = new Dictionary<string, int>();
        foreach (string p in parole)
        {
            if (frequenza.ContainsKey(p))
            {
                frequenza[p]++; 
            }
            else
            {
                frequenza[p] = 1;
            }
        }
        Console.WriteLine("\nConteggio parole:");
        foreach (var coppia in frequenza)
        {
            Console.WriteLine($"{coppia.Key}: {coppia.Value} volte");
        }
    }
}