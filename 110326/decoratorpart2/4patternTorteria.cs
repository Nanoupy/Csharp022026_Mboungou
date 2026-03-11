using System;
using System.Collections.Generic;
namespace TorteriaApp;
// observer....interfacce
public interface IObserver { void Aggiorna(string descrizione); }
public interface ISoggetto
{
    void Registra(IObserver o);
    void Notifica(string descrizione);
}
// decorate
public interface ITorta { string Descrizione(); }

public class TortaCioccolato : ITorta { public string Descrizione() => "Torta al cioccolato"; }
public class TortaVaniglia : ITorta { public string Descrizione() => "Torta alla vaniglia"; }
public class TortaFrutta : ITorta { public string Descrizione() => "Torta alla frutta"; }
public abstract class DecoratoreTorta : ITorta
{
    protected ITorta _tortaBase;
    protected DecoratoreTorta(ITorta torta) => _tortaBase = torta;
    public abstract string Descrizione();
}
public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta t) : base(t) { }
    public override string Descrizione() => _tortaBase.Descrizione() + " + panna";
}
public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta t) : base(t) { }
    public override string Descrizione() => _tortaBase.Descrizione() + " + fragole";
}
// factory
public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo) => tipo.ToLower() switch
    {
        "cioccolato" => new TortaCioccolato(),
        "vaniglia" => new TortaVaniglia(),
        "frutta" => new TortaFrutta(),
        _ => null
    };
}
// Singelton e soggetto observer
public class GestoreOrdini : ISoggetto
{
    private static GestoreOrdini _instance;
    private List<IObserver> _observers = new List<IObserver>();
    private ITorta _tortaCorrente;
    private GestoreOrdini() { }
    public static GestoreOrdini Instance => _instance ??= new GestoreOrdini();
    public void Registra(IObserver o) => _observers.Add(o);
    public void Notifica(string desc) => _observers.ForEach(o => o.Aggiorna(desc));
    public void ImpostaTorta(ITorta t)
    {
        _tortaCorrente = t;
        Notifica(_tortaCorrente.Descrizione());
    }
    public void AggiungiDecorazione(Func<ITorta, ITorta> decoratore)
    {
        if (_tortaCorrente != null)
        {
            _tortaCorrente = decoratore(_tortaCorrente);
            Notifica(_tortaCorrente.Descrizione());
        }
    }
}
// observer concretti
public class DisplayCucina : IObserver 
{ 
    public void Aggiorna(string desc) => Console.WriteLine($"[CUCINA] In preparazione: {desc}"); 
}
public class DisplayCliente : IObserver 
{ 
    public void Aggiorna(string desc) => Console.WriteLine($"[CLIENTE] La tua torta ora è: {desc}"); 
}
class Program
{
    static void Main()
    {
        // Singleton e Observer
        var gestore = GestoreOrdini.Instance;
        gestore.Registra(new DisplayCucina());
        gestore.Registra(new DisplayCliente());
        Console.WriteLine("=== Benvenuti nella Torteria Nan's Cakes ===");
        // factory
        ITorta miaTorta = null;
        while (miaTorta == null)
        {
            Console.Write("\nScegli la base (cioccolato, vaniglia, frutta): ");
            miaTorta = TortaFactory.CreaTortaBase(Console.ReadLine());
            if (miaTorta == null) Console.WriteLine("Tipo non valido!");
        }
        gestore.ImpostaTorta(miaTorta);
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n--- Menu decorazioni ---");
            Console.WriteLine("1. Aggiungi Panna");
            Console.WriteLine("2. Aggiungi Fragole");
            Console.WriteLine("0. Concludi Ordine");
            Console.Write("Scelta: ");
            switch (Console.ReadLine())
            {
                case "1":
                    gestore.AggiungiDecorazione(t => new ConPanna(t));
                    break;
                case "2":
                    gestore.AggiungiDecorazione(t => new ConFragole(t));
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta errata!");
                    break;
            }
        }
        Console.WriteLine("\nOrdine inviato! Grazie per aver scelto Nan's Cakes.");
    }
}