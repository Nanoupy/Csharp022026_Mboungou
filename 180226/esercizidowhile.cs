using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- ESERCIZIO 1: PASSWORD (MAX 3 TENTATIVI) ---");
        EsercizioPassword();

        Console.WriteLine("\n--- ESERCIZIO 2: SOMMA FINO ALLO ZERO ---");
        EsercizioSomma();

        Console.WriteLine("\n--- ESERCIZIO 3: CALCOLATRICE CONTINUA ---");
        EsercizioCalcolatrice();

        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }

    // 1. Password con massimo 3 tentativi
    static void EsercizioPassword()
    {
        int tentativi = 0;
        const int passwordCorretta = 1234;
        int inputUtente;
        bool corretta = false;

        do
        {
            Console.Write($"Inserisci password ({3 - tentativi} tentativi rimasti): ");
            inputUtente = int.Parse(Console.ReadLine());
            tentativi++;

            if (inputUtente == passwordCorretta)
            {
                corretta = true;
                Console.WriteLine("Accesso eseguito!");
            }
        } while (!corretta && tentativi < 3);

        if (!corretta) Console.WriteLine("Tentativi esauriti.");
    }

    // 2. Somma e conteggio numeri fino allo zero
    static void EsercizioSomma()
    {
        int numero;
        int somma = 0;
        int conteggio = 0;
        do
        {
            Console.Write("Inserisci un numero intero (0 per sommare): ");
            numero = int.Parse(Console.ReadLine());

            if (numero != 0)
            {
                somma += numero;
                conteggio++;
            }
        } while (numero != 0);
        Console.WriteLine($"Risultato: Hai inserito {conteggio} numeri. Somma totale: {somma}");
    }

    // 3. Calcolatrice con scelta di uscita
    static void EsercizioCalcolatrice()
    {
        string risposta;
        do
        {
            Console.Write("Primo numero: ");
            double n1 = double.Parse(Console.ReadLine());
            Console.Write("Operazione (+, -, *, /): ");
            char op = char.Parse(Console.ReadLine());
            Console.Write("Secondo numero: ");
            double n2 = double.Parse(Console.ReadLine());
            double risultato = op switch
            {
                '+' => n1 + n2,
                '-' => n1 - n2,
                '*' => n1 * n2,
                '/' => n2 != 0 ? n1 / n2 : 0,
                _ => 0
            };
            Console.WriteLine($"Risultato: {risultato}");
            Console.Write("Vuoi continuare? (s/n): ");
            risposta = Console.ReadLine().ToLower();
        } while (risposta == "s");
    }
}