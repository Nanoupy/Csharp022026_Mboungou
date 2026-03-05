using System;

public class PrenotazioneViaggio
{
    // 1. Campo privato
    private int postiPrenotati;
    // costante
    public const int maxPosti = 20;
    // 2. Proprietà pubblica automatica 
    public string Destinazione { get; set; }
    // 3. lettura per vedere i posti prenotati
    public int PostiPrenotati
    {
        get { return postiPrenotati; }
    }

    // 4. proprietà calcolata sola lettura
    public int PostiDisponibili
    {
        get { return maxPosti - postiPrenotati; }
    }
    // costruttore
    public PrenotazioneViaggio(string destinazione)
    {
        Destinazione = destinazione;
        postiPrenotati = 0; //
    }

    // 5. metodo per prenotare con controllo di sicurezza
    public void PrenotaPosti(int numero)
    {
        if (numero > 0 && numero <= PostiDisponibili)
        {
            postiPrenotati += numero;
            Console.WriteLine($"OK: Prenotati {numero} posti per {Destinazione}.");
        }
        else
        {
            Console.WriteLine($"ERRORE: Impossibile prenotare {numero} posti. Disponibili: {PostiDisponibili}");
        }
    }
    // metodo per annullare
    public void AnnullaPrenotazione(int numero)
    {
        if (numero > 0 && numero <= postiPrenotati)
        {
            postiPrenotati -= numero;
            Console.WriteLine($"OK: Annullati {numero} posti.");
        }
        else
        {
            Console.WriteLine("ERRORE: Numero di posti da annullare non valido.");
        }
    }
}

class Program
{
    static void Main()
    {
        // creazione oggetto
        PrenotazioneViaggio viaggio = new PrenotazioneViaggio("Tokyo");
        Console.WriteLine($"--- Viaggio per {viaggio.Destinazione} (Max posti: {PrenotazioneViaggio.maxPosti}) ---");

        // prenotazione valida
        viaggio.PrenotaPosti(12);
        StampaSituazione(viaggio);

        // prenotazione eccessiva (supera i 20 totali)
        viaggio.PrenotaPosti(10);
        StampaSituazione(viaggio);

        // annullamento valido
        viaggio.AnnullaPrenotazione(5);
        StampaSituazione(viaggio);

        // annullamento impossibile
        viaggio.AnnullaPrenotazione(20);
        StampaSituazione(viaggio);

        Console.ReadLine();
    }
    static void StampaSituazione(PrenotazioneViaggio v)
    {
        Console.WriteLine($"Stato: Prenotati {v.PostiPrenotati} | Disponibili {v.PostiDisponibili}\n");
    }
}