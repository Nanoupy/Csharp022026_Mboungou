using System;
using System.Collections.Generic;
using System.Linq;
// 1. astrazione Classe padre
public abstract class Animale
{
    private string nome;
    private int eta;
    public string Nome 
    { 
        get => nome; 
        set => nome = !string.IsNullOrWhiteSpace(value) ? value : "Sconosciuto"; 
    }
    public int Eta 
    { 
        get => eta; 
        set => eta = value >= 0 ? value : 0; 
    }
    protected Animale(string nome, int eta)
    {
        Nome = nome;
        Eta = eta;
    }

    public virtual void MostraInformazioni()
    {
        Console.Write($"[Tipo: {this.GetType().Name}] Nome: {Nome}, Età: {Eta} anni");
    }
    public abstract void EmettiVerso();
}

// 2. ereditarietà : Classi figlie
public class Mucca : Animale
{
    public double ProduzioneLatte { get; set; }
    public Mucca(string nome, int eta, double latte) : base(nome, eta) => ProduzioneLatte = latte;
    public override void EmettiVerso() => Console.WriteLine("Muuu!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Produzione Latte: {ProduzioneLatte}L"); }
}
public class Gallina : Animale
{
    public int UovaSettimanali { get; set; }
    public Gallina(string nome, int eta, int uova) : base(nome, eta) => UovaSettimanali = uova;
    public override void EmettiVerso() => Console.WriteLine("Coccodè!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Uova/Settimana: {UovaSettimanali}"); }
}
public class Pecora : Animale
{
    public string QualitaLana { get; set; }
    public Pecora(string nome, int eta, string lana) : base(nome, eta) => QualitaLana = lana;
    public override void EmettiVerso() => Console.WriteLine("Beeeh!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Qualità Lana: {QualitaLana}"); }
}
public class Maiale : Animale
{
    public double Peso { get; set; }
    public Maiale(string nome, int eta, double peso) : base(nome, eta) => Peso = peso;
    public override void EmettiVerso() => Console.WriteLine("Oink!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Peso: {Peso}kg"); }
}
public class Cavallo : Animale
{
    public string Razza { get; set; }
    public Cavallo(string nome, int eta, string razza) : base(nome, eta) => Razza = razza;
    public override void EmettiVerso() => Console.WriteLine("Niiiigh!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Razza: {Razza}"); }
}
public class Capra : Animale
{
    public double LunghezzaCorna { get; set; }
    public Capra(string nome, int eta, double corna) : base(nome, eta) => LunghezzaCorna = corna;
    public override void EmettiVerso() => Console.WriteLine("Meeeh!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Lunghezza Corna: {LunghezzaCorna}cm"); }
}
public class Anatra : Animale
{
    public bool SaVolare { get; set; }
    public Anatra(string nome, int eta, bool vola) : base(nome, eta) => SaVolare = vola;
    public override void EmettiVerso() => Console.WriteLine("Quack!");
    public override void MostraInformazioni() { base.MostraInformazioni(); Console.WriteLine($", Sa Volare: {(SaVolare ? "Sì" : "No")}"); }
}
//  main e gestione
class Program
{
    static List<Animale> fattoria = new List<Animale>();
    static void Main()
    {
        fattoria.Add(new Mucca("Carolina", 5, 20.5));
        fattoria.Add(new Gallina("Rosita", 2, 6));
        fattoria.Add(new Pecora("Dolly", 3, "Pregiata"));
        fattoria.Add(new Maiale("Porky", 4, 110.0));
        fattoria.Add(new Cavallo("Spirit", 7, "Mustang"));
        fattoria.Add(new Capra("Beppa", 4, 15.0));
        fattoria.Add(new Anatra("Daffy", 1, true));
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n--- GESTIONE FATTORIA (7 SPECIE) ---");
            Console.WriteLine("1. Mostra tutti gli animali");
            Console.WriteLine("2. Aggiungi Animale");
            Console.WriteLine("3. Cancella Animale");
            Console.WriteLine("4. Modifica Animale");
            Console.WriteLine("5. Visualizza divisi per tipo");
            Console.WriteLine("0. Esci");
            Console.Write("Scelta: ");

            switch (Console.ReadLine())
            {
                case "1": MostraAnimali(); break;
                case "2": AggiungiAnimale(); break;
                case "3": CancellaAnimale(); break;
                case "4": ModificaAnimale(); break;
                case "5": MostraPerTipo(); break;
                case "0": continua = false; break;
                default: Console.WriteLine("Scelta non valida."); break;
            }
        }
    }
    static void MostraAnimali()
    {
        Console.WriteLine("\nElenco Animali:");
        foreach (var a in fattoria)
        {
            a.MostraInformazioni();
            Console.Write("Verso: ");
            a.EmettiVerso();
        }
    }
    static void AggiungiAnimale()
    {
        Console.WriteLine("Tipo (1.Mucca, 2.Gallina, 3.Pecora, 4.Maiale, 5.Cavallo, 6.Capra, 7.Anatra): ");
        string tipo = Console.ReadLine();
        Console.Write("Nome: "); string nome = Console.ReadLine();
        Console.Write("Età: "); int eta = int.Parse(Console.ReadLine());

        switch (tipo)
        {
            case "1": fattoria.Add(new Mucca(nome, eta, 10.0)); break;
            case "2": fattoria.Add(new Gallina(nome, eta, 4)); break;
            case "3": fattoria.Add(new Pecora(nome, eta, "Grezza")); break;
            case "4": fattoria.Add(new Maiale(nome, eta, 90.0)); break;
            case "5": fattoria.Add(new Cavallo(nome, eta, "Arabo")); break;
            case "6": fattoria.Add(new Capra(nome, eta, 10.0)); break;
            case "7": fattoria.Add(new Anatra(nome, eta, false)); break;
            default: Console.WriteLine("Tipo non riconosciuto."); break;
        }
    }
    static void CancellaAnimale()
    {
        Console.Write("Nome dell'animale da rimuovere: ");
        string nome = Console.ReadLine();
        fattoria.RemoveAll(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
    }
    static void ModificaAnimale()
    {
        Console.Write("Nome dell'animale da modificare: ");
        string nome = Console.ReadLine();
        var animale = fattoria.Find(a => a.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        if (animale != null)
        {
            Console.Write("Nuovo Nome: "); animale.Nome = Console.ReadLine();
            Console.Write("Nuova Età: "); animale.Eta = int.Parse(Console.ReadLine());
        }
        else { Console.WriteLine("Animale non trovato."); }
    }
    static void MostraPerTipo()
    {
        Console.WriteLine("\n--- Divisione per Tipo ---");
        var gruppi = fattoria.GroupBy(a => a.GetType().Name);
        foreach (var gruppo in gruppi)
        {
            Console.WriteLine($"\nCATEGORIA {gruppo.Key.ToUpper()}:");
            foreach (var a in gruppo) a.MostraInformazioni();
        }
    }
}