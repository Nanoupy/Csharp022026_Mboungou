using System;

public class Libro
{
    // Proprietà pubbliche
    public string Titolo;
    public string Autore;
    public int AnnoPubblicazione;

    // Costruttore 
    public Libro(string titolo, string autore, int anno)
    {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = anno;
    }

    // 1. Sovrascrittura di ToString()
    public override string ToString()
    {
        return $"\"{Titolo}\" di {Autore} ({AnnoPubblicazione})";
    }

    // 2. Sovrascrittura di Equals()
        public override bool Equals(object obj)
    {
        if (obj is Libro altroLibro)
        {
            return this.Titolo == altroLibro.Titolo && 
                   this.Autore == altroLibro.Autore;
        }
        return false;
    }

    // 3. Sovrascrittura di GetHashCode()
    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore);
    }
}

public class Programma
{
    public static void Main()
    {
        // 4. Creazione di due oggetti Libro con gli stessi valori
        Libro libro1 = new Libro("Il Signore degli Anelli", "J.R.R. Tolkien", 1954);
        Libro libro2 = new Libro("Il Signore degli Anelli", "J.R.R. Tolkien", 1954);

        // Verifica ToString()
        Console.WriteLine("Verifica ToString():");
        Console.WriteLine(libro1.ToString()); 

        // Verifica Equals()
        Console.WriteLine("\nVerifica Equals():");
        bool sonoUguali = libro1.Equals(libro2);
        Console.WriteLine("I due libri sono uguali? " + sonoUguali);

        // Verifica GetHashCode()
        Console.WriteLine("\nVerifica GetHashCode():");
        Console.WriteLine("Hash Libro 1: " + libro1.GetHashCode());
        Console.WriteLine("Hash Libro 2: " + libro2.GetHashCode());
        
        if (libro1.GetHashCode() == libro2.GetHashCode())
        {
            Console.WriteLine("Gli Hash sono identici!");
        }
    }
}