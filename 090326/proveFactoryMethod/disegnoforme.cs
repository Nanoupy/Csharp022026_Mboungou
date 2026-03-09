using System;
// programma che disegna forme 
// interfaccia
public interface IShape
{
    void Draw();
}
// classi
public class Circle : IShape
{
    public void Draw() => Console.WriteLine("Disegno un cerchio: O");
}
public class Square : IShape
{
    public void Draw() => Console.WriteLine("Disegno un quadrato: [ ]");
}
// classe astratta 
public abstract class ShapeCreator
{
    // Factory Method
    public abstract IShape CreateShape(string type);
}
// i creator
public class ConcreteShapeCreator : ShapeCreator
{
    public override IShape CreateShape(string type)
    {
        if (type == "1")
        {
            return new Circle();
        }
        else if (type == "2")
        {
            return new Square();
        }
        else
        {
            return null;
        }
    }
}
class Program
{
    static void Main()
    {
        // creazione della fabbrica
        ShapeCreator fabbrica = new ConcreteShapeCreator();
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("\n--- Menu disegno forme ---");
            Console.WriteLine("1. Disegna Cerchio");
            Console.WriteLine("2. Disegna Quadrato");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();
            if (scelta == "0")
            {
                continua = false;
                Console.WriteLine("Chiusura programma...");
            }
            else
            {
                //la creazione della forma avvienne in base della scelta fatta
                IShape forma = fabbrica.CreateShape(scelta);

                if (forma != null)
                {
                    Console.WriteLine("\n--- Output Grafico ---");
                    forma.Draw();
                }
                else
                {
                    Console.WriteLine("Errore: Forma non riconosciuta.");
                }
            }
        }
    }
}