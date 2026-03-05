using System;
public class ContoBancario
{
//campo privato (non accessibile direttamente dall'esterno)
private double Saldo
{
    get { return saldo;} //solo valori validi
    set
    {
        if(value >= 0) // solo valori validi
            saldo = value;
    }
}
}
public class Programma
{
    public static void Main()
    {
        ContoBancario conto = new ContoBancario();
        conto.Saldo = 1000.50; // imposta il saldo tramite la proprietà
        Console.writeLine(conto.Saldo); // legge il saldo tramite la proprietà

        conto.Saldo = -500;  // non modifica il saldo che è negativo 
        Console.WriteLine(conto.Saldo); // rimane 1000.50
    }
}