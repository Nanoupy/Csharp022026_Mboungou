using System;

class Program
{
    static void Main(string[] args)
    {
        bool ripetiProgramma = true;

        do
        {
            Console.Clear();
            Console.WriteLine("--- SISTEMA DI CREAZIONE ARRAY DINAMICO ---");
            Console.WriteLine("Quale tipo di dati vuoi inserire?");
            Console.WriteLine("1: Numeri Interi (int)");
            Console.WriteLine("2: Testo (string)");
            Console.Write("Scelta: ");
            string sceltaTipo = Console.ReadLine();

            Console.Write("\nQuanto deve essere lungo l'array? ");
            int lunghezza = int.Parse(Console.ReadLine());

            // Gestione della scelta tramite Switch
            switch (sceltaTipo)
            {
                case "1":
                    // Creazione e popolamento array di interi
                    int[] arrayInt = new int[lunghezza];
                    for (int i = 0; i < lunghezza; i++)
                    {
                        Console.Write($"Inserisci l'intero per la posizione [{i}]: ");
                        arrayInt[i] = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine("\n--- Output Array Interi ---");
                    foreach (int n in arrayInt)
                    {
                        Console.WriteLine($"Valore registrato: {n}");
                    }
                    break;

                case "2":
                    // Creazione e popolamento array di stringhe
                    string[] arrayString = new string[lunghezza];
                    for (int i = 0; i < lunghezza; i++)
                    {
                        Console.Write($"Inserisci il testo per la posizione [{i}]: ");
                        arrayString[i] = Console.ReadLine();
                    }

                    Console.WriteLine("\n--- Output Array Stringhe ---");
                    foreach (string s in arrayString)
                    {
                        Console.WriteLine($"Testo registrato: {s}");
                    }
                    break;

                default:
                    Console.WriteLine("Scelta non valida!");
                    break;
            }

            //ripetizione
            Console.Write("\nVuoi creare un altro array? (si/no): ");
            string risposta = Console.ReadLine().ToLower();
            if (risposta != "s")
            {
                ripetiProgramma = false;
                Console.WriteLine("Chiusura del programma. Arrivederci!");
            }

        } while (ripetiProgramma);
    }
}