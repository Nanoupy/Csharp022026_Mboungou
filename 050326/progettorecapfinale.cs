using System;
using System.Collections.Generic;
// 1.incapsulamento: Protezione dei dati sensibili
public class Persona
{
    private string nome;
    private string badgeId;
    // proprietà per accedere ai campi privati
    public string Nome { get => nome; set => nome = value; }
    public string BadgeId { get => badgeId; } 
    public Persona(string nome, string bId)
    {
        this.nome = nome;
        this.badgeId = bId;
    }
}
// 2. astrazione
public abstract class PermessoAccesso
{
    // Metodo astratto: ogni figlio DEVE decidere le sue regole di orario
    public abstract bool PuoEntrare(int ora);
    // Metodo virtuale: comportamento base sovrascrivibile
    public virtual void InfoRuolo() => Console.Write("Ruolo: ");
}
// 3. ereditarietà: Specializzazione dei ruoli
public class PermessoDipendente : PermessoAccesso
{
    // il dipendente entra solo tra le 08:00 e le 18:00
    public override bool PuoEntrare(int ora) => ora >= 8 && ora <= 18;
    public override void InfoRuolo()
    {
        base.InfoRuolo();
        Console.WriteLine("DIPENDENTE (Ufficio standard)");
    }
}
public class PermessoManager : PermessoAccesso
{
    // il manager ha un accesso totale h24
    public override bool PuoEntrare(int ora) => true;
    public override void InfoRuolo()
    {
        base.InfoRuolo();
        Console.WriteLine("MANAGER (Accesso Dirigenziale)");
    }
}
// gestore: Logica di coordinamento
public class GestoreAccessi
{
    public void ValidaIngresso(Persona p, PermessoAccesso permesso, int ora)
    {
        Console.WriteLine($"--- Analisi Badge {p.BadgeId} ---");
        permesso.InfoRuolo();
        if (permesso.PuoEntrare(ora))
            Console.WriteLine($">> ESITO: Benvenuto {p.Nome}. Entrata consentita.");
        else
            Console.WriteLine($">> ESITO: Spiacenti {p.Nome}. Accesso negato (fuori orario).");
           Console.WriteLine("----------------------------------\n");
    }
}
// 4. polimorfismo
class Program
{
    static void Main()
    {
        GestoreAccessi sistema = new GestoreAccessi();
        // simuliamo l'ora del tentativo di ingresso per le ore 22:00
        int oraAttuale = 22;
        // Creazione oggetti
        Persona dip = new Persona("Exaucee Nahira", "B013");
        Persona man = new Persona("Mathieu Kevin", "M999");
        // polimorfismo: usiamo riferimenti della classe base permessoAccesso
        PermessoAccesso perm1 = new PermessoDipendente();
        PermessoAccesso perm2 = new PermessoManager();
        Console.WriteLine($"LOG SICUREZZA AZIENDALE - ORE {oraAttuale}:00");
        Console.WriteLine("============================================\n");
        // esecuzione dei controlli
        sistema.ValidaIngresso(dip, perm1, oraAttuale); 
        sistema.ValidaIngresso(man, perm2, oraAttuale); 

        Console.WriteLine("Premi un tasto per chiudere il terminale...");
        Console.ReadKey();
    }
}