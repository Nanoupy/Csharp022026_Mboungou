//classe studente 
using System;

public class Studente
{    public string Nome;
    public int Matricola;
    public double MediaVoti;
}

public class Programma
{
    public static void Main()
    {
        // creo due oggetti Studente
        Studente s1 = new Studente();
        Studente s2 = new Studente();

        // 2. Assegno valori alle proprietà
        s1.Nome = "Marco";
        s1.Matricola = 10234;
        s1.MediaVoti = 28.5;

        s2.Nome = "Sofia";
        s2.Matricola = 10235;
        s2.MediaVoti = 29.2;

        // 3. Stampo le informazioni
        Console.WriteLine($"Studente 1: {s1.Nome}, Matricola: {s1.Matricola}, Media: {s1.MediaVoti}");
        Console.WriteLine($"Studente 2: {s2.Nome}, Matricola: {s2.Matricola}, Media: {s2.MediaVoti}");
    }
}