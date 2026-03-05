using System;

public class VoloAereo
{
    private int postiOccupati;
    public const int maxPosti = 150;
    public string CodiceVolo { get; set; }

    // 4. Proprietà in sola lettura (restituisce il valore del campo privato)
    public int PostiOccupati
    {
        get { return postiOccupati; }
    }
    // 5. Proprietà in sola lettura calcolata al volo
    public int PostiLiberi
    {
        get { return maxPosti - postiOccupati; }
    }
    public VoloAereo(string codice)
    {
        CodiceVolo = codice;
        postiOccupati = 0;
    }
    // 6. Metodo per prenotare
    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti <= PostiLiberi)
        {
            postiOccupati += numeroPosti;
            Console.WriteLine("Prenotazione effettuata: " + numeroPosti + " posti.");
        }
        else
        {
            Console.WriteLine("Errore: Non ci sono abbastanza posti liberi!");
        }
    }
    // 7. Metodo per annullare
    public void AnnullaPrenotazione(int numeroPosti)
    {
        if (numeroPosti > 0 && numeroPosti <= postiOccupati)
        {
            postiOccupati -= numeroPosti;
            Console.WriteLine("Annullamento effettuato: " + numeroPosti + " posti.");
        }
        else
        {
            Console.WriteLine("Errore: Numero di posti da annullare non valido.");
        }
    }

    // 8. mostro lo stato
    public void VisualizzaStato()
    {
        Console.WriteLine("\n--- STATO VOLO " + CodiceVolo + " ---");
        Console.WriteLine("Posti Occupati: " + PostiOccupati);
        Console.WriteLine("Posti Liberi: " + PostiLiberi);
        Console.WriteLine("Capienza Massima: " + maxPosti);
        Console.WriteLine("---------------------------\n");
    }
}

class Program
{
    static void Main()
    {
        // Creazione oggetto
        VoloAereo mioVolo = new VoloAereo("AZ123");
        mioVolo.VisualizzaStato();
        mioVolo.EffettuaPrenotazione(50);
        mioVolo.VisualizzaStato();
        mioVolo.EffettuaPrenotazione(120);
        mioVolo.VisualizzaStato();
        mioVolo.AnnullaPrenotazione(20);
        mioVolo.VisualizzaStato();
        mioVolo.AnnullaPrenotazione(100);
        mioVolo.VisualizzaStato();
        
        Console.ReadLine();
    }
}