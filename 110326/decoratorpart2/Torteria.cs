using System;
using System.Collections.Generic;

namespace TorteriaApp;
public interface ITorta
{
    string Descrizione();
}
// componenti concretti
public class TortaCioccolato : ITorta
{
    public string Descrizione() => "Torta al cioccolato";
}
public class TortaVaniglia : ITorta
{
    public string Descrizione() => "Torta alla vaniglia";
}
public class TortaFrutta : ITorta
{
    public string Descrizione() => "Torta alla frutta";
}
// decoratore astratto
public abstract class DecoratoreTorta : ITorta
{
    protected ITorta _tortaBase;

    protected DecoratoreTorta(ITorta torta)
    {
        _tortaBase = torta;
    }

    public abstract string Descrizione();
}
// decoratori concrette 
public class ConPanna : DecoratoreTorta
{
    public ConPanna(ITorta torta) : base(torta) { }
    public override string Descrizione() => _tortaBase.Descrizione() + " + panna";
}
public class ConFragole : DecoratoreTorta
{
    public ConFragole(ITorta torta) : base(torta) { }
    public override string Descrizione() => _tortaBase.Descrizione() + " + fragole";
}
public class ConGlassa : DecoratoreTorta
{
    public ConGlassa(ITorta torta) : base(torta) { }
    public override string Descrizione() => _tortaBase.Descrizione() + " + glassa";
}
// torte di base 
public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        return tipo.ToLower() switch
        {
            "cioccolato" => new TortaCioccolato(),
            "vaniglia" => new TortaVaniglia(),
            "frutta" => new TortaFrutta(),
            _ => null
        };
    }
}
class Program
{
    static void Main()
    {
        Console.WriteLine("=== Bevenutti nella Torteria Nan's cakes ===");
        //1. Utilizziamo la Factory
        ITorta miaTorta = null;
        while (miaTorta == null)
        {
            Console.Write("\nScegli la base (cioccolato, vaniglia, frutta): ");
            string sceltaBase = Console.ReadLine();
            miaTorta = TortaFactory.CreaTortaBase(sceltaBase);
            
            if (miaTorta == null) 
                Console.WriteLine("Tipo di torta non valido, riprova.");
        }
    //2. Utilizziamo i decoratori
        bool aggiuntaInCorso = true;
        while (aggiuntaInCorso)
        {
            Console.WriteLine("\n--- Ingredienti Extra ---");
            Console.WriteLine("1. Aggiungi Panna");
            Console.WriteLine("2. Aggiungi Fragole");
            Console.WriteLine("3. Aggiungi Glassa");
            Console.WriteLine("0. Concludi ordine");
            Console.Write("Scelta: ");
            string sceltaExtra = Console.ReadLine();
            switch (sceltaExtra)
            {
                case "1":
                    miaTorta = new ConPanna(miaTorta);
                    Console.WriteLine("Panna aggiunta!");
                    break;
                case "2":
                    miaTorta = new ConFragole(miaTorta);
                    Console.WriteLine("Fragole aggiunte!");
                    break;
                case "3":
                    miaTorta = new ConGlassa(miaTorta);
                    Console.WriteLine("Glassa aggiunta!");
                    break;
                case "0":
                    aggiuntaInCorso = false;
                    break;
                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }
        }
        Console.WriteLine("\n========================================");
        Console.WriteLine("Ordine completato!!!!!!");
        Console.WriteLine($"Descrizione finale: {miaTorta.Descrizione()}");
        Console.WriteLine("========================================");
    }
}