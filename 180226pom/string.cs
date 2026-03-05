using System;
class Program
{
    static void Main()
    {
        //string
    string nome = "Marco";
    Console.WriteLine(nome.Length);
    Console.WriteLine(nome.ToUpper());
    Console.WriteLine(nome.ToLower());
    nome = nome.ToUpper();
    Console.WriteLine(nome);
    //trim e contain
    string frase = " Ciao Mondo ";
    Console.WriteLine(frase.Trim());
    Console.WriteLine(frase);
    Console.WriteLine(frase.Contains("Mondo"));
    //indexof e replace
    string parola = "banana";
    Console.WriteLine(parola.IndexOf(""));
    Console.WriteLine(parola.Replace("na", "**"));
    Console.WriteLine(parola);

    }
    }