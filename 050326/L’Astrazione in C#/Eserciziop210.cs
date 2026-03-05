using System;
using System.Collections.Generic;
// interfaccia
public interface IPagamento
{
    void EseguiPagamento(decimal importo);
    void MostraMetodo();
}
// classi con interfaccia 
public class PagamentoCarta : IPagamento
{
    public string Circuito { get; set; }
    public PagamentoCarta(string circuito) => Circuito = circuito;
    public void MostraMetodo() => Console.WriteLine("Metodo: Carta di credito");
    public void EseguiPagamento(decimal importo) => 
        Console.WriteLine($"Pagamento di {importo} euro con carta (Circuito: {Circuito})");
}
public class PagamentoContanti : IPagamento
{
    public void MostraMetodo() => Console.WriteLine("Metodo: Contanti");

    public void EseguiPagamento(decimal importo) => 
        Console.WriteLine($"Pagamento di {importo} euro in contanti");
}

public class PagamentoPayPal : IPagamento
{
    public string EmailUtente { get; set; }

    public PagamentoPayPal(string email) => EmailUtente = email;

    public void MostraMetodo() => Console.WriteLine("Metodo: PayPal");

    public void EseguiPagamento(decimal importo) => 
        Console.WriteLine($"Pagamento di {importo} euro tramite PayPal da: {EmailUtente}");
}

// main
class Program
{
    static void Main()
    {
        List<IPagamento> listaPagamenti = new List<IPagamento>
        {
            new PagamentoCarta("Mastercard"),
            new PagamentoContanti(),
            new PagamentoPayPal("utente@email.com")
        };

        foreach (var metodo in listaPagamenti)
        {
            metodo.MostraMetodo();
            metodo.EseguiPagamento(99.99m);
            Console.WriteLine("-----------------------------");
        }
        Console.ReadKey();
    }
}