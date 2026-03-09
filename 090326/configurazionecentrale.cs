using System;
using System.Collections.Generic;
public sealed class ConfigurazioneSistema
{
    // istanza statica
    private static ConfigurazioneSistema _instance;
    private static readonly object _lock = new object();
    private Dictionary<string, string> impostazioni;
    // costruttore privato
    private ConfigurazioneSistema()
    {
        impostazioni = new Dictionary<string, string>();
        Console.WriteLine("[SISTEMA] Dizionario di configurazione creato.");
    }
    // proprietà per accedere all'istanza
    public static ConfigurazioneSistema Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ConfigurazioneSistema();
                }
                return _instance;
            }
        }
    }
    public void Imposta(string chiave, string valore)
    {
        if (impostazioni.ContainsKey(chiave))
        {
            impostazioni[chiave] = valore; // aggiorna se esiste già
        }
        else
        {
            impostazioni.Add(chiave, valore); // aggiunge
        }
    }
    // letura config
    public string Leggi(string chiave)
    {
        if (impostazioni.ContainsKey(chiave))
        {
            return impostazioni[chiave];
        }
        return "Chiave non trovata!";
    }
    // stampo il contenuto
    public void StampaTutte()
    {
        Console.WriteLine("\n--- ELENCO CONFIGURAZIONI ATTUALI ---");
        foreach (var coppia in impostazioni)
        {
            Console.WriteLine("Chiave: " + coppia.Key + " | Valore: " + coppia.Value);
        }
    }
}
class ModuloA
{
    public void Avvia()
    {
        ConfigurazioneSistema.Instance.Imposta("Lingua", "Italiano");
        Console.WriteLine("ModuloA: Lingua impostata su Italiano.");
    }
}
class ModuloB
{
    public void Avvia()
    {
        // Accede allo STESSO Singleton per impostare il Tema
        ConfigurazioneSistema.Instance.Imposta("Tema", "Scuro");
        Console.WriteLine("ModuloB: Tema impostato su Scuro.");
    }
}
class Program
{
    static void Main()
    {
        //creo i due moduli
        ModuloA modA = new ModuloA();
        ModuloB modB = new ModuloB();
         // faccio partire i moduli
        modA.Avvia();
        modB.Avvia();
        // verifico che i dati siano tutti nello stesso posto
        ConfigurazioneSistema config = ConfigurazioneSistema.Instance;
        Console.WriteLine("\nVerifica lettura dal Main:");
        Console.WriteLine("Lingua letta: " + config.Leggi("Lingua"));
        Console.WriteLine("Tema letto: " + config.Leggi("Tema"));
        // stampa finale di controllo
        config.StampaTutte();
        // controllo finale di identità
        Console.WriteLine("\nIl sistema sta usando un'unica istanza? " + (config == ConfigurazioneSistema.Instance));
    }
}