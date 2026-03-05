using System;

class Program 
{
    static void Main(string[] args)
    {
        // ============================================================
        // EXTRA 1: ACCESSO ACCOUNT (Operatore AND - &&)
        // Entrambe le condizioni devono essere vere
        // ============================================================
        Console.WriteLine("--- EXTRA 1: Login ---");
        string usernameCorretto = "admin";
        string passwordCorretta = "12345";

        Console.Write("Inserisci Username: ");
        string user = Console.ReadLine();
        Console.Write("Inserisci Password: ");
        string pass = Console.ReadLine();

        if (user == usernameCorretto && pass == passwordCorretta)
        {
            Console.WriteLine("Accesso eseguito con successo!");
        }
        if (user != usernameCorretto || pass != passwordCorretta)
        {
            Console.WriteLine("Errore: Credenziali errate.");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // ============================================================
        // EXTRA 2: SCONTO STUDENTI O ANZIANI (Operatore OR - ||)
        // Almeno una delle condizioni deve essere vera
        // ============================================================
        Console.WriteLine("--- EXTRA 2: Sconto Agevolato ---");
        Console.Write("Inserisci la tua età: ");
        int eta = int.Parse(Console.ReadLine());

        Console.Write("Sei uno studente? (true/false): ");
        bool esStudente = bool.Parse(Console.ReadLine());

        // Sconto se hai meno di 20 anni OPPURE se sei uno studente
        if (eta < 20 || esStudente == true)
        {
            Console.WriteLine("Hai diritto allo sconto giovani/studenti!");
        }
        if (eta >= 20 && esStudente == false)
        {
            Console.WriteLine("Tariffa intera.");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // ============================================================
        // EXTRA 3: SISTEMA DI ALLERTA (Operatore NOT - !)
        // Inverte il valore di una condizione
        // ============================================================
        Console.WriteLine("--- EXTRA 3: Sensore Sicurezza ---");
        bool portaAperta = false; 

        // Se NON è vero che la porta è aperta (quindi è chiusa)
        if (!portaAperta)
        {
            Console.WriteLine("Stato: Sistema sicuro (Porta chiusa).");
        }
        
        // Esempio combinato complesso:
        bool allarmeAttivo = true;
        if (allarmeAttivo && !portaAperta)
        {
            Console.WriteLine("Sensore: Allarme armato e perimetro sigillato.");
        }

        Console.WriteLine("\nFine esercizi extra.");
    }
}