using System;

class Program 
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- ESERCIZIO 3: Calcolatrice Semplificata ---");

        // i. Input multipli da tastiera
        Console.Write("Inserisci il primo numero: ");
        // ii. Casting/Conversione esplicita da string a double
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Inserisci il secondo numero: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.Write("Inserisci l'operatore (+ oppure -): ");
        string operatore = Console.ReadLine();

        // Variabile per memorizzare il risultato
        double risultato = 0;

        // iii. Uso combinato di operatori e stringhe
        if (operatore == "+")
        {
            risultato = num1 + num2;
            Console.WriteLine($"Risultato: {num1} + {num2} = {risultato}");
        }
        
        if (operatore == "-")
        {
            risultato = num1 - num2;
            Console.WriteLine($"Risultato: {num1} - {num2} = {risultato}");
        }

        // Controllo validità operatore
        if (operatore != "+" && operatore != "-")
        {
            Console.WriteLine("Operatore non valido!");
        }

        Console.WriteLine("\nEsecuzione terminata.");
    }
}