using System;

// 1. CLASSE BASE
public class Animale 
{ 
    // Usiamo 'virtual' per permettere alle classi figlie di cambiare il verso
    public virtual void Verso()
    {
        Console.WriteLine("L'animale emette un verso generico.");
    }

    public void Mangia()
    {
        Console.WriteLine("L'animale sta mangiando.");
    }
}

// 2. CLASSE DERIVATA (EREDITARIETÀ + OVERRIDE)
public class Cane : Animale
{
    // Usiamo 'override' per personalizzare il metodo della base
    public override void Verso()
    {
        // Chiamiamo il verso base e poi aggiungiamo il nostro
        base.Verso(); 
        Console.WriteLine("Il cane abbaia: Bau Bau!");
    }

    public void Scodinzola()
    {
        Console.WriteLine("Il cane scodinzola felice.");
    }
}

// 3. CLASSE DERIVATA (NASCONDIMENTO CON 'NEW')
public class Gatto : Animale
{
    // 'new' dice al computer: "Ignora il metodo Verso del padre, questo è uno nuovo"
    public new void Verso()
    {
        Console.WriteLine("Il gatto miagola: Miao!");
    }
}

// PROGRAMMA PRINCIPALE
public class Programma    
{
    public static void Main()
    {
        Console.WriteLine("--- TEST CANE ---");
        Cane mioCane = new Cane(); 
        mioCane.Mangia();    // Metodo ereditato (non modificato)
        mioCane.Verso();     // Metodo modificato con override + base
        mioCane.Scodinzola(); // Metodo specifico del cane

        Console.WriteLine("\n--- TEST GATTO ---");
        Gatto mioGatto = new Gatto();
        mioGatto.Mangia();   // Ereditato
        mioGatto.Verso();    // Metodo nuovo del gatto (new)
    }
}