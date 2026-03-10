using System;
using System.Collections.Generic;
namespace UserSystem;
//factory
public class Utente
{
    public string Nome { get; set; }
    public override string ToString() => $"[Profilo Utente: {Nome}]";
}
public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente { Nome = nome };
    }
}
// interfacce
public interface IObserver
{
    void NotificaCreazione(string nomeUtente);
}
public interface ISoggetto
{
    void Registra(IObserver o);
    void Rimuovi(IObserver o);
    void Notifica(string nomeUtente);
}
// soggetto
public class GestoreCreazioneUtente : ISoggetto
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    public void Registra(IObserver o)
    {
        if (!_observers.Contains(o))
        {
            _observers.Add(o);
            Console.WriteLine("Sistema: Modulo registrato correttamente.");
        }
    }
    public void Rimuovi(IObserver o)
    {
        if (_observers.Contains(o))
        {
            _observers.Remove(o);
            Console.WriteLine("Sistema: Modulo rimosso.");
        }
    }
    public void Notifica(string nomeUtente)
    {
        foreach (var observer in _observers)
        {
            observer.NotificaCreazione(nomeUtente);
        }
    }
    public void CreaUtente(string nome)
    {
        Utente nuovoUtente = UserFactory.Crea(nome);
        Console.WriteLine($"\n[DATABASE]: Salvataggio di {nuovoUtente}...");
        Notifica(nome);
    }
}
// osservatori
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente) =>
        Console.WriteLine($"   > [LOG]: Registrata creazione per '{nomeUtente}'");
}
public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente) =>
        Console.WriteLine($"   > [MARKETING]: Email di benvenuto inviata a '{nomeUtente}'");
}
class Program
{
    static void Main()
    {
        GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
        // istanze degli osservatori
        IObserver log = new ModuloLog();
        IObserver marketing = new ModuloMarketing();
        // registrazione iniziale predefinita
        gestore.Registra(log);
        gestore.Registra(marketing);

        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n========== MENU GESTIONE UTENTI ==========");
            Console.WriteLine("1. Crea nuovo Utente");
            Console.WriteLine("2. Disattiva Modulo LOG");
            Console.WriteLine("3. Attiva Modulo LOG");
            Console.WriteLine("4. Disattiva Modulo MARKETING");
            Console.WriteLine("5. Attiva Modulo MARKETING");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci il nome dell'utente: ");
                    string nome = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(nome))
                        gestore.CreaUtente(nome);
                    else
                        Console.WriteLine("Errore: Il nome non può essere vuoto.");
                    break;
                case "2":
                    gestore.Rimuovi(log);
                    break;
                case "3":
                    gestore.Registra(log);
                    break;
                case "4":
                    gestore.Rimuovi(marketing);
                    break;
                case "5":
                    gestore.Registra(marketing);
                    break;

                case "0":
                    continua = false;
                    Console.WriteLine("Chiusura in corso...");
                    break;
                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }
        }
    }
}