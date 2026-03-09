using System;

public sealed class Singleton
{
    // Riferimento all'unica istanza (inizialmente null)
        private static Singleton _instance;

    // Oggetto di lock per garantire il thread-safety 
    private static readonly object _lock = new object();

    // Costruttore privato: impedisce 'new Singleton()' dall'esterno
    private Singleton()
    {
        // Codice di inizializzazione
    }

    // Punto di accesso globale all'istanza
    public static Singleton Instance
    {
        get
        {
            // Primo controllo per performance
            if (_instance == null)
            {
                lock (_lock) 
                {
                    // Secondo controllo per sicurezza tra thread
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance; // Il return deve stare fuori dal blocco 'if' principale
        }
    }

    public void DoSomething()
    {
        Console.WriteLine("Metodo DoSomething chiamato sull'istanza Singleton."); 
    }
}

class Program
{
    static void Main()
    {
        // 'Instance' corrisponde al nome della proprietà nella classe
        var istanza1 = Singleton.Instance;
        istanza1.DoSomething();
    }
}