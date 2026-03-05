using System;

class Program
{ //Conteggio Cifre (0-9)
    static void Main(string[] args)
    {
        Console.Write("Inserisci una frase: ");
string frase = Console.ReadLine();
int contatoreCifre = 0;

foreach (char c in frase)
{
    if (char.IsDigit(c))
    {
        contatoreCifre++;
    }
}
Console.WriteLine($"Nella frase sono presenti {contatoreCifre} cifre.");
    }
    }