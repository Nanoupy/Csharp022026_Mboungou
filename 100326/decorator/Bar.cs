using System;
namespace BarSistema;
//bar software
public interface IBevanda
{
    string Descrizione();
    double Costo();
}
// componenti concretti
public class Caffe : IBevanda
{
    public string Descrizione() => "Caffè";
    public double Costo() => 1.50;
}
public class Te : IBevanda
{
    public string Descrizione() => "Tè";
    public double Costo() => 2.00;
}
//  decoratori astratti 
public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda _bevanda;
    protected DecoratoreBevanda(IBevanda bevanda)
    {
        _bevanda = bevanda;
    }
    public virtual string Descrizione() => _bevanda.Descrizione();
    public virtual double Costo() => _bevanda.Costo();
}
// decoratori concreti
public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione() => base.Descrizione() + ", con Latte";
    public override double Costo() => base.Costo() + 0.50;
}
public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) { }

    public override string Descrizione() => base.Descrizione() + ", con Cioccolato";
    public override double Costo() => base.Costo() + 0.70;
}
public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() => base.Descrizione() + ", con Panna";
    public override double Costo() => base.Costo() + 0.60;
}
class Program
{
    static void Main()
    {
        Console.WriteLine("=== BENVENUTI AL BAR DESIGN PATTERN ===\n");
        //ordiniamo un Caffè semplice
        IBevanda ordine1 = new Caffe();
        Console.WriteLine($"Ordine 1: {ordine1.Descrizione()} | Costo: €{ordine1.Costo():F2}");
        // ordiniamo un Caffè con Latte e Panna 
        IBevanda ordine2 = new Caffe();
        ordine2 = new ConLatte(ordine2);  
        ordine2 = new ConPanna(ordine2); 
        Console.WriteLine($"Ordine 2: {ordine2.Descrizione()} | Costo: €{ordine2.Costo():F2}");
        //ordiniamo un Tè con Cioccolato e Latte 
        IBevanda ordine3 = new Te();
        ordine3 = new ConCioccolato(ordine3);
        ordine3 = new ConLatte(ordine3);
        Console.WriteLine($"Ordine 3: {ordine3.Descrizione()} | Costo: €{ordine3.Costo():F2}");
        Console.WriteLine("\nGrazie e arrivederci!");
    }
}