using System;

class Program
{//annalizzatore stringhe
    static void Main()
    {
        Console.WriteLine("Inserisci una frase da analizzare:");
        string frase = Console.ReadLine();
        AnalizzaTesto(frase);
    }
    static void AnalizzaTesto(string testo)
    {
        int lettere = 0, spazi = 0, punteggiatura = 0;
        // Conteggio caratteri tramite foreach
        foreach (char c in testo)
        {
            if (char.IsLetter(c)) lettere++;
            else if (char.IsWhiteSpace(c)) spazi++;
            else if (char.IsPunctuation(c)) punteggiatura++;
        }
        // Conteggio parole: Split divide la stringa ogni volta che trova uno spazio
        // StringSplitOptions.RemoveEmptyEntries serve se l'utente mette due spazi vicini
        string[] parole = testo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Console.WriteLine("\n--- RISULTATI ANALISI ---");
        Console.WriteLine($"Parole: {parole.Length}");
        Console.WriteLine($"Lettere: {lettere}");
        Console.WriteLine($"Spazi: {spazi}");
        Console.WriteLine($"Punteggiatura: {punteggiatura}");
    }
}