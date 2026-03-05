using System;

class Program 
{
    static void Main(string[] args)
    {
        // 1. SOMMA NUMERI POSITIVI
        Console.WriteLine("--- ESERCIZIO 1: Somma fino a numero negativo ---");
        int sommaTotale = 0;
        int numeroInserito = 0;
        // Il ciclo continua finché il numero è 0 o positivo
        while (numeroInserito >= 0)
        {
            Console.Write("Inserisci un numero (negativo per terminare): ");
            numeroInserito = int.Parse(Console.ReadLine());

            if (numeroInserito >= 0)
            {
                sommaTotale += numeroInserito; // Aggiunge alla somma
            }
        }
        Console.WriteLine($"La somma totale dei numeri positivi è: {sommaTotale}");
        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 2. INDOVINA IL NUMERO SEGRETO
        Console.WriteLine("--- ESERCIZIO 2: Indovina il numero segreto ---");
        const int NUMERO_SEGRETO = 42; // Costante predefinita
        int tentativo = 0;
        Console.WriteLine("Ho pensato un numero tra 1 e 100. Prova a indovinare!");
        while (tentativo != NUMERO_SEGRETO)
        {
            Console.Write("Inserisci il tuo tentativo: ");
            tentativo = int.Parse(Console.ReadLine());
            if (tentativo < NUMERO_SEGRETO)
            {
                Console.WriteLine("Troppo basso! Riprova.");
            }
            else if (tentativo > NUMERO_SEGRETO)
            {
                Console.WriteLine("Troppo alto! Riprova.");
            }
            else
            {
                Console.WriteLine("Complimenti! Hai indovinato.");
            }
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 3. SIMULATORE BANCOMAT
        Console.WriteLine("--- ESERCIZIO 3: Simulatore Bancomat ---");
        double saldo = 0;
        int sceltaMenu = 0;
        while (sceltaMenu != 4)
        {
            Console.WriteLine("\nMENU BANCOMAT:");
            Console.WriteLine("1: Visualizza saldo");
            Console.WriteLine("2: Deposita denaro");
            Console.WriteLine("3: Preleva denaro");
            Console.WriteLine("4: Esci");
            Console.Write("Scegli un'opzione: ");
            sceltaMenu = int.Parse(Console.ReadLine());
            switch (sceltaMenu)
            {
                case 1:
                    Console.WriteLine($"Il tuo saldo attuale è: {saldo:F2}€");
                    break;

                case 2:
                    Console.Write("Quanto vuoi depositare? ");
                    double deposito = double.Parse(Console.ReadLine());
                    if (deposito > 0)
                    {
                        saldo += deposito;
                        Console.WriteLine("Deposito effettuato.");
                    }
                    break;

                case 3:
                    Console.Write("Quanto vuoi prelevare? ");
                    double prelievo = double.Parse(Console.ReadLine());
                    if (prelievo > saldo)
                    {
                        Console.WriteLine("ERRORE: Saldo insufficiente!");
                    }
                    else if (prelievo > 0)
                    {
                        saldo -= prelievo;
                        Console.WriteLine("Prelievo effettuato.");
                    }
                    break;

                case 4:
                    Console.WriteLine("Grazie per aver usato il nostro Bancomat. Arrivederci!");
                    break;

                default:
                    Console.WriteLine("Opzione non valida!");
                    break;
            }
        }

        Console.WriteLine("\nProgramma terminato correttamente.");
    }
}