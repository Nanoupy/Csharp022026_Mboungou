using System.Collections.Generic;

// la classe Film
public class Film
{
    public string Titolo;
    public string Regista;
    public int Anno;
    public string Genere;

    // Costruttore 
    public Film(string t, string r, int a, string g)
    {
        Titolo = t;
        Regista = r;
        Anno = a;
        Genere = g;
    }
}

class Program
{
    static void Main()
    {
                List<Film> videoteca = new List<Film>();

        Console.WriteLine("--- BENVENUTO NELLA VIDEOTECA DIGITALE ---");

        // 1. Inserimento di almeno 3 film
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\nInserimento film numero " + (i + 1) + ":");
            Console.Write("Titolo: ");
            string tit = Console.ReadLine();
            Console.Write("Regista: ");
            string reg = Console.ReadLine();
            Console.Write("Anno di uscita: ");
            int ann = int.Parse(Console.ReadLine());
            Console.Write("Genere: ");
            string gen = Console.ReadLine();

            // creo l'oggetto film e lo aggiungo alla lista
            Film nuovoFilm = new Film(tit, reg, ann, gen);
            videoteca.Add(nuovoFilm);
        }

        // 2. Stampo tutti i film inseriti
        Console.WriteLine("\n--- ELENCO COMPLETO DEI FILM ---");
        foreach (Film f in videoteca)
        {
            Console.WriteLine("Titolo: " + f.Titolo + " | Regista: " + f.Regista + " (" + f.Anno + ") | Genere: " + f.Genere);
        }

        // 3. Ricerca per genere
        Console.Write("\nInserisci un genere per filtrare i film: ");
        string genereCercato = Console.ReadLine();
        Console.WriteLine("\nFilm trovati per il genere '" + genereCercato + "':");
        bool trovato = false;
        foreach (Film f in videoteca)
        {
            // uso Equals per confrontare le stringhe
            if (f.Genere.ToLower() == genereCercato.ToLower())
            {
                Console.WriteLine("- " + f.Titolo + " di " + f.Regista);
                trovato = true;
            }
        }
        if (trovato == false)
        {
            Console.WriteLine("Nessun film trovato per questo genere.");
        }

        Console.WriteLine("\nPremi un tasto per uscire...");
        Console.ReadKey();
    }
}