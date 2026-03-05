//scuola artistica
using System;
using System.Collections.Generic;

// classe base
public class Corso
{
    public string NomeCorso;
    public int DurataOre;
    public string Docente;
    public List<string> Studenti = new List<string>();
    public Corso(string nome, int durata, string docente)
    {
        NomeCorso = nome;
        DurataOre = durata;
        Docente = docente;
    }
    public void AggiungiStudente(string nomeStudente)
    {
        Studenti.Add(nomeStudente);
        Console.WriteLine("Studente aggiunto con successo!");
    }
    public override string ToString()
    {
        return $"Corso: {NomeCorso} | Docente: {Docente} | Ore: {DurataOre} | Studenti: {Studenti.Count}";
    }
    public virtual void MetodoSpeciale()
    {
        Console.WriteLine("Attività generica del corso.");
    }
}

// classi derivati
public class CorsoMusica : Corso
{
    public string Strumento;

    public CorsoMusica(string nome, int durata, string docente, string strumento) : base(nome, durata, docente)
    {
        Strumento = strumento;
    }
    public override string ToString() => base.ToString() + $" | Strumento: {Strumento}";
    public override void MetodoSpeciale() => Console.WriteLine($"Si tiene una prova pratica dello strumento: {Strumento}");
}
public class CorsoPittura : Corso
{
    public string Tecnica;

    public CorsoPittura(string nome, int durata, string docente, string tecnica) : base(nome, durata, docente)
    {
        Tecnica = tecnica;
    }
    public override string ToString() => base.ToString() + $" | Tecnica: {Tecnica}";

    public override void MetodoSpeciale() => Console.WriteLine($"Si lavora su una tela con tecnica: {Tecnica}");
}
public class CorsoDanza : Corso
{
    public string Stile;
    public CorsoDanza(string nome, int durata, string docente, string stile) : base(nome, durata, docente)
    {
        Stile = stile;
    }
    public override string ToString() => base.ToString() + $" | Stile: {Stile}";
    public override void MetodoSpeciale() => Console.WriteLine($"Esecuzione coreografia nello stile: {Stile}");
}
// main
class Program
{
    static void Main()
    {
        List<Corso> listaCorsi = new List<Corso>();
        string scelta = "";
        while (scelta != "0")
        {
            Console.WriteLine("\n=== MENU SCUOLA ARTISTICA ===");
            Console.WriteLine("[1] Aggiungi Musica | [2] Aggiungi Pittura | [3] Aggiungi Danza");
            Console.WriteLine("[4] Aggiungi studente | [5] Visualizza corsi | [6] Cerca per Docente");
            Console.WriteLine("[7] Esegui Metodo Speciale | [0] Esci");
            Console.Write("Scelta: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                case "2":
                case "3":
                    Console.Write("Nome Corso: "); string n = Console.ReadLine();
                    Console.Write("Durata (ore): "); int d = int.Parse(Console.ReadLine());
                    Console.Write("Docente: "); string doc = Console.ReadLine();
                    
                    if (scelta == "1") {
                        Console.Write("Strumento: "); string s = Console.ReadLine();
                        listaCorsi.Add(new CorsoMusica(n, d, doc, s));
                    } else if (scelta == "2") {
                        Console.Write("Tecnica: "); string t = Console.ReadLine();
                        listaCorsi.Add(new CorsoPittura(n, d, doc, t));
                    } else {
                        Console.Write("Stile: "); string st = Console.ReadLine();
                        listaCorsi.Add(new CorsoDanza(n, d, doc, st));
                    }
                    Console.WriteLine("Corso aggiunto!");
                    break;

                case "4":
                    VisualizzaIndici(listaCorsi);
                    Console.Write("Seleziona indice corso: ");
                    int idxS = int.Parse(Console.ReadLine());
                    Console.Write("Nome studente: ");
                    listaCorsi[idxS].AggiungiStudente(Console.ReadLine());
                    break;

                case "5":
                    VisualizzaIndici(listaCorsi);
                    break;

                case "6":
                    Console.Write("Nome docente da cercare: ");
                    string cercaDoc = Console.ReadLine();
                    foreach (var c in listaCorsi)
                        if (c.Docente.ToLower().Contains(cercaDoc.ToLower())) Console.WriteLine(c.ToString());
                    break;

                case "7":
                    VisualizzaIndici(listaCorsi);
                    Console.Write("Seleziona indice corso: ");
                    int idxM = int.Parse(Console.ReadLine());
                    listaCorsi[idxM].MetodoSpeciale();
                    break;
            }
        }
    }
    static void VisualizzaIndici(List<Corso> corsi)
    {
        for (int i = 0; i < corsi.Count; i++)
            Console.WriteLine($"[{i}] {corsi[i].ToString()}");
    }
}