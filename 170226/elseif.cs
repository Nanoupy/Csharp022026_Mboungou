using System;

class Program 
{
    static void Main(string[] args)
    {
        // 1. VALUTAZIONE VOTO (da 1 a 10)
        Console.WriteLine("--- ESERCIZIO 1: Valutazione Voto ---");
        Console.Write("Inserisci un voto (1-10): ");
        int voto = int.Parse(Console.ReadLine());

        if (voto >= 1 && voto <= 4)
        {
            Console.WriteLine("Valutazione: Insufficiente");
        }
        else if (voto == 5 || voto == 6)
        {
            Console.WriteLine("Valutazione: Sufficiente");
        }
        else if (voto == 7 || voto == 8)
        {
            Console.WriteLine("Valutazione: Buono");
        }
        else if (voto == 9 || voto == 10)
        {
            Console.WriteLine("Valutazione: Ottimo");
        }
        else
        {
            Console.WriteLine("Voto non valido! Inserisci un numero tra 1 e 10.");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 2. CALCOLO BMI (Body Mass Index)
        Console.WriteLine("--- ESERCIZIO 2: Calcolo BMI ---");
        Console.Write("Inserisci il tuo peso (kg): ");
        double peso = double.Parse(Console.ReadLine());
        Console.Write("Inserisci la tua altezza (metri, es: 1,75): ");
        double altezza = double.Parse(Console.ReadLine());
        //peso / (altezza * altezza)
        double bmi = peso / Math.Pow(altezza, 2);
        Console.WriteLine($"Il tuo BMI è: {bmi:F2}");
        if (bmi < 18.5)
        {
            Console.WriteLine("Categoria: Sottopeso");
        }
        else if (bmi >= 18.5 && bmi < 25)
        {
            Console.WriteLine("Categoria: Normopeso");
        }
        else if (bmi >= 25 && bmi < 30)
        {
            Console.WriteLine("Categoria: Sovrappeso");
        }
        else
        {
            Console.WriteLine("Categoria: Obesità");
        }

        Console.WriteLine("\n" + new string('-', 30) + "\n");

        // 3. CONVERTITORE TEMPERATURE (Celsius verso Altre Scale)
        Console.WriteLine("--- ESERCIZIO 3: Convertitore Celsius ---");
        Console.Write("Inserisci la temperatura in Celsius: ");
        double celsius = double.Parse(Console.ReadLine());
        Console.WriteLine("Scegli la scala di destinazione (F = Fahrenheit, K = Kelvin, R = Rankine): ");
        string scelta = Console.ReadLine().ToUpper(); // Converte l'input in maiuscolo
        double tempConvertita = 0;
        if (scelta == "F")
        {
            tempConvertita = (celsius * 9 / 5) + 32;
            Console.WriteLine($"{celsius}°C corrispondono a {tempConvertita:F2}°F");
        }
        else if (scelta == "K")
        {
            tempConvertita = celsius + 273.15;
            Console.WriteLine($"{celsius}°C corrispondono a {tempConvertita:F2}K");
        }
        else if (scelta == "R")
        {
            tempConvertita = (celsius + 273.15) * 9 / 5;
            Console.WriteLine($"{celsius}°C corrispondono a {tempConvertita:F2}°R");
        }
        else
        {
            Console.WriteLine("Scelta non valida!");
        }

        Console.WriteLine("\nEsercizi completati!");
    }
}