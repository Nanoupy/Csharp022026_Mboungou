using System;

class Program 
{
    static void Main(string[] args)
    {
        // 1. NUMERO PARI O DISPARI
        Console.WriteLine("--- ESERCIZIO 1: Pari o Dispari ---");
        
        Console.Write("Inserisci un numero intero: ");
        // Conversione esplicita da string (input) a int
        int numeroInput = int.Parse(Console.ReadLine());

        /* L'operatore modulo (%) restituisce il resto della divisione.
           Se un numero diviso 2 dà resto 0, allora è PARI.
        */
        if (numeroInput % 2 == 0)
        {
            Console.WriteLine($"Il numero {numeroInput} è Pari.");
        }
        
        if (numeroInput % 2 != 0)
        {
            Console.WriteLine($"Il numero {numeroInput} è Dispari.");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 2. CONTROLLO PASSWORD NUMERICA
        Console.WriteLine("--- ESERCIZIO 2: Accesso Password ---");
        
        // Uso di una costante predefinita
        const int PASSWORD_CORRETTA = 1234;

        Console.Write("Inserisci la password numerica: ");
        // Casting/Conversione esplicita dell'input utente
        int passwordInserita = int.Parse(Console.ReadLine());

        if (passwordInserita == PASSWORD_CORRETTA)
        {
            Console.WriteLine("Accesso consentito");
        }
        
        if (passwordInserita != PASSWORD_CORRETTA)
        {
            Console.WriteLine("Accesso negato");
        }

        Console.WriteLine("\nFine degli esercizi.");
    }
}