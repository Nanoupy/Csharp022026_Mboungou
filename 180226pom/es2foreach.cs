using System;

class Program
{
    static void Main(string[] args)
    { //Rimuovere gli spazi
        Console.Write("Inserisci una frase con spazi: ");
        string input = Console.ReadLine();
        string senzaSpazi = "";

        foreach (char c in input)
        {
            if (c != ' ')
            {
                senzaSpazi += c; 
            }
        }

        Console.WriteLine("Frase senza spazi: " + senzaSpazi);
        
    }
} 