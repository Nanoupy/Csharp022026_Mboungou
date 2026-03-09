using System;
//extra con due classi 
// primo Singleton 
public class Logger
{
    private static Logger _istanza;
    private static readonly object _lock = new object();
    private Logger() { }
    public static Logger GetIstanza()
    {
        lock (_lock)
        {
            if (_istanza == null) _istanza = new Logger();
            return _istanza;
        }
    }
    public void Log(string messaggio)
    {
        Console.WriteLine("[LOG] " + messaggio);
    }
}
// secondo Singleton 
public class Configuratore
{
    private static Configuratore _istanza;
    private static readonly object _lock = new object();

    // impostazioni
    public string NomeApplicazione = "La Mia App";
    public string Versione = "1.0.0";
    private Configuratore() { }
    public static Configuratore GetIstanza()
    {
        lock (_lock)
        {
            if (_istanza == null) _istanza = new Configuratore();
            return _istanza;
        }
    }
}
class Program
{
    static void Main()
    {
        // uso il Configuratore per leggere le impostazioni
        Configuratore config = Configuratore.GetIstanza();
        Console.WriteLine("Avvio di: " + config.NomeApplicazione + " v" + config.Versione);

        // uso il Logger per segnalare l'avvio
        Logger log = Logger.GetIstanza();
        log.Log("Il sistema è partito correttamente.");

        // controllo se che siano indipendenti
        Configuratore config2 = Configuratore.GetIstanza();
        if (config == config2)
        {
            Console.WriteLine("\nIl Configuratore è un Singleton corretto.");
        }
        
        Logger log2 = Logger.GetIstanza();
        if (log == log2)
        {
            Console.WriteLine("Il Logger è un Singleton corretto.");
        }
    }
}