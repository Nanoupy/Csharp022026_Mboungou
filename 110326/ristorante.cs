using System;
using System.Collections.Generic;
//programma ordine ristorante usando i  5 pattern
namespace Ristorante;
//observer
public interface IObserver { void Aggiorna(string messaggio); }
public class Cameriere : IObserver 
{
    public void Aggiorna(string messaggio) => 
        Console.WriteLine($"[Cameriera]: Ricevuto! Porto subito '{messaggio}' al tavolo.");
}
//strategy
public interface IPreparazioneStrategia { string Prepara(string desc); }
public class AlForno : IPreparazioneStrategia 
{ 
    public string Prepara(string desc) => $"[Cottura al forno]: {desc} dorato."; 
}
public class Fritto : IPreparazioneStrategia 
{ 
    public string Prepara(string desc) => $"[Cottura fritto]: {desc} croccante."; 
}
//decorator
public interface IPiatto { string Descrizione(); }
public class Pizza : IPiatto { public string Descrizione() => "Pizza Diavola"; }
public class Hamburger : IPiatto { public string Descrizione() => "Hamburger di Pollo"; }
public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piatto;
    protected IngredienteExtra(IPiatto p) => _piatto = p;
    public abstract string Descrizione();
}
public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto p) : base(p) { }
    public override string Descrizione() => _piatto.Descrizione() + " + extra Formaggio";
}
//factory
public static class PiattoFactory
{
    public static IPiatto Crea(string tipo) => tipo.ToLower() switch
    {
        "pizza" => new Pizza(),
        "hamburger" => new Hamburger(),
        _ => null
    };
}
//singleton
public class Chef
{
    private static Chef _instance;
    private IPreparazioneStrategia _strategia;
    private List<IObserver> _osservatori = new List<IObserver>();
    private Chef() { }
    public static Chef Instance => _instance ??= new Chef();
    public void RegistraCameriere(IObserver o) => _osservatori.Add(o);
    public void ImpostaCottura(IPreparazioneStrategia s) => _strategia = s;
    public void PreparaPiatto(IPiatto piatto)
    {
        if (_strategia == null) return;
    
        string risultato = _strategia.Prepara(piatto.Descrizione());
        Console.WriteLine($"\n[Chef]: Ho finito di cucinare!");
        Console.WriteLine(risultato);
        foreach (var o in _osservatori) o.Aggiorna(piatto.Descrizione());
    }
}
class Program
{
    static void Main()
    {
        //Chef (Singleton) e cameriere (Observer)
        Chef loChef = Chef.Instance;
        loChef.RegistraCameriere(new Cameriere());
        Console.WriteLine("==== Nanou's ristorante ====");
        //Factory
        IPiatto mioPiatto = null;
        while (mioPiatto == null)
        {
            Console.Write("\nCosa ordini? (pizza / hamburger): ");
            mioPiatto = PiattoFactory.Crea(Console.ReadLine() ?? "");
        }
        //Decorator
        Console.WriteLine("Vuoi extra formaggio? (si/no)");
        if (Console.ReadLine()?.ToLower() == "s") mioPiatto = new ConFormaggio(mioPiatto);
        //Strategy
        Console.WriteLine("\nCottura: 1.Forno | 2.Fritto");
        if (Console.ReadLine() == "1") loChef.ImpostaCottura(new AlForno());
        else loChef.ImpostaCottura(new Fritto());
        loChef.PreparaPiatto(mioPiatto);
    }
}
