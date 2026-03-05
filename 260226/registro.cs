using System;
using System.Collections.Generic;
using System.Linq;

class RegistroScolastico
{
    // 1. DICHIARAZIONE STRUTTURE DATI
    static string[] studenti = { "Anna", "Luca", "Maya", "Rami", "Zoe" };
    static string[] materie = { "Matematica", "Italiano", "Inglese", "Storia" };
    
    // Matrice voti: Righe = Studenti, Colonne = Materie
    static int[,] voti = new int[studenti.Length, materie.Length];
    
    // Liste per dati dinamici
    static List<string>[] notePerStudente = new List<string>[studenti.Length];
    static List<string> logOperazioni = new List<string>();
    static List<string> ricercheRecenti = new List<string>();

    static void Main()
    {
        InizializzaDati();
        string scelta = "";

        while (scelta != "0")
        {
            Console.WriteLine("\n=== GESTIONALE SCUOLA 2.0 ===");
            Console.WriteLine("1. Visualizza Registro");
            Console.WriteLine("2. Inserisci/Aggiorna Voto");
            Console.WriteLine("3. Statistiche (Medie e Max/Min)");
            Console.WriteLine("4. Gestione Note");
            Console.WriteLine("5. Ricerca Studente o Media");
            Console.WriteLine("6. Borse di Studio (Extra)");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'opzione: ");
            scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1": VisualizzaRegistro(); RegistraLog("Visualizzazione registro"); break;
                case "2": AggiornaVoto(); break;
                case "3": StampaStatistiche(); RegistraLog("Calcolo statistiche"); break;
                case "4": GestisciNote(); break;
                case "5": RicercaSoglia(); break;
                case "6": FiltraBorseStudio(); break;
            }
        }
    }

    // --- FUNZIONALITÀ ---

    static void InizializzaDati()
    {
        Random rnd = new Random();
        for (int i = 0; i < studenti.Length; i++)
        {
            notePerStudente[i] = new List<string>(); // Inizializzo le liste per ogni studente
            for (int j = 0; j < materie.Length; j++)
            {
                voti[i, j] = rnd.Next(1, 11); // Voti casuali 1-10
            }
        }
    }

    static void VisualizzaRegistro()
    {
        Console.Write("\t\t");
        foreach (var m in materie) Console.Write(m + "\t");
        Console.WriteLine("\n------------------------------------------------------------");

        for (int i = 0; i < studenti.Length; i++)
        {
            Console.Write(studenti[i] + "\t\t");
            for (int j = 0; j < materie.Length; j++)
            {
                Console.Write(voti[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void AggiornaVoto()
    {
        Console.Write("Inserisci indice studente (0-4): ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Inserisci indice materia (0-3): ");
        int m = int.Parse(Console.ReadLine());

        if (s >= 0 && s < studenti.Length && m >= 0 && m < materie.Length)
        {
            Console.Write($"Nuovo voto per {studenti[s]} in {materie[m]}: ");
            int nuovoVoto = int.Parse(Console.ReadLine());
            voti[s, m] = nuovoVoto;
            RegistraLog($"Aggiornato voto: {studenti[s]}, {materie[m]} -> {nuovoVoto}");
        }
        else Console.WriteLine("Errore: Indici non validi!");
    }

    static void StampaStatistiche()
    {
        // Media per studente (RIGA)
        for (int i = 0; i < studenti.Length; i++)
        {
            double somma = 0;
            for (int j = 0; j < materie.Length; j++) somma += voti[i, j];
            Console.WriteLine($"Media {studenti[i]}: {somma / materie.Length:F2}");
        }
    }

    static void RegistraLog(string azione)
    {
        logOperazioni.Add($"{DateTime.Now:HH:mm:ss} - {azione}");
        if (logOperazioni.Count > 10) logOperazioni.RemoveAt(0); // Mantieni solo gli ultimi 10
    }

    static void FiltraBorseStudio()
    {
        Console.WriteLine("\nCandidati Borsa di Studio (Media >= 8 e zero insufficienze):");
        for (int i = 0; i < studenti.Length; i++)
        {
            double somma = 0;
            bool haInsufficienze = false;
            for (int j = 0; j < materie.Length; j++)
            {
                somma += voti[i, j];
                if (voti[i, j] < 6) haInsufficienze = true;
            }
            double media = somma / materie.Length;
            if (media >= 8 && !haInsufficienze)
                Console.WriteLine($"- {studenti[i]} (Media: {media:F2})");
        }
    }

    static void GestisciNote()
    {
        Console.Write("Inserisci indice studente per aggiungere nota: ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Contenuto nota: ");
        string nota = Console.ReadLine();
        notePerStudente[s].Add(nota);
        RegistraLog($"Nota aggiunta a {studenti[s]}");
    }

    static void RicercaSoglia()
    {
        Console.Write("Mostra studenti con media maggiore o uguale a: ");
        double soglia = double.Parse(Console.ReadLine());
        
        // Salviamo la ricerca nei recenti
        ricercheRecenti.Add("Soglia media " + soglia);
        if (ricercheRecenti.Count > 5) ricercheRecenti.RemoveAt(0);

        for (int i = 0; i < studenti.Length; i++)
        {
            double somma = 0;
            for (int j = 0; j < materie.Length; j++) somma += voti[i, j];
            if ((somma / materie.Length) >= soglia)
                Console.WriteLine($"- {studenti[i]} ha superato la soglia!");
        }
    }
} 