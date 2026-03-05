//classe persona 
using System;

public class Persona
{
    public string Nome;
    public string Cognome;
    public int AnnoNascita;
}

public class Programma
{
    public static void Main()
    {
        // 1. Creo due oggetti
        Persona p1 = new Persona();
        Persona p2 = new Persona();

        // 2. Assegno manualmente i valori
        p1.Nome = "Mario";
        p1.Cognome = "Rossi";
        p1.AnnoNascita = 1985;

        p2.Nome = "Luca";
        p2.Cognome = "Verdi";
        p2.AnnoNascita = 1992;

        // 3. Stampo 
        Console.WriteLine($"{p1.Nome} {p1.Cognome} è nato nel {p1.AnnoNascita}");
        Console.WriteLine($"{p2.Nome} {p2.Cognome} è nato nel {p2.AnnoNascita}");
    }
}