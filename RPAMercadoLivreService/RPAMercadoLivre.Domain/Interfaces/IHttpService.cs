

namespace RPAMercadoLivre.Domain.Interfaces
{
    public interface IHttpService
    {
        Task<string> GetHttpResponseBodyAsync(string url);
    }
}
