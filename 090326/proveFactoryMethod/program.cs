// 1. Product: definisce l'interfaccia del prodotto
public interface IProduct
{
    void Execute();
}

// 2. ConcreteProductA: implementa IProduct
public class ConcreteProductA : IProduct
{
    public void Execute() => Console.WriteLine("Risultato di ConcreteProductA");
}

// 3. ConcreteProductB: un altro prodotto concreto
public class ConcreteProductB : IProduct
{
    public void Execute() => Console.WriteLine("Risultato di ConcreteProductB");
}

// 4. Creator: dichiara il Factory Method
public abstract class Creator
{
    // Il Factory Method
    public abstract IProduct FactoryMethod();

    // Logica di business che utilizza il prodotto creato dalle sottoclassi
    public void AnOperation()
    {
        var product = FactoryMethod();
        product.Execute();
    }
}

// 5. ConcreteCreatorA: implementa FactoryMethod per ConcreteProductA
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

// 6. ConcreteCreatorB: implementa FactoryMethod per ConcreteProductB
public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

// Esempio di utilizzo (Client)
class Program
{
    static void Main()
    {
        Creator creatorA = new ConcreteCreatorA();
        creatorA.AnOperation();  // Usa ConcreteProductA

        Creator creatorB = new ConcreteCreatorB();
        creatorB.AnOperation();  // Usa ConcreteProductB
    }
}