// rubrica telefonica 
using System;
using System.Collections.Generic;

class Rubrica
{
    static void Main()
    {
        Dictionary<string, string> rubrica = new Dictionary<string, string>();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Inserisci il nome: ");
            string nome = Console.ReadLine();
            Console.Write("Inserisci il numero di telefono: ");
            string numero = Console.ReadLine();
            rubrica[nome] = numero; 
        }
        Console.WriteLine("\n--- TUA RUBRICA ---");
        foreach (var contatto in rubrica)
        {
            Console.WriteLine($"Nome: {contatto.Key} -> Tel: {contatto.Value}");
        }
    }
}