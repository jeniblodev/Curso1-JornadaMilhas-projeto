using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhasV0.Modelos;
public class OfertaViagem
{
    public Rota Rota { get; set; }
    public DateTime DataIda { get; set; }
    public DateTime DataVolta { get; set; }
    public double Preco { get; set; }

    public List<OfertaViagem> ofertaViagem = new List<OfertaViagem>();

    public OfertaViagem()
    {

    }

    public OfertaViagem(Rota rota, DateTime dataIda, DateTime dataVolta, double preco)
    {
        Rota = rota;
        DataIda = dataIda;
        DataVolta = dataVolta;
        Preco = preco;
    }

    public void CadastrarOferta()
    {
        Console.WriteLine("-- Cadastro de ofertas --");
        Console.WriteLine("Informe a cidade de origem: ");
        string origem = Console.ReadLine();

        Console.WriteLine("Informe a cidade de destino: ");
        string destino = Console.ReadLine();

        Console.WriteLine("Informe a data de ida (DD/MM/AAAA): ");
        DateTime dataIda;
        if (!DateTime.TryParse(Console.ReadLine(), out dataIda))
        {
            Console.WriteLine("Data de ida inválida.");
            return;
        }

        Console.WriteLine("Informe a data de volta (DD/MM/AAAA): ");
        DateTime dataVolta;
        if (!DateTime.TryParse(Console.ReadLine(), out dataVolta))
        {
            Console.WriteLine("Data de volta inválida.");
            return;
        }

        Console.WriteLine("Informe o preço: ");
        double preco;
        if (!double.TryParse(Console.ReadLine(), out preco))
        {
            Console.WriteLine("Formato de preço inválido.");
            return;
        }

        OfertaViagem ofertaCadastrada = new OfertaViagem(new Rota(origem, destino), dataIda, dataVolta, preco);
        ofertaViagem.Add(ofertaCadastrada);

        Console.WriteLine("\nOferta cadastrada com sucesso.");
    }


    public void CarregarOfertas()
    {
        ofertaViagem.Add(new OfertaViagem(new Rota("São Paulo", "Curitiba"), new DateTime(2024,1,15), new DateTime(2024, 1, 20), 500));
        ofertaViagem.Add(new OfertaViagem(new Rota("Recife", "Rio de Janeiro"), new DateTime(2024, 2, 10), new DateTime(2024, 2, 15), 700));
        ofertaViagem.Add(new OfertaViagem(new Rota("Acre", "Brasília"), new DateTime(2024, 3, 5), new DateTime(2024, 3, 10), 600));
    }

    public void ExibirTodasAsOfertas()
    {
        Console.WriteLine("\nTodas as ofertas cadastradas: ");
        foreach (var oferta in ofertaViagem)
        {
            Console.WriteLine(oferta);
        }
    }

    public override string ToString()
    {
        return $"Origem: {Rota.Origem}, Destino: {Rota.Destino}, Data de Ida: {DataIda.ToShortDateString()}, Data de Volta: {DataVolta.ToShortDateString()}, Preço: {Preco:C}";
    }
}
