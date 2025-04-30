
using RPAMercadoLivre.Domain.Interfaces;

namespace RPAMercadoLivreProjeto.Application.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _client;

        public HttpService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetHttpResponseBodyAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
                return "";
            }
        }


    }
}
