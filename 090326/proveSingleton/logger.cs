using System;
// creazione di un logger centralizzato ch epossa essere usato in qualsiasi parte del programma per scrivere messagi di log su console
public class Logger
{
    private static Logger istanza;

    // oggetto per il controllo dei Thread 
    private static readonly object lockOggetto = new object();

    // costruttore privato: nessuno può fare "new Logger()" da fuori
    private Logger()
    {
        Console.WriteLine("[SISTEMA] Logger inizializzato per la prima volta.");
    }

    // metodo statico per ottenere l'istanza
    public static Logger GetIstanza()
    {
        if (istanza == null)
        {
            lock (lockOggetto)
            {
                if (istanza == null)
                {
                    istanza = new Logger();
                }
            }
        }
        return istanza;
    }

    // metodo per scrivere i messaggi con data e ora
    public void ScriviMessaggio(string messaggio)
    {
        string dataOra = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        Console.WriteLine("[" + dataOra + "] LOG: " + messaggio);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("--- Inizio Programma ---");

        // richiamo il logger dal punto A
        Logger log1 = Logger.GetIstanza();
        log1.ScriviMessaggio("Utente ha effettuato l'accesso.");

        // richiamo il logger dal punto B
        Logger log2 = Logger.GetIstanza();
        log2.ScriviMessaggio("Caricamento dati completato.");

        Console.WriteLine("\n--- Verifica Singleton ---");

        // dimostro che log1 e log2 sono lo stesso oggetto
        if (log1 == log2)
        {
            Console.WriteLine("Successo: log1 e log2 puntano alla stessa istanza.");
        }
        else
        {
            Console.WriteLine("Errore: le istanze sono diverse!");
        }
    }
}