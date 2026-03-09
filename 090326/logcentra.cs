using System;
using System.Collections.Generic;
public sealed class Logger
{
    private static Logger _instance;
    // oggetto di lock per la sicurezza (thread-safety)
    private static readonly object _lock = new object();
    // lista interna per memorizzare i messaggi di log
    private List<string> cronologiaLog;
    //costruttore privato
    private Logger()
    {
        cronologiaLog = new List<string>();
        Console.WriteLine("[SISTEMA] Logger creato per la prima volta.");
    }
    // accedere all'oggetto
    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }
    public void Log(string messaggio)
    {
        string voce = "[" + DateTime.Now.ToLongTimeString() + "] " + messaggio;
        cronologiaLog.Add(voce);
    }
    public void StampaTuttiILog()
    {
        Console.WriteLine("\n--- CRONOLOGIA LOG COMPLETA ---");
        foreach (string s in cronologiaLog)
        {
            Console.WriteLine(s);
        }
    }
}
class Program
{
    static void Main()
    {
        // otteniamo il riferimento al Logger per la prima volta
        Logger primoRiferimento = Logger.Instance;
        primoRiferimento.Log("Messaggio inviato dal primo riferimento.");
        // otteniamo di nuovo l'istanza in una variabile diversa
        Logger secondoRiferimento = Logger.Instance;
        secondoRiferimento.Log("Messaggio inviato dal secondo riferimento.");
        //  i log sono finiti nello stesso posto
        secondoRiferimento.StampaTuttiILog();
        // Verifica finale
        if (ReferenceEquals(primoRiferimento, secondoRiferimento))
        {
            Console.WriteLine("\nVerifica: Entrambi i riferimenti puntano allo stesso oggetto!");
        }
    }
}