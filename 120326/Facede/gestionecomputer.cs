using System;
namespace GamingSystem;
// sottosistema
public class Monitor
{
    public void Accendi() => Console.WriteLine("Monitor: Accensione... Risoluzione 4K impostata.");
    public void Spegni() => Console.WriteLine("Monitor: Spegnimento in corso.");
}
public class Tastiera
{
    public void InizializzaRGB() => Console.WriteLine("Tastiera: Profilo LED 'Gaming' caricato.");
    public void Disabilita() => Console.WriteLine("Tastiera: Luci spente.");
}
public class Mouse
{
    public void ImpostaDPI() => Console.WriteLine("Mouse: DPI impostati a 1600.");
    public void Disconnetti() => Console.WriteLine("Mouse: Sensore disattivato.");
}
public class SchedaVideo
{
    public void AvviaVentole() => Console.WriteLine("GPU: Ventole attive. Caricamento Driver...");
    public void Arresta() => Console.WriteLine("GPU: Raffreddamento terminato, arresto.");
}
// Facede
public class GamingSetupFacade
{
    // componenti del sottositema 
    private readonly Monitor _monitor;
    private readonly Tastiera _tastiera;
    private readonly Mouse _mouse;
    private readonly SchedaVideo _gpu;
    public GamingSetupFacade()
    {
        _monitor = new Monitor();
        _tastiera = new Tastiera();
        _mouse = new Mouse();
        _gpu = new SchedaVideo();
    }
    // avvio semplificato 
    public void AvviaPostazione()
    {
        Console.WriteLine("\n==== Avvio postazione gaming ====");
        _gpu.AvviaVentole();
        _monitor.Accendi();
        _tastiera.InizializzaRGB();
        _mouse.ImpostaDPI();
        Console.WriteLine(">>> Sistema pronto! Buon divertimento. <<<");
    }
    // spegnimento semplificato
    public void SpegniPostazione()
    {
        Console.WriteLine("\n--- spegnimento postazione ---");
        _monitor.Spegni();
        _tastiera.Disabilita();
        _mouse.Disconnetti();
        _gpu.Arresta();
        Console.WriteLine(">>> Postazione spenta in sicurezza. <<<");
    }
}
class Program
{
    static void Main()
    {
        // client interagisce solo con la Facade
        GamingSetupFacade pcGaming = new GamingSetupFacade();
        pcGaming.AvviaPostazione();
        Console.WriteLine("\n... Stai giocando a  GTA7 ...");
        Console.WriteLine("(Premi un tasto per smettere di giocare)");
        Console.ReadKey();
        pcGaming.SpegniPostazione();
    }
}