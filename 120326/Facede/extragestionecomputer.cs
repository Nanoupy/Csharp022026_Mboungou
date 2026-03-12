using System;
using System.Collections.Generic;
namespace GamingEvolution;
//observer
public interface IObserver { void NotificaStato(bool acceso); }

public class SistemaVentole : IObserver
{
    public void NotificaStato(bool acceso) => 
        Console.WriteLine(acceso ? "[Observer] Ventole: Avvio regime Gaming (2000 RPM)." : "[Observer] Ventole: Arresto.");
}
public class SistemaLuci : IObserver
{
    public void NotificaStato(bool acceso) => 
        Console.WriteLine(acceso ? "[Observer] Luci RGB: Effetto Arcobaleno ATTIVO." : "[Observer] Luci RGB: Spente.");
}

//componenti
public interface IHardware { void Start(); void Stop(); }

public class Monitor : IHardware {
    public void Start() => Console.WriteLine("Monitor: Segnale ricevuto (4K).");
    public void Stop() => Console.WriteLine("Monitor: Standby.");
}
public class SchedaVideo : IHardware {
    public void Start() => Console.WriteLine("GPU: Driver caricati.");
    public void Stop() => Console.WriteLine("GPU: Spegnimento core.");
}
public static class HardwareFactory
{
    public static IHardware Create(string tipo) => tipo.ToLower() switch
    {
        "monitor" => new Monitor(),
        "gpu" => new SchedaVideo(),
        _ => throw new ArgumentException("Hardware sconosciuto")
    };
}
//
public class GamingSetupFacade
{
    private static GamingSetupFacade _instance;
    private readonly List<IHardware> _hardware = new();
    private readonly List<IObserver> _observers = new();
    private bool _isAcceso = false;
    // Singleton: Costruttore privato 
    private GamingSetupFacade()
    {
        // Uso della Factory per popolare il sistema
        _hardware.Add(HardwareFactory.Create("gpu"));
        _hardware.Add(HardwareFactory.Create("monitor"));
    }
    public static GamingSetupFacade Instance => _instance ??= new GamingSetupFacade();
    // Metodi Observer per la reazione dei sistemi secondari
    public void Attach(IObserver o) => _observers.Add(o);
    private void Notify(bool acceso) => _observers.ForEach(o => o.NotificaStato(acceso));
    // Facade
    public void AvviaPostazione()
    {
        if (_isAcceso)
        {
            Console.WriteLine("\n[!] Il sistema è già acceso.");
            return;
        }
        Console.WriteLine("\n==== Facade: Avvio sistema gaming ====");
        _hardware.ForEach(h => h.Start());
        Notify(true); // Notifica agli osservatori
        _isAcceso = true;
        Console.WriteLine("------------------------------------\n");
    }
    public void SpegniPostazione()
    {
        if (!_isAcceso)
        {
            Console.WriteLine("\n[!] Il sistema è già spento.");
            return;
        }
        Console.WriteLine("\n--- FACADE: SPEGNIMENTO ---");
        _hardware.ForEach(h => h.Stop());
        Notify(false);
        _isAcceso = false;
        Console.WriteLine("---------------------------\n");
    }
}
class Program
{
    static void Main()
    {
        // Otteniamo l'unica istanza (Singleton)
        var pcGaming = GamingSetupFacade.Instance;
        // Registriamo i moduli Observer
        pcGaming.Attach(new SistemaVentole());
        pcGaming.Attach(new SistemaLuci());

        bool continua = true;
        while (continua)
        {
            Console.WriteLine("========== PC gaming manager ==========");
            Console.WriteLine("1. Accendi Postazione");
            Console.WriteLine("2. Spegni Postazione");
            Console.WriteLine("0. Esci");
            Console.Write("Seleziona un'opzione: ");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    pcGaming.AvviaPostazione();
                    break;
                case "2":
                    pcGaming.SpegniPostazione();
                    break;
                case "0":
                    pcGaming.SpegniPostazione(); // Spegne tutto prima di uscire per sicurezza
                    continua = false;
                    Console.WriteLine("Chiusura programma...");
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }
    }
}