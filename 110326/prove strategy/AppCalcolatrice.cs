using System;
namespace CalcolatriceStrategy;
public interface IStrategiaOperazione
{
    double Calcola(double a, double b);
}
// strategia
public class SommaStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b) => a + b;
}
public class SottrazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b) => a - b;
}
public class MoltiplicazioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b) => a * b;
}
public class DivisioneStrategia : IStrategiaOperazione
{
    public double Calcola(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Errore: Divisione per zero!");
            return 0;
        }
        return a / b;
    }
}
public class Calcolatrice
{
    private IStrategiaOperazione _strategia;
// cambio comportamento
    public void ImpostaStrategia(IStrategiaOperazione nuovaStrategia)
    {
        _strategia = nuovaStrategia;
    }
    // delega
    public void EseguiOperazione(double a, double b)
    {
        if (_strategia == null)
        {
            Console.WriteLine("Errore: Nessuna operazione selezionata.");
            return;
        }
        double risultato = _strategia.Calcola(a, b);
        Console.WriteLine($"Il risultato è: {risultato}");
    }
}
class Program
{
    static void Main()
    {
        Calcolatrice miaCalcolatrice = new Calcolatrice();
        Console.WriteLine("=== Calcolatrice Strategy Pattern ===");
        // input 
        Console.Write("Inserisci il primo numero: ");
        double n1 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Inserisci il secondo numero: ");
        double n2 = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("\nScegli l'operazione:");
        Console.WriteLine("1. Somma (+)");
        Console.WriteLine("2. Sottrazione (-)");
        Console.WriteLine("3. Moltiplicazione (*)");
        Console.WriteLine("4. Divisione (/)");
        Console.Write("Scelta: ");
        string scelta = Console.ReadLine();
        switch (scelta)
        {
            case "1":
                miaCalcolatrice.ImpostaStrategia(new SommaStrategia());
                break;
            case "2":
                miaCalcolatrice.ImpostaStrategia(new SottrazioneStrategia());
                break;
            case "3":
                miaCalcolatrice.ImpostaStrategia(new MoltiplicazioneStrategia());
                break;
            case "4":
                miaCalcolatrice.ImpostaStrategia(new DivisioneStrategia());
                break;
            default:
                Console.WriteLine("Opzione non valida.");
                return;
        }
        miaCalcolatrice.EseguiOperazione(n1, n2);
    }
}