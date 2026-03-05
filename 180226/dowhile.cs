using System;

class Program 
{
    static void Main(string[] args)
    {
        bool continua = true;
        
        do // Prima esegue il codice, poi controlla la condizione
        {
            Console.WriteLine("Ciclo in esecuzione");
            
            // Per testare il codice, chiediamo all'utente se vuole continuare
            Console.Write("Vuoi continuare? (true/false): ");
            continua = bool.Parse(Console.ReadLine());
        } 
        while (continua); // CORREZIONE: Rimosso '= true' e aggiunto ';' alla fine
    }
}