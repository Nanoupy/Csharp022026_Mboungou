using System;

class Program
{
    static void Main()
    { //conteggio vocali con metodo
    
        Console.Write("Inserisci una parola o frase: ");
        string testo = Console.ReadLine();
        int numeroVocali = ContaVocali(testo);
        Console.WriteLine($"Il numero di vocali è: {numeroVocali}");
    }
    static int ContaVocali(string input)
    {
        int conteggio = 0;
        string vocali = "aeiou";
        foreach (char c in input)
        {
            // Convertiamo in minuscolo per non mancare le maiuscole
            char carattereMinuscolo = char.ToLower(c);
            if (vocali.Contains(carattereMinuscolo))
            {
                conteggio++;
            }
        }
        return conteggio;
    }
}