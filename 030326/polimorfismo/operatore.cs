using System;
using System.Collections.Generic;

//classse base 
public class Operatore
{
    private string nome;
    private string turno; // "giorno" o "notte"

    public string Nome 
    { 
        get => nome; 
        set => nome = value; 
    }

    public string Turno
    {
        get => turno;
        set
        {
            // Controllo: accetta solo giorno o notte
            if (value.ToLower() == "giorno" || value.ToLower() == "notte")
                turno = value.ToLower();
            else
                turno = "giorno"; // Valore di default in caso di errore
        }
    }

    public Operatore(string nome, string turno)
    {
        Nome = nome;
        Turno = turno;
    }

    public virtual void EseguiCompito()
    {
        Console.WriteLine("Operatore generico in servizio.");
    }

    public override string ToString()
    {
        return $"[Nome: {Nome}, Turno: {Turno}]";
    }
}

// --- 2. CLASSI DERIVATE ---

public class OperatoreEmergenza : Operatore
{
    private int livelloUrgenza;
    public int LivelloUrgenza
    {
        get => livelloUrgenza;
        set => livelloUrgenza = (value >= 1 && value <= 5) ? value : 1;
    }

    public OperatoreEmergenza(string n, string t, int l) : base(n, t) { LivelloUrgenza = l; }

    public override void EseguiCompito() => Console.WriteLine($"{Nome}: Gestione emergenza di livello {LivelloUrgenza}");
}

public class OperatoreSicurezza : Operatore
{
    public string AreaSorvegliata { get; set; }
    public OperatoreSicurezza(string n, string t, string a) : base(n, t) { AreaSorvegliata = a; }

    public override void EseguiCompito() => Console.WriteLine($"{Nome}: Sorveglianza dell'area {AreaSorvegliata}");
}

public class OperatoreLogistica : Operatore
{
    private int numeroConsegne;
    public int NumeroConsegne
    {
        get => numeroConsegne;
        set => numeroConsegne = (value >= 0) ? value : 0;
    }

    public OperatoreLogistica(string n, string t, int c) : base(n, t) { NumeroConsegne = c; }

    public override void EseguiCompito() => Console.WriteLine($"{Nome}: Coordinamento di {NumeroConsegne} consegne");
}

// --- 3. MAIN ---
class Program
{
    static void Main()
    {
        List<Operatore> personale = new List<Operatore>();
        string scelta = "";

        while (scelta != "d")
        {
            Console.WriteLine("\n--- GESTIONE PERSONALE OPERATIVO ---");
            Console.WriteLine("a. Aggiungi Operatore | b. Visualizza Elenco | c. Esegui Compiti | d. Esci");
            Console.Write("Scelta: ");
            scelta = Console.ReadLine().ToLower();

            switch (scelta)
            {
                case "a":
                    Console.WriteLine("Tipo: 1.Emergenza, 2.Sicurezza, 3.Logistica");
                    string tipo = Console.ReadLine();
                    Console.Write("Nome: "); string n = Console.ReadLine();
                    Console.Write("Turno (giorno/notte): "); string t = Console.ReadLine();

                    if (tipo == "1") {
                        Console.Write("Livello Urgenza (1-5): "); int l = int.Parse(Console.ReadLine());
                        personale.Add(new OperatoreEmergenza(n, t, l));
                    } else if (tipo == "2") {
                        Console.Write("Area Sorvegliata: "); string a = Console.ReadLine();
                        personale.Add(new OperatoreSicurezza(n, t, a));
                    } else if (tipo == "3") {
                        Console.Write("Numero Consegne: "); int c = int.Parse(Console.ReadLine());
                        personale.Add(new OperatoreLogistica(n, t, c));
                    }
                    break;

                case "b":
                    Console.WriteLine("\n--- LISTA PERSONALE ---");
                    foreach (var op in personale) Console.WriteLine(op.ToString() + " - Tipo: " + op.GetType().Name);
                    break;

                case "c":
                    Console.WriteLine("\n--- ESECUZIONE COMPITI (POLIMORFISMO) ---");
                    foreach (var op in personale) op.EseguiCompito();
                    break;
            }
        }
    }
}