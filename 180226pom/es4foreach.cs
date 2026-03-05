using System;

class Program
{
    static void Main()
    { //validatore di password
        Console.Write("Inserisci una password da verificare: ");
        string pass = Console.ReadLine();

        if (IsPasswordValida(pass))
            Console.WriteLine("Password valida! Ok");
        else
            Console.WriteLine("Password NON valida. NO");
    }
    static bool IsPasswordValida(string p)
    {
        // Regola c: Almeno 8 caratteri
        if (p.Length < 8) return false;

        // Regola d: Non deve iniziare o finire con spazio
        if (p.StartsWith(" ") || p.EndsWith(" ")) return false;
        bool haMaiuscola = false;
        bool haCifra = false;

        foreach (char c in p)
        {
            if (char.IsUpper(c)) haMaiuscola = true;
            if (char.IsDigit(c)) haCifra = true;
        }

        // Ritorna true solo se entrambe le condizioni sono soddisfatte
        return haMaiuscola && haCifra;
    }
}