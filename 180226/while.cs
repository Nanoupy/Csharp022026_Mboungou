using System;

class Program 
{
    static void Main(string[] args)
    { // 3. SIMULATORE BANCOMAT
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
}
    }