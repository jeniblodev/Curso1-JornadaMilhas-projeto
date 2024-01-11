namespace JornadaMilhasV0.Modelos;
public class OfertaViagem
{
    public Rota Rota { get; set; }
    public DateTime DataIda { get; set; }
    public DateTime DataVolta { get; set; }
    public double Preco { get; set; }

    public OfertaViagem(Rota rota, DateTime dataIda, DateTime dataVolta, double preco)
    {
        Rota = rota;
        DataIda = dataIda;
        DataVolta = dataVolta;
        Preco = preco;
    }

    public override string ToString()
    {
        return $"Origem: {Rota.Origem}, Destino: {Rota.Destino}, Data de Ida: {DataIda.ToShortDateString()}, Data de Volta: {DataVolta.ToShortDateString()}, Preço: {Preco:C}";
    }
}
