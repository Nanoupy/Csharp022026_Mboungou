using System;
using System.Collections.Generic;
namespace EnteFormativo
{
    //astrazione
    public abstract class Corso
    {
        private string titolo;
        private int durataOre;
        private string docente; 
//incapsulamento
        public string Titolo { get => titolo; set => titolo = value; }
        
        public int DurataOre
        {
            get => durataOre;
            set => durataOre = value > 0 ? value : 1;
        }
        public string Docente { get => docente; set => docente = value; }
        protected Corso(string titolo, int durata, string docente)
        {
            Titolo = titolo;
            DurataOre = durata;
            Docente = docente;
        }
// metodi astratti
        public abstract void ErogaCorso();
        public virtual void StampaDettagli()
        {
            Console.WriteLine($"\nCORSO: {Titolo}");
            Console.WriteLine($"Docente: {Docente}");
            Console.WriteLine($"Durata: {DurataOre} ore");
        }
    }
  // eredita
    public class CorsoInPresenza : Corso
    {
        private string aula;
        private int numeroPosti;
        public int NumeroPosti
        {
            get => numeroPosti;
            set => numeroPosti = value >= 1 ? value : 1;
        }
        public CorsoInPresenza(string titolo, int durata, string docente, string aula, int posti) 
            : base(titolo, durata, docente)
        {
            this.aula = aula;
            this.NumeroPosti = posti;
        }
        public override void ErogaCorso()
        {
            Console.WriteLine($">> Registrazione presenze in corso nell'aula {aula}...");
        }
        public override void StampaDettagli()
        {
            base.StampaDettagli();
            Console.WriteLine($"Modalità: In Presenza (Aula {aula})");
            Console.WriteLine($"Posti disponibili: {NumeroPosti}");
        }
    }
    public class CorsoOnline : Corso
    {
        private string piattaforma;
        private string linkAccesso;
        public CorsoOnline(string titolo, int durata, string docente, string piattaforma, string link) 
            : base(titolo, durata, docente)
        {
            this.piattaforma = piattaforma;
            this.linkAccesso = link;
        }
        public override void ErogaCorso()
        {
            Console.WriteLine($">> Connessione alla piattaforma {piattaforma} in corso...");
            Console.WriteLine($">> Link: {linkAccesso}");
        }
        public override void StampaDettagli()
        {
            base.StampaDettagli();
            Console.WriteLine($"Modalità: Online ({piattaforma})");
        }
    }
   //main
    class Program
    {
        static void Main()
        {
            //polimorfismo
            List<Corso> catalogoCorsi = new List<Corso>();
            catalogoCorsi.Add(new CorsoInPresenza("Programmazione C#", 40, "Mario Rossi", "Aula Magna", 25));
            catalogoCorsi.Add(new CorsoOnline("Cybersecurity Base", 20, "Anna Bianchi", "Zoom", "https://bit.ly/cyber-101"));
            Console.WriteLine("=== GESTIONALE ENTE FORMATIVO ===");
            foreach (var corso in catalogoCorsi)
            {
                corso.StampaDettagli();
                corso.ErogaCorso();
                Console.WriteLine("---------------------------------");
            }
            Console.WriteLine("\nPremi un tasto per uscire...");
            Console.ReadKey();
        }
    }
}