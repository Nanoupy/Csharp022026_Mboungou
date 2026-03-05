using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. TABELLINA DA 1 A 10
        Console.WriteLine("--- 1. TABELLINA ---");
        Console.Write("Inserisci un numero: ");
        int numTabellina = int.Parse(Console.ReadLine());
        // Partiamo da i = 1 fino a i <= 10
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine($"{numTabellina} x {i} = {numTabellina * i}");
        }
        Console.WriteLine("\n------------------------------\n");

        // 2. CALCOLO MEDIA
        Console.WriteLine("--- 2. MEDIA NUMERI ---");
        Console.Write("Quanti numeri vuoi inserire? ");
        int quantita = int.Parse(Console.ReadLine());
        double somma = 0;
        for (int i = 0; i < quantita; i++)
        {
            Console.Write($"Inserisci il numero {i + 1}: ");
            somma += double.Parse(Console.ReadLine());
        }
        double media = somma / quantita;
        Console.WriteLine($"La media è: {media:F2}");
        Console.WriteLine("\n------------------------------\n");

        // 3. FATTORIALE (n!)
        Console.WriteLine("--- 3. FATTORIALE ---");
        Console.Write("Inserisci un numero intero positivo: ");
        int n = int.Parse(Console.ReadLine());
        if (n < 0)
        {
            Console.WriteLine("Errore: Il numero deve essere positivo!");
        }
        else
        {
            long fattoriale = 1;
            // Calcoliamo il fattoriale moltiplicando i numeri da 1 a n
            for (int i = 1; i <= n; i++)
            {
                fattoriale *= i;
            }
            Console.WriteLine($"Il fattoriale di {n} è: {fattoriale}");
        }
    }
}