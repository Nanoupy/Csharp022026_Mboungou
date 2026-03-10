using System;
using System.Collections.Generic;

namespace EsercizioObserverMeteo
{
    public interface IObserver
    {
        void Aggiorna(string messaggio);
    }
    public interface ISoggetto
    {
        void Registra(IObserver osservatore);
        void Rimuovi(IObserver osservatore);
        void Notifica(string messaggio);
    }
// classe per il soggetto
    public class CentroMeteo : ISoggetto
    {
        private List<IObserver> _osservatori = new List<IObserver>();
        public void Registra(IObserver osservatore)
        {
            _osservatori.Add(osservatore);
            Console.WriteLine("Sistema: Nuovo display registrato.");
        }
        public void Rimuovi(IObserver osservatore)
        {
            _osservatori.Remove(osservatore);
            Console.WriteLine("Sistema: Display rimosso.");
        }
        public void Notifica(string messaggio)
        {
            foreach (var osservatore in _osservatori)
            {
                osservatore.Aggiorna(messaggio);
            }
        }
        public void AggiornaMeteo(string dati)
        {
            Console.WriteLine($"\n[Centro Meteo] Rilevamento dati: {dati}");
            Notifica(dati);
        }
    }
    // classi per l'observer
    public class DisplayConsole : IObserver
    {
        public void Aggiorna(string messaggio)
        {
            Console.WriteLine($"[Display Console] Visualizzazione dati: {messaggio}");
        }
    }
    public class DisplayMobile : IObserver
    {
        public void Aggiorna(string messaggio)
        {
            Console.WriteLine($"[Notifica Mobile] 📱 Meteo Aggiornato: {messaggio}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CentroMeteo centro = new CentroMeteo();
            IObserver console = new DisplayConsole();
            IObserver mobile = new DisplayMobile();
            centro.Registra(console);
            centro.Registra(mobile);
            bool continua = true;
            while (continua)
            {
                Console.WriteLine("\n--- Inserimento Dati Meteo ---");
                Console.Write("Inserisci condizione meteo (es. Sole, Pioggia) o 'esci': ");
                string input = Console.ReadLine();

                if (input.ToLower() == "esci")
                {
                    continua = false;
                }
                else
                {
                    centro.AggiornaMeteo(input);
                }
            }
            Console.WriteLine("Applicazione terminata.");
        }
    }
}