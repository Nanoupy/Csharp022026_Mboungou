// Classe astratta
public abstract class Veicolo
{
    public abstract void Avvia();
}

// Classe concreta che eredita dalla classe astratta
public class Auto : Veicolo
{
    public override void Avvia()
    {
        Console.WriteLine("L'auto si avvia con il motore.");
    }
}

// Interfaccia
public interface IVeicoloElettrico
{
    void CaricaBatteria();
}

// Classe che implementa l'interfaccia
public class ScooterElettrico : IVeicoloElettrico
{
    public void CaricaBatteria()
    {
        Console.WriteLine("La batteria dello scooter è in carica.");
    }
}

public class Programma
{
    public static void Main()
    {
        Veicolo miaAuto = new Auto();
        miaAuto.Avvia();

        IVeicoloElettrico mioScooter = new ScooterElettrico();
        mioScooter.CaricaBatteria();
    }
}