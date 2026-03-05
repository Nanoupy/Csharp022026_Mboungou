using System;

class Program 
{
    static void Main(string[] args)
    {  
        int contatore = 0;
        int somma = 10;
        var nome = "Ada";
        int numero = 10; 
        
        // CORREZIONE 1: Mancava il suffisso 'f' per il float
        float decimaleDouble = 3.14f; 
        double decimaledouble = 3.14d;
        
        char lettera = 'A';
        bool condizione = true;
        string saluto = "Ciao a tutti!";
        
        // CORREZIONE 2: const float richiede il suffisso 'f' alla fine
        const float PI_NUMBER = 3.1159265359f; 
        
        nome = "Giulio";
        int intero = 42; 
        float numeroLungo = intero; // Widening (automatico)
        
        // CORREZIONE 1 (ancora): Aggiunto 'f'
        float pi = 3.14f; 
        int cicaPi = (int)pi; // Narrowing (esplicito)
        
        int a = 10;
        int b = 15;
        
        Console.WriteLine("Numero: " + numero);
        
        // CORREZIONE 3: La variabile si chiama 'decimaleDouble', non 'decimale'
        Console.WriteLine("Decimale: " + decimaleDouble); 
        
        Console.WriteLine("Lettera: " + lettera);
        Console.WriteLine("Condizione: " + condizione);
        Console.WriteLine("Saluto: " + saluto);
        
        // CORREZIONE 4: C# è case-sensitive. 'nome' (variabile locale) vs 'Nome' (campo della classe)
        Console.WriteLine("Ciao mi chiamo " + nome); 
        
        Console.WriteLine("Operatori aritmetici:");
        Console.WriteLine($"a={a}, b = {b}");
        Console.WriteLine($"Addizione: a + b = {a + b}");
        Console.WriteLine($"Sottrazione: a - b = {a - b}");
        Console.WriteLine($"Moltiplicazione: a * b = {a * b}");
        
        // NOTA: Qui la divisione darà 0 perché sono entrambi 'int' e 10/15 fa 0 con resto 10
        Console.WriteLine($"Divisione: a / b = {a / b}");
        Console.WriteLine($"Modulo (resto): a % b = {a % b}");
        
        Console.WriteLine("Operatori Assegnamento:");
        Console.WriteLine($"Incremento postfisso: a++ = {a++}"); // Stampa 10, poi diventa 11
        Console.WriteLine($"Ora a = {a}");
        Console.WriteLine($"Decremento prefisso: --b = {--b}"); // Diventa 14, poi stampa 14
        Console.WriteLine($"Ora b = {b}");
        
        Console.WriteLine("Operatori Logici:");
        Console.WriteLine($"AND: {a < b && a >= 10}"); 
        Console.WriteLine($"OR: {a > b || a >= 10}");
        Console.WriteLine($"NOT: {!(a < b)}");
        
        Console.WriteLine("Hello, world!");
        Console.WriteLine("Contatore: " + contatore);
    }

    // Nota: questo campo appartiene alla classe, non al Main. 
    // Per usarlo nel Main dovrebbe essere 'static'.
    public readonly string NomeInterno = "Franco";
}