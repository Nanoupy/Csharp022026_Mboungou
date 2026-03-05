using System;

class Program
{
    static void Main()
    {
        int[] numeri = { 30, 50, 80, 100, 120 };

        Console.WriteLine("Elementi dell'array di numeri:");
        foreach (int numero in numeri)
        {
            Console.WriteLine("Valore: " + numero);
        }
        int sommaTotal = 0;
        foreach (int n in numeri)
        {
            sommaTotal += n;
        }
        Console.WriteLine("\nLa somma totale degli elementi è: " + sommaTotal);
    }
}