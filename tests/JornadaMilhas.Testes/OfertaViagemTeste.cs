using JornadaMilhasV0.Modelos;

namespace JornadaMilhas.Testes;

public class OfertaViagemTeste
{
    [Fact(DisplayName = "DeveCriarOfertaCorretamente")]
    public void DeveCriarOfertaCorretamente()
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

    [Fact(DisplayName = "ValidaObjetoOfertaDeveConterOrigemNoToString")]
    public void ValidaObjetoOfertaDeveConterOrigemNoToString()
    {
        Rota rota = new Rota("Origem", "Destino");
        DateTime dataIda = new DateTime(2024, 1, 1);
        DateTime dataVolta = new DateTime(2024, 1, 5);
        double preco = 100;

        OfertaViagem oferta = new OfertaViagem(rota, dataIda, dataVolta, preco);        

        Assert.Contains("Origem",oferta.ToString());

    }

    [Fact(DisplayName = "DeveRetornarVerdadeiroSeObjetoCriadoEhValido")]
    public void DeveRetornarVerdadeiroSeObjetoCriadoEhValido()
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
    public void DeveGerarExcecoesParaDadosInvalidos(string origem, string destino, string dataIn, string dataVol, double preco)
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

    [Fact(DisplayName = "DeveDefinirCorretamenteDesconto")]
    public void DeveDefinirCorretamenteDesconto()
    {
        //Arrange
        var rota = new Rota("Origem", "Destino");
        var dataIda = DateTime.Now;
        var dataVolta = DateTime.Now.AddDays(7);
        var preco = 100.0;
        var desconto = 10.0;

        //Act
        var ofertaViagem = new OfertaViagem(rota, dataIda, dataVolta, preco) { Desconto = desconto };

        //Assert
        Assert.Equal(desconto, ofertaViagem.Desconto);
    }

    [Fact(DisplayName = "PropriedadeStatusDeveSerDisponivelTruePorPadrao")]
    public void PropriedadeStatusDeveSerDisponivelTruePorPadrao()
    {
        // Arrange
        var rota = new Rota("Origem", "Destino");
        var dataIda = DateTime.Now;
        var dataVolta = DateTime.Now.AddDays(7);
        var preco = 100.0;

        // Act
        var ofertaViagem = new OfertaViagem(rota, dataIda, dataVolta, preco);

        // Assert
        Assert.True(ofertaViagem.StatusDisponivel);
    }

    [Fact(DisplayName = "AlteraStatusParaIndisponivelComMetodoInativar")]
    public void AlteraStatusParaIndisponivelComMetodoInativar()
    {
        // Arrange
        var rota = new Rota("Origem", "Destino");
        var dataIda = DateTime.Now;
        var dataVolta = DateTime.Now.AddDays(7);
        var preco = 100.0;
        var desconto = 10.0;
        var ofertaViagem = new OfertaViagem(rota, dataIda, dataVolta, preco) { Desconto = desconto};

        // Act
        ofertaViagem.Inativar();

        // Assert
        Assert.False(ofertaViagem.StatusDisponivel);
    }


}