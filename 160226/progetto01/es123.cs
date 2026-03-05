using System;

class Program 
{
    static void Main(string[] args)
    {
         int contatore = 0;
        int somma = 10;
        var nome = "Ada";
        int numero = 10; 
        
        // esercizio 1: Mancava il suffisso 'f' per il float
        float decimaleDouble = 3.14f; 
        double decimaledouble = 3.14d;
        
        char lettera = 'A';
        bool condizione = true;
        string saluto = "Ciao a tutti!";
        
        // esercizio 2
        const float PI_NUMBER = 3.1159265359f; 
        
        nome = "Giulio";
        int intero = 42; 
        float numeroLungo = intero; // Widening 
        // Aggiunto 'f'
        float pi = 3.14f; 
        int cicaPi = (int)pi; // Narrowing
        int a = 10;
        int b = 15;
        Console.WriteLine("Numero: " + numero);

        // esercizio 3
        Console.WriteLine("Decimale: " + decimaleDouble); 
        Console.WriteLine("Lettera: " + lettera);
        Console.WriteLine("Condizione: " + condizione);
        Console.WriteLine("Saluto: " + saluto);
    }
}