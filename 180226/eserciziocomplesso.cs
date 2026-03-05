using System;

class Program
{
    static void Main(string[] args)
    {
        // Variabili per la registrazione/sato del sistema
        string nomeRegistrato = "";
        string passwordRegistrata = "";
        bool accountCreato = false;
        bool loggato = false;
        int scelta = 0;
        // Ciclo principale per fare ripetere il programma
        while (scelta != 4)
        {
            Console.WriteLine("\n--- SISTEMA DI SICUREZZA ---");
            Console.WriteLine("1: Registra Account");
            Console.WriteLine("2: Login Accesso");
            Console.WriteLine("3: Attiva Conto alla Rovescia (Solo se Loggato)");
            Console.WriteLine("4: Esci");
            Console.Write("Scegli un'opzione: ");
            
            scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    // REGISTRAZIONE
                    Console.Write("Inserisci un nuovo nome utente: ");
                    nomeRegistrato = Console.ReadLine();
                    Console.Write("Inserisci una nuova password: ");
                    passwordRegistrata = Console.ReadLine();
                    accountCreato = true;
                    Console.WriteLine("Account registrato con successo!");
                    break;

                case 2:
                    // LOGIN
                    if (!accountCreato)
                    {
                        Console.WriteLine("Errore: Devi prima registrare un account!");
                    }
                    else
                    {
                        Console.Write("Nome utente: ");
                        string userInput = Console.ReadLine();
                        Console.Write("Password: ");
                        string passInput = Console.ReadLine();

                        if (userInput == nomeRegistrato && passInput == passwordRegistrata)
                        {
                            loggato = true;
                            Console.WriteLine($"Benvenuto {nomeRegistrato}! Accesso effettuato.");
                        }
                        else
                        {
                            Console.WriteLine("Credenziali errate!");
                        }
                    }
                    break;

                case 3:
                    // CONTO ALLA ROVESCIA (Protetto da Login)
                    if (loggato)
                    {
                        Console.Write("Da che numero vuoi far partire il conto alla rovescia? ");
                        int partenza = int.Parse(Console.ReadLine());

                        Console.WriteLine("Avvio sequenza...");
                        // Ciclo FOR per il conto alla rovescia
                        for (int i = partenza; i >= 0; i--)
                        {
                            Console.WriteLine(i + "...");
                            // Un piccolo trucco per aspettare 1 secondo tra i numeri
                            System.Threading.Thread.Sleep(1000); 
                        }
                        Console.WriteLine("BOOM! Conto terminato.");
                    }
                    else
                    {
                        Console.WriteLine("ACCESSO NEGATO: Effettua prima il login!");
                    }
                    break;

                case 4:
                    Console.WriteLine("Chiusura sistema...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}