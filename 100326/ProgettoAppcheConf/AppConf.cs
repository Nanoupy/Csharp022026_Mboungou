using System;
using System.Collections.Generic;
namespace EsercizioDesignPattern
{
//singleton
    public class ConfigurazioneSistema
    {
        private static ConfigurazioneSistema _instance;
        private Dictionary<string, string> _impostazioni;
        // costruttore
        private ConfigurazioneSistema()
        {
            _impostazioni = new Dictionary<string, string>();
        }
        // istanza
        public static ConfigurazioneSistema Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ConfigurazioneSistema();
                return _instance;
            }
        }
        public void Imposta(string chiave, string valore)
        {
            _impostazioni[chiave] = valore;
        }
        public string Leggi(string chiave)
        {
            return _impostazioni.ContainsKey(chiave) ? _impostazioni[chiave] : "Chiave non trovata";
        }
        public void StampaTutte()
        {
            Console.WriteLine("\n--- Elenco configurazioni ---");
            foreach (var coppia in _impostazioni)
            {
                Console.WriteLine($"[{coppia.Key}]: {coppia.Value}");
            }
        }
    }
    // factory method
    public interface IDispositivo
    {
        void Avvia();
        void MostraTipo();
    }
    public class Computer : IDispositivo
    {
        public void Avvia() => Console.WriteLine("Il computer si avvia...");
        public void MostraTipo() => Console.WriteLine("Tipo: Computer");
    }
    public class Stampante : IDispositivo
    {
        public void Avvia() => Console.WriteLine("La stampante si accende...");
        public void MostraTipo() => Console.WriteLine("Tipo: Stampante");
    }
    // classe Factory
    public static class DispositivoFactory
    {
        public static IDispositivo CreaDispositivo(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "computer": return new Computer();
                case "stampante": return new Stampante();
                default: return null;
            }
        }
    }
    //moduli
    public class ModuloA
    {
        public void Esegui()
        {
            var config = ConfigurazioneSistema.Instance;
            config.Imposta("Lingua", "Italiano");
            Console.WriteLine("Modulo A: Impostata lingua su Italiano.");
        }
    }
    public class ModuloB
    {
        public void Esegui()
        {
            var config = ConfigurazioneSistema.Instance;
            config.Imposta("Risoluzione", "1920x1080");
            Console.WriteLine("Modulo B: Impostata risoluzione su 1920x1080.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool continua = true;
            List<IDispositivo> inventario = new List<IDispositivo>();

            while (continua)
            {
                Console.WriteLine("\n===== Menu sistema centralizzato =====");
                Console.WriteLine("1. Esegui Modulo A e Modulo B "); //test singleton
                Console.WriteLine("2. Crea un nuovo Dispositivo "); // factory 
                Console.WriteLine("3. Mostra tutte le Configurazioni");
                Console.WriteLine("4. Avvia tutti i dispositivi creati");
                Console.WriteLine("5. Verifica istanza Singleton");
                Console.WriteLine("0. Esci");
                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();
                switch (scelta)
                {
                    case "1":
                        new ModuloA().Esegui();
                        new ModuloB().Esegui();
                        break;

                    case "2":
                        Console.Write("Inserisci tipo (computer/stampante): ");
                        string tipo = Console.ReadLine();
                        IDispositivo nuovo = DispositivoFactory.CreaDispositivo(tipo);
                        if (nuovo != null)
                        {
                            inventario.Add(nuovo);
                            Console.WriteLine("Dispositivo creato con successo!");
                        }
                        else Console.WriteLine("Errore: Tipo non valido.");
                        break;
                    case "3":
                        ConfigurazioneSistema.Instance.StampaTutte();
                        break;
                    case "4":
                        Console.WriteLine("\n--- Avvio Dispositivi ---");
                        foreach (var d in inventario)
                        {
                            d.MostraTipo();
                            d.Avvia();
                        }
                        break;
                    case "5":
                        var istanza1 = ConfigurazioneSistema.Instance;
                        var istanza2 = ConfigurazioneSistema.Instance;
                        bool uguali = object.ReferenceEquals(istanza1, istanza2);
                        Console.WriteLine($"Le due istanze sono uguali? {uguali}");
                        break;
                    case "0":
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
    }
}