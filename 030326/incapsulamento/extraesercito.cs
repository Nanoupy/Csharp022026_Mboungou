using System;
using System.Collections.Generic;

namespace EsercizioEsercitoCompleto
{
    // ==========================================
    // 1. CLASSE BASE: SOLDATO
    // ==========================================
    public class Soldato
    {
        // Campi privati (Incapsulamento)
        private string nome;
        private string grado;
        private int anniServizio;

        // Proprietà pubbliche con logica di controllo
        public string Nome 
        { 
            get { return nome; } 
            set { nome = value; } 
        }

        public string Grado 
        { 
            get { return grado; } 
            set { grado = value; } 
        }

        public int AnniServizio
        {
            get { return anniServizio; }
            set 
            { 
                // Controllo richiesto: solo valori >= 0
                if (value >= 0) anniServizio = value; 
                else anniServizio = 0; 
            }
        }

        // Metodo virtuale per il Polimorfismo
        public virtual void Descrizione()
        {
            Console.WriteLine($"Nome: {Nome} | Grado: {Grado} | Anni di Servizio: {AnniServizio}");
        }
    }

    // ==========================================
    // 2. CLASSI DERIVATE (EREDITARIETÀ)
    // ==========================================

    // Classe Fante
    public class Fante : Soldato
    {
        private string arma;
        public string Arma { get { return arma; } set { arma = value; } }

        // Override per aggiungere l'arma alla descrizione
        public override void Descrizione()
        {
            Console.Write("[FANTE] ");
            base.Descrizione(); // Richiama la descrizione base (nome, grado, anni)
            Console.WriteLine($"       -> Arma in dotazione: {Arma}");
        }
    }

    // Classe Artigliere
    public class Artigliere : Soldato
    {
        private int calibro;
        public int Calibro 
        { 
            get { return calibro; } 
            set { if (value > 0) calibro = value; } 
        }

        // Override per aggiungere il calibro alla descrizione
        public override void Descrizione()
        {
            Console.Write("[ARTIGLIERE] ");
            base.Descrizione();
            Console.WriteLine($"            -> Calibro gestito: {Calibro}mm");
        }
    }
// classe esercito
    public class Esercito
    {
        // Lista generica che sfrutta il polimorfismo (contiene Soldati, Fanti o Artiglieri)
        private List<Soldato> reparti;

        public Esercito()
        {
            reparti = new List<Soldato>();
        }

        public void AggiungiSoldato(Soldato s)
        {
            reparti.Add(s);
        }

        public void MostraTuttiIDettagli()
        {
            if (reparti.Count == 0)
            {
                Console.WriteLine("\nL'esercito è vuoto.");
                return;
            }

            Console.WriteLine("\n--- ELENCO FORZE ARMATE ---");
            foreach (Soldato s in reparti)
            {
                // Chiama il metodo corretto in base all'oggetto reale (Fante o Artigliere)
                s.Descrizione();
            }
            Console.WriteLine("---------------------------\n");
        }
    }

    // ==========================================
    // 4. PROGRAMMA PRINCIPALE (MENU INTERATTIVO)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Esercito mioEsercito = new Esercito();
            bool continua = true;

            

            while (continua)
            {
                Console.WriteLine("=== SISTEMA GESTIONE ESERCITO ===");
                Console.WriteLine("a. Aggiungi un nuovo Fante");
                Console.WriteLine("b. Aggiungi un nuovo Artigliere");
                Console.WriteLine("c. Visualizzare tutti i soldati");
                Console.WriteLine("d. Uscire");
                Console.Write("Scegli un'opzione: ");

                string scelta = Console.ReadLine().ToLower();

                switch (scelta)
                {
                    case "a":
                        Fante f = new Fante();
                        Console.Write("Inserisci Nome: "); f.Nome = Console.ReadLine();
                        Console.Write("Inserisci Grado: "); f.Grado = Console.ReadLine();
                        Console.Write("Anni di Servizio: "); f.AnniServizio = int.Parse(Console.ReadLine());
                        Console.Write("Arma assegnata: "); f.Arma = Console.ReadLine();
                        mioEsercito.AggiungiSoldato(f);
                        Console.WriteLine("Fante aggiunto correttamente.");
                        break;

                    case "b":
                        Artigliere art = new Artigliere();
                        Console.Write("Inserisci Nome: "); art.Nome = Console.ReadLine();
                        Console.Write("Inserisci Grado: "); art.Grado = Console.ReadLine();
                        Console.Write("Anni di Servizio: "); art.AnniServizio = int.Parse(Console.ReadLine());
                        Console.Write("Calibro cannone (mm): "); art.Calibro = int.Parse(Console.ReadLine());
                        mioEsercito.AggiungiSoldato(art);
                        Console.WriteLine("Artigliere aggiunto correttamente.");
                        break;

                    case "c":
                        mioEsercito.MostraTuttiIDettagli();
                        break;

                    case "d":
                        Console.WriteLine("Chiusura sistema...");
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Errore: Opzione non valida.");
                        break;
                }
                
                if (continua)
                {
                    Console.WriteLine("\nPremi un tasto per tornare al menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}