using System;
//con menu 
// interfaccia
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}
//classi
public class Auto : IVeicolo
{
    public void Avvia() => Console.WriteLine("Avvio dell'auto... Brum brum!");
    public void MostraTipo() => Console.WriteLine("Tipo: Auto");
}
public class Moto : IVeicolo
{
    public void Avvia() => Console.WriteLine("Avvio della moto... Vroom!");
    public void MostraTipo() => Console.WriteLine("Tipo: Moto");
}
public class Camion : IVeicolo
{
    public void Avvia() => Console.WriteLine("Avvio del camion... Rumore pesante!");
    public void MostraTipo() => Console.WriteLine("Tipo: Camion");
}

// la fabbrica
public class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string scelta)
    {
        // Usiamo uno switch per gestire i numeri del menu
        switch (scelta)
        {
            case "1": return new Auto();
            case "2": return new Moto();
            case "3": return new Camion();
            default:
                Console.WriteLine("Scelta non valida nella Factory.");
                return null;
        }
    }
}
class Program
{
    static void Main()
    {
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\n--- Menu Fabbrica veicoli ---");
            Console.WriteLine("1. Crea Auto");
            Console.WriteLine("2. Crea Moto");
            Console.WriteLine("3. Crea Camion");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'opzione: ");
            string sceltaUtente = Console.ReadLine();
            if (sceltaUtente == "0")
            {
                continua = false;
                Console.WriteLine("Uscita in corso...");
            }
            else
            {
                // Chiamiamo la Factory passando il numero scelto
                IVeicolo veicoloCreato = VeicoloFactory.CreaVeicolo(sceltaUtente);
                // Se il veicolo esiste (non è null), lo usiamo
                if (veicoloCreato != null)
                {
                    Console.WriteLine("\n--- Risultato ---");
                    veicoloCreato.MostraTipo();
                    veicoloCreato.Avvia();
                }
            }
        }
    }
}