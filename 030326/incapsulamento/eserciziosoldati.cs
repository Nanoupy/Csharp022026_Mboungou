using System;
using System.Collections.Generic;

namespace EsercizioSoldati
{
    // --- CLASSE BASE ---
    public class Soldato
    {
        // Campi privati (Incapsulamento)
        private string nome;
        private string grado;
        private int anniServizio;
        // Proprietà pubbliche
        public string Nome { get { return nome; } set { nome = value; } }
        public string Grado { get { return grado; } set { grado = value; } }
        public int AnniServizio
        {
            get { return anniServizio; }
            set 
            { 
                // Controllo: solo valori >= 0
                if (value >= 0) anniServizio = value; 
                else anniServizio = 0; 
            }
        }
        // Metodo virtuale (Polimorfismo)
        public virtual void Descrizione()
        {
            Console.WriteLine($"[Soldato] Nome: {Nome}, Grado: {Grado}, Anni Servizio: {AnniServizio}");
        }
    }
    // --- CLASSI DERIVATE ---
    // 1. Fante
    public class Fante : Soldato
    {
        private string arma;
        public string Arma { get { return arma; } set { arma = value; } }

        public override void Descrizione()
        {
            Console.WriteLine($"[Fante] Nome: {Nome}, Grado: {Grado}, Anni Servizio: {AnniServizio}, Arma: {Arma}");
        }
    }
    // 2. Artigliere
    public class Artigliere : Soldato
    {
        private int calibro;
        public int Calibro 
        { 
            get { return calibro; } 
            set { if (value > 0) calibro = value; } 
        }
        public override void Descrizione()
        {
            Console.WriteLine($"[Artigliere] Nome: {Nome}, Grado: {Grado}, Anni Servizio: {AnniServizio}, Calibro: {Calibro}mm");
        }
    }
    // --- PROGRAMMA PRINCIPALE ---
    class Program
    {
        static void Main(string[] args)
        {
            // Utilizzo di una List per il polimorfismo
            List<Soldato> caserma = new List<Soldato>();
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n--- MENU GESTIONE SOLDATI ---");
                Console.WriteLine("a. Aggiungi Fante");
                Console.WriteLine("b. Aggiungi Artigliere");
                Console.WriteLine("c. Visualizza tutti i soldati");
                Console.WriteLine("d. Esci");
                Console.Write("Scegli un'opzione: ");
                
                char scelta = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (scelta)
                {
                    case 'a':
                        Fante f = new Fante();
                        Console.Write("Nome: "); f.Nome = Console.ReadLine();
                        Console.Write("Grado: "); f.Grado = Console.ReadLine();
                        Console.Write("Anni Servizio: "); f.AnniServizio = int.Parse(Console.ReadLine());
                        Console.Write("Arma in dotazione: "); f.Arma = Console.ReadLine();
                        caserma.Add(f);
                        break;

                    case 'b':
                        Artigliere art = new Artigliere();
                        Console.Write("Nome: "); art.Nome = Console.ReadLine();
                        Console.Write("Grado: "); art.Grado = Console.ReadLine();
                        Console.Write("Anni Servizio: "); art.AnniServizio = int.Parse(Console.ReadLine());
                        Console.Write("Calibro gestito (mm): "); art.Calibro = int.Parse(Console.ReadLine());
                        caserma.Add(art);
                        break;
                    case 'c':
                        Console.WriteLine("\nElenco Soldati:");
                        foreach (Soldato s in caserma)
                        {
                            s.Descrizione();
                        }
                        break;

                    case 'd':
                        continua = false;
                        break;

                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
    }
}