using System;

// interfaccia
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}
// classi
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
    public void Avvia() => Console.WriteLine("Avvio del camion... Braaaaaaaaaaaaahhhhhhh!");
    public void MostraTipo() => Console.WriteLine("Tipo: Camion");
}
// la fabbrica
public class VeicoloFactory
{
        public static IVeicolo CreaVeicolo(string tipo)
    {
      tipo = tipo.ToLower();
        if (tipo == "auto")
        {
            return new Auto();
        }
        else if (tipo == "moto")
        {
            return new Moto();
        }
        else if (tipo == "camion")
        {
            return new Camion();
        }
        else
        {
            Console.WriteLine("Errore: Veicolo '" + tipo + "' non riconosciuto.");
            return null;
        }
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("--- Benvenuto nella fabbrica di veicoli ---");
        Console.Write("Quale veicolo vuoi creare? (auto, moto, camion): ");
        string scelta = Console.ReadLine();
        // ricerca veicolo
        IVeicolo mioVeicolo = VeicoloFactory.CreaVeicolo(scelta);
        // se ci ha restituito un oggetto valido o non null
        if (mioVeicolo != null)
        {
            Console.WriteLine("\nVeicolo creato con successo!");
            mioVeicolo.Avvia();
            mioVeicolo.MostraTipo();
        }
        else
        {
            Console.WriteLine("Impossibile procedere: tipo di veicolo errato.");
        }
    }
}