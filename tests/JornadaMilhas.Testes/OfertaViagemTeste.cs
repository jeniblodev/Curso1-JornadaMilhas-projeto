using JornadaMilhasV0.Modelos;

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

    [Fact(DisplayName = "TesteQueValidaObjetoOferta")]
    public void TesteQueValidaObjetoOferta()
    {
        Rota rota = new Rota("Origem", "Destino");
        DateTime dataIda = new DateTime(2024, 1, 1);
        DateTime dataVolta = new DateTime(2024, 1, 5);
        double preco = 100;

        OfertaViagem oferta = new OfertaViagem(rota, dataIda, dataVolta, preco);        

        Assert.Contains("Origem",oferta.ToString());

    }

    [Fact(DisplayName = "TestaSeObjetoCriadoEhValido")]
    public void TestaSeObjetoCriadoEhValido()
    {
        //Arrange
        Rota rota = new Rota("Origem", "Destino");
        DateTime dataIda = new DateTime(2024, 1, 1);
        DateTime dataVolta = new DateTime(2024, 1, 5);
        double preco = 100;

        OfertaViagem oferta = new OfertaViagem(rota, dataIda, dataVolta, preco);

        //Act
        var resultado = oferta.EhValido();

        //Assert
        Assert.True(resultado);

    }

    [Fact(DisplayName = "EhValidoOfertaDeveRetornarExcecaoQuandoDestinoNulo")]
    public void EhValidoOfertaDeveRetornarExcecaoQuandoDestinoNulo()
    {
        //Arrange
        Rota rota = null;
        DateTime dataIda = new DateTime(2024, 1, 1);
        DateTime dataVolta = new DateTime(2024, 1, 5);
        double preco = 100;
        OfertaViagem oferta;


        //Act+Assert
        Assert.Throws<System.FormatException>(                 
                 () => oferta = new OfertaViagem(rota, dataIda, dataVolta, preco)
        );
             
        
    }

    [Theory]
    [InlineData("Manaus", "São Paulo", "2024-01-01", "2024-01-02", 100)]
    [InlineData("Recife", "São Paulo", "2024-01-01", "2024-01-02", 110)]
    [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-02", 120)]
    [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", 250)]
    public void TestaSeObjetosCriadoSaoValidos(string origem, string destino, string dataIn, string dataVol, double preco)
    {
        //Arrange
        Rota rota = new Rota(origem,destino);
        DateTime dataIda = DateTime.Parse(dataIn);
        DateTime dataVolta = DateTime.Parse(dataVol);
        OfertaViagem oferta = new OfertaViagem(rota, dataIda, dataVolta, preco);

        //Act
        var resultado = oferta.EhValido();

        //Assert
        Assert.True(resultado);

    }

    [Theory(DisplayName = "TestaGerarExcecoesDadosInvalidos")]
    [InlineData("", null, "2024-01-01", "2024-01-02", 0)]
    [InlineData(null, "São Paulo", "2024-01-01", "2024-01-02", -1)]
    [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0)]
    [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500)]
    public void TestaGerarExcecoesDadosInvalidos(string origem, string destino, string dataIn, string dataVol, double preco)
    {
        //Arrange
        Rota rota = new Rota(origem, destino);
        DateTime dataIda = DateTime.Parse(dataIn);
        DateTime dataVolta = DateTime.Parse(dataVol);
        OfertaViagem oferta;

        //Act+Assert
        Assert.Throws<System.FormatException>(
                 () => oferta = new OfertaViagem(rota, dataIda, dataVolta, preco));

    }


}