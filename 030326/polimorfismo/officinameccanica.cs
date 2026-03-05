using System;
using System.Collections.Generic;
// 1. classe base
public class Veicolo
{
    public string Targa { get; set; }

    public Veicolo(string targa)
    {
        Targa = targa;
    }
    // metodo virtuale: definisce il comportamento generico
    public virtual void Ripara()
    {
        Console.WriteLine($"[{Targa}] Il veicolo viene controllato.");
    }
}
// 2. classi derivati 
public class Auto : Veicolo
{
    public Auto(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"[{Targa}] Riparazione AUTO: Controllo olio, freni e motore.");
    }
}
public class Moto : Veicolo
{
    public Moto(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"[{Targa}] Riparazione MOTO: Controllo catena, freni e gomme.");
    }
}
public class Camion : Veicolo
{
    public Camion(string targa) : base(targa) { }

    public override void Ripara()
    {
        Console.WriteLine($"[{Targa}] Riparazione CAMION: Controllo sospensioni, freni rinforzati e carico.");
    }
}
// 3. main
class Program
{
    static void Main()
    {
        // creo la lista di tipo Veicolo (può contenere tutti i figli)
        List<Veicolo> officina = new List<Veicolo>();

        // inserisco diversi tipi di veicoli
        officina.Add(new Auto("AA123BB"));
        officina.Add(new Moto("CC456DD"));
        officina.Add(new Camion("EE789FF"));

        Console.WriteLine("--- BENVENUTI NELL'OFFICINA C# ---");
        Console.WriteLine("Inizio riparazioni giornaliere:\n");

        // ciclo polimorfico
        foreach (Veicolo v in officina)
        {
            v.Ripara();
        }
        Console.WriteLine("\nLavoro terminato. Premi un tasto per uscire.");
        Console.ReadKey();
    }
}