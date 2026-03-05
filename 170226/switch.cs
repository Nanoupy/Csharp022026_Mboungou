using System;

class Program 
{
    static void Main(string[] args)
    {
        // 1. GIORNI DELLA SETTIMANA
        Console.WriteLine("--- ESERCIZIO 1: Giorni della Settimana ---");
        Console.Write("Inserisci un numero da 1 a 7: ");
        int giorno = int.Parse(Console.ReadLine());

        switch (giorno)
        {
            case 1:
                Console.WriteLine("Lunedì");
                break;
            case 2:
                Console.WriteLine("Martedì");
                break;
            case 3:
                Console.WriteLine("Mercoledì");
                break;
            case 4:
                Console.WriteLine("Giovedì");
                break;
            case 5:
                Console.WriteLine("Venerdì");
                break;
            case 6:
                Console.WriteLine("Sabato");
                break;
            case 7:
                Console.WriteLine("Domenica");
                break;
            default:
                Console.WriteLine("Errore: Il numero deve essere compreso tra 1 e 7.");
                break;
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 2. CALCOLO AREE GEOMETRICHE
        Console.WriteLine("--- ESERCIZIO 2: Calcolo Aree ---");
        Console.WriteLine("Scegli una figura (quadrato, cerchio, triangolo):");
        string figura = Console.ReadLine().ToLower(); // Convertiamo in minuscolo per sicurezza
        switch (figura)
        {
            case "quadrato":
                Console.Write("Inserisci il lato del quadrato: ");
                double lato = double.Parse(Console.ReadLine());
                double areaQuadrato = lato * lato;
                Console.WriteLine($"L'area del quadrato è: {areaQuadrato}");
                break;

            case "cerchio":
                Console.Write("Inserisci il raggio del cerchio: ");
                double raggio = double.Parse(Console.ReadLine());
                // Area = PI * r^2
                double areaCerchio = Math.PI * Math.Pow(raggio, 2);
                Console.WriteLine($"L'area del cerchio è: {areaCerchio:F2}");
                break;

            case "triangolo":
                Console.Write("Inserisci la base: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Inserisci l'altezza: ");
                double h = double.Parse(Console.ReadLine());
                double areaTriangolo = (b * h) / 2;
                Console.WriteLine($"L'area del triangolo è: {areaTriangolo}");
                break;

            default:
                Console.WriteLine("Figura non riconosciuta!");
                break;
        }

        Console.WriteLine("\nEsercizi terminati correttamente.");
    }
}