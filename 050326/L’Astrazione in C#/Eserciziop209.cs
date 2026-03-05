using System;
using System.Collections.Generic;

// classe astratta 
public abstract class DispositivoElettronico
{
    public string Modello { get; set; }

    protected DispositivoElettronico(string modello)
    {
        Modello = modello;
    }
// metodi
    public abstract void Accendi();
    public abstract void Spegni();
    public virtual void MostraInfo()
    {
        Console.WriteLine($"Dispositivo Modello: {Modello}");
    }
}
//classe concrete 
public class Computer : DispositivoElettronico
{
    public Computer(string modello) : base(modello) { }

//implementazione dei metodi 
    public override void Accendi() => Console.WriteLine("Il computer si avvia...");
    public override void Spegni() => Console.WriteLine("Il computer si spegne.");
}

public class Stampante : DispositivoElettronico
{
    public Stampante(string modello) : base(modello) { }

    public override void Accendi() => Console.WriteLine("La stampante si accende.");
    public override void Spegni() => Console.WriteLine("La stampante va in standby.");
}

class Program
{
    static void Main()
    {
        // lista polimorfica
        List<DispositivoElettronico> laboratorio = new List<DispositivoElettronico>();

        laboratorio.Add(new Computer("Dell XPS"));
        laboratorio.Add(new Stampante("HP LaserJet"));

        Console.WriteLine("--- TEST DISPOSITIVI LABORATORIO ---");

        // ciclo polimorfico
        foreach (DispositivoElettronico dispositivo in laboratorio)
        {
            // qui il programma chiama i metodi corretti in base al tipo reale dell'oggetto
            dispositivo.MostraInfo();
            dispositivo.Accendi();
            dispositivo.Spegni();
            Console.WriteLine("-----------------------------------");
        }

        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
}