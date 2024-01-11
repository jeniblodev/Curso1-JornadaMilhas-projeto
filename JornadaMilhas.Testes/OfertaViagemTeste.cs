using System.Linq.Expressions;
using Xunit;
using JornadaMilhasV0.Modelos;
using System.Text.RegularExpressions;

namespace JornadaMilhas.Testes;

public class OfertaViagemTeste
{
    [Fact(DisplayName = "TesteDeveCriarOferta")]
    public void TesteDeveCriarOferta()
    {
        Rota rota = new Rota("OrigemTeste", "DestinoTeste");
        DateTime dataIda = new DateTime(2024, 1, 1);
        DateTime dataVolta = new DateTime(2024, 1, 5);
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(rota, dataIda, dataVolta, preco);

        Assert.Equal(rota, oferta.Rota);
        Assert.Equal(dataIda, oferta.DataIda);
        Assert.Equal(dataVolta, oferta.DataVolta);
        Assert.Equal(preco, oferta.Preco);

    }

    [Fact(DisplayName = "TesteNaoDeveCriarOfertaComOrigemEDestinoVazios")]
    public void TesteNaoDeveCriarOfertaComOrigemEDestinoVazios()
    {
/*        Rota rota = new Rota("", "");*/
        DateTime dataIda = new DateTime(2024, 1, 1);
        DateTime dataVolta = new DateTime(2024, 1, 5);
        double preco = 100.0;

        OfertaViagem oferta = new OfertaViagem(null, dataIda, dataVolta, preco);

        Assert.Null(oferta);

    }

    /*    [Fact(DisplayName = "TesteDeveCadastrarOfertaNaLista")]
        public void DeveCadastrarOfertaNaLista()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            DateTime dataIda = new DateTime(2024, 1, 1);
            DateTime dataVolta = new DateTime(2024, 1, 5);
            double preco = 100.0;
            List<OfertaViagem> listaDeOfertas = new List<OfertaViagem>();

            OfertaViagem oferta = new OfertaViagem(rota, dataIda, dataVolta, preco);
            var gerenciador = new GerenciadorDeOfertas(listaDeOfertas);

            var resultado = gerenciador.AdicionarOfertaNaLista(oferta);

            Assert.NotEmpty(listaDeOfertas);
            Assert.True(resultado);
        }*/


}