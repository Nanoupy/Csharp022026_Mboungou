using System;
using System.Collections.Generic;
//fabbrica con resgitro centralizzato , qui vanno usati Singleton & Factory method 
// interfaccia
public interface IVeicolo
{
    void Avvia();
    void MostraTipo();
}
//classi
public class Auto : IVeicolo
{
    public void Avvia() => Console.WriteLine("L'auto accende il motore: Brummmmmmmmm!");
    public void MostraTipo() => Console.WriteLine("Tipo: AUTO");
}
public class Moto : IVeicolo
{
    public void Avvia() => Console.WriteLine("La moto sgasca: Vrooooooom!");
    public void MostraTipo() => Console.WriteLine("Tipo: MOTO");
}
public class Camion : IVeicolo
{
    public void Avvia() => Console.WriteLine("Il camion parte lentamente: Roarrrrrrrrrrr!");
    public void MostraTipo() => Console.WriteLine("Tipo: CAMION");
}
// Singleton per il RegistroVeicoli
public class RegistroVeicoli
{
    private static RegistroVeicoli _istanza;
    private List<IVeicolo> listaVeicoli = new List<IVeicolo>();
    private RegistroVeicoli() { } // costruttore privato
    public static RegistroVeicoli Istanza
    {
        get
        {
            if (_istanza == null) _istanza = new RegistroVeicoli();
            return _istanza;
        }
    }
    public void Registra(IVeicolo v)
    {
        listaVeicoli.Add(v);
        Console.WriteLine("[Registrp] Veicolo aggiunto correttamente.");
    }
    public void StampaTutti()
    {
        Console.WriteLine("\n--- Elenco dei veicoli presente nel registro ---");
        foreach (var v in listaVeicoli)
        {
            v.MostraTipo();
        }
        Console.WriteLine("----------------------------------\n");
    }
}
// Factory Method per VeicoloFactory
public static class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        switch (tipo)
        {
            case "1": return new Auto();
            case "2": return new Moto();
            case "3": return new Camion();
            default: return null;
        }
    }
}
class Program
{
    static void Main()
    {
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("Scegli un veicolo da creare:");
            Console.WriteLine("1. Auto | 2. Moto | 3. Camion | 0. Esci e Stampa");
            string scelta = Console.ReadLine();
            if (scelta == "0")
            {
                continua = false;
            }
            else
            {
                // la Factory crea il veicolo
                IVeicolo nuovoVeicolo = VeicoloFactory.CreaVeicolo(scelta);
                if (nuovoVeicolo != null)
                {
                    // Il Singleton lo registra
                    RegistroVeicoli.Istanza.Registra(nuovoVeicolo);
                    
                    // Usiamo il veicolo appena creato
                    nuovoVeicolo.Avvia();
                }
                else
                {
                    Console.WriteLine("Scelta non valida!");
                }
            }
        }
        // step finale stampiamo tutto quello che abbiamo creato durante la sessione
        RegistroVeicoli.Istanza.StampaTutti();
    }
}