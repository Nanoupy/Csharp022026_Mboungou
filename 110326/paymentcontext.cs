using System;
namespace SistemaPagamenti;
public interface IPaymentStrategy
{
    void Pay(decimal amount);
}
//strategy
public class CreditCardPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => 
        Console.WriteLine($"Pagamento di {amount:C} completato con Carta di Credito.");
}
public class PayPalPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => 
        Console.WriteLine($"Pagamento di {amount:C} completato tramite PayPal.");
}
public class BitcoinPayment : IPaymentStrategy
{
    public void Pay(decimal amount) => 
        Console.WriteLine($"Pagamento di {amount:C} completato in Bitcoin (Blockchain confermata).");
}
//factory
public static class PaymentFactory
{
    public static IPaymentStrategy GetPaymentMethod(string scelta)
    {
        return scelta switch
        {
            "1" => new CreditCardPayment(),
            "2" => new PayPalPayment(),
            "3" => new BitcoinPayment(),
            _ => null
        };
    }
}
// context
public class PaymentContext
{
    private IPaymentStrategy _strategy;
    //la strategia a runtime
    public void SetStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }
    public void ExecutePayment(decimal amount)
    {
        if (_strategy == null)
            Console.WriteLine("Errore: Seleziona prima un metodo di pagamento!");
        else
            _strategy.Pay(amount);
    }
}
class Program
{
    static void Main()
    {
        PaymentContext context = new PaymentContext();
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n==== Sistema di  pagamento ====");
            Console.WriteLine("1. Carta di Credito");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Bitcoin");
            Console.WriteLine("0. Esci");
            Console.Write("Seleziona metodo: ");
            string scelta = Console.ReadLine();
            if (scelta == "0")
            {
                continua = false;
                continue;
            }
            // yso della Factory per ottenere la strategia
            IPaymentStrategy strategiaScelta = PaymentFactory.GetPaymentMethod(scelta);
            if (strategiaScelta != null)
            {
                //la strategia nel contesto
                context.SetStrategy(strategiaScelta);
                // esecuzione della transazione
                context.ExecutePayment(100000000);
            }
            else
            {
                Console.WriteLine("Scelta non valida!");
            }
        }
    }
}