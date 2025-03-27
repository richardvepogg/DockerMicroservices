using FluentAssertions;
using RPAMercadoLivre.Integration.Helpers;
using RPAMercadoLivreProjeto.Application.Services;

namespace RPAMercadoLivre.Unit.Application
{
    public class HttpServiceTests
    {

        [Theory(DisplayName = "Query the product on the Mercado Libre website and verify if it was able to find the product information.")]
        [InlineData("kindle")] 
        [InlineData("iphone15")] 
        public async Task GetHttpResponseBodyAsync_DeveRetornarConteudoDoMercadoLivre_ComInformacoesEsperadas(string produto)
        {
            var httpService = new HttpService();

            // Act
            var responseBody = await httpService.GetHttpResponseBodyAsync($"{MercadoLivreHelper.Url}{produto}");

            // Assert
            responseBody.Should().NotBeNullOrEmpty();

            var match = MercadoLivreHelper.PrecosRegex.Match(responseBody);

            match.Success.Should().BeTrue();
        }
    

    }

}
