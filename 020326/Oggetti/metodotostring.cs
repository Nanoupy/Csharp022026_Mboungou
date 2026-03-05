using System;

public class Persona
{
    // 1. Proprietà
    public string Nome;
    public string Cognome;
    public int AnnoNascita;

    // 2. Metodo ToString (Deve stare dentro la classe Persona)
    public override string ToString()
    {
        return $"{Nome} {Cognome}, nato nel {AnnoNascita}";
    }

    // 3. Metodo Equals (Deve stare dentro la classe Persona)
    public override bool Equals(object obj)
    {
        // Controlliamo se obj è nullo o non è una Persona
        if (obj == null || !(obj is Persona))
        {
            return false;
        }

        Persona altra = (Persona)obj;
        return this.Nome == altra.Nome && 
               this.Cognome == altra.Cognome && 
               this.AnnoNascita == altra.AnnoNascita;
    }

    // Nota: quando si sovrascrive Equals, è buona norma sovrascrivere anche GetHashCode
    public override int GetHashCode()
    {
        return HashCode.Combine(Nome, Cognome, AnnoNascita);
    }
}

public class Programma
{
    public static void Main()
    {
        // Creazione primo oggetto
        Persona p1 = new Persona();
        p1.Nome = "Mario";
        p1.Cognome = "Rossi";
        p1.AnnoNascita = 1985;

        // Creazione secondo oggetto (identico al primo)
        Persona p2 = new Persona();
        p2.Nome = "Mario";
        p2.Cognome = "Rossi";
        p2.AnnoNascita = 1985;

        // TEST 1: ToString()
        // Quando scrivi p1 in un Console.WriteLine, C# chiama automaticamente il tuo ToString()
        Console.WriteLine("Dati Persona 1: " + p1); 

        // TEST 2: Equals()
        if (p1.Equals(p2))
        {
            Console.WriteLine("Il contenuto è uguale!");
        }
        else
        {
            Console.WriteLine("Il contenuto è diverso.");
        }
    }
}