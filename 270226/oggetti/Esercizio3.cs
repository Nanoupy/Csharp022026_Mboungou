//classe operazione 
using System;

public class Operazioni
{
    public int Somma(int a, int b)
    {
        return a + b;
    }
    public int Moltiplica(int a, int b)
    {
        return a * b;
    }

    public void StampaRisultato(string operazione, int risultato)
    {
        Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
    }
}

public class Programma
{
    public static void Main()
    {
        // 1. Creo un oggetto Operazioni
        Operazioni op = new Operazioni();

        // 2. Chiedo input all'utente
        Console.Write("Inserisci il primo numero: ");
        int n1 = int.Parse(Console.ReadLine());
        
        Console.Write("Inserisci il secondo numero: ");
        int n2 = int.Parse(Console.ReadLine());

        // 3. Calcolo e stampo usando i metodi dell'oggetto
        int risSomma = op.Somma(n1, n2);
        op.StampaRisultato("Somma", risSomma);

        int risMoltiplica = op.Moltiplica(n1, n2);
        op.StampaRisultato("Moltiplica", risMoltiplica);
    }
} 