using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Negocio.Services
{
    public interface IHttpService
    {
        Task<string> GetHttpResponseBodyAsync(string url);
    }

}