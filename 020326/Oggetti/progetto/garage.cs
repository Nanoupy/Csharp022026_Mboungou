using System;
using System.Collections.Generic;

// 1. classe base
public class Veicolo
{
    public string Marca;
    public string Modello;

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }
    // Metodo virtuale personalizzato dalle classi figlie
    public virtual void StampaInfo()
    {
        Console.Write("Marca: " + Marca + ", Modello: " + Modello);
    }
}

// 2. classe derivata: auto 
public class Auto : Veicolo
{
    public int NumeroPorte;
    public Auto(string marca, string modello, int porte) : base(marca, modello)
    {
        NumeroPorte = porte;
    }
    public override void StampaInfo()
    {
        base.StampaInfo(); // Chiama la stampa di Marca e Modello
        Console.WriteLine(", Porte: " + NumeroPorte);
    }
}

// 3. CLASSE DERIVATA: MOTO
public class Moto : Veicolo
{
    public string TipoManubrio;

    public Moto(string marca, string modello, string manubrio) : base(marca, modello)
    {
        TipoManubrio = manubrio;
    }

    public override void StampaInfo()
    {
        base.StampaInfo(); // Chiama la stampa di Marca e Modello
        Console.WriteLine(", Manubrio: " + TipoManubrio);
    }
}

// 4. PROGRAMMA PRINCIPALE
class Program
{
    static void Main()
    {
        // Lista generica che accetta qualsiasi Veicolo 
        List<Veicolo> garage = new List<Veicolo>();
        string scelta = "";

        while (scelta != "3")
        {
            Console.WriteLine("\n--- GESTIONE GARAGE ---");
            Console.WriteLine("1. Inserisci Auto");
            Console.WriteLine("2. Inserisci Moto");
            Console.WriteLine("3. Visualizza Veicoli");
            Console.WriteLine("4. Esci");
            Console.Write("Scegli un'opzione: ");
            scelta = Console.ReadLine();

            if (scelta == "1")
            {
                Console.Write("Marca: "); string ma = Console.ReadLine();
                Console.Write("Modello: "); string mo = Console.ReadLine();
                Console.Write("Numero Porte: "); int po = int.Parse(Console.ReadLine());
                
                garage.Add(new Auto(ma, mo, po));
                Console.WriteLine("Auto aggiunta!");
            }
            else if (scelta == "2")
            {
                Console.Write("Marca: "); string ma = Console.ReadLine();
                Console.Write("Modello: "); string mo = Console.ReadLine();
                Console.Write("Tipo Manubrio: "); string man = Console.ReadLine();
                
                garage.Add(new Moto(ma, mo, man));
                Console.WriteLine("Moto aggiunta!");
            }
            else if (scelta == "3")
            {
                Console.WriteLine("\n--- VEICOLI NEL GARAGE ---");
                if (garage.Count == 0) Console.WriteLine("Il garage è vuoto.");
                
                foreach (Veicolo v in garage)
                {
                    v.StampaInfo(); // Grazie al polimorfismo, chiama il metodo corretto
                }
            }
            else if (scelta == "4")
            {
                Console.WriteLine("Chiusura programma...");
                break;
            }
            else
            {
                Console.WriteLine("Opzione non valida!");
            }
        }
    }
}