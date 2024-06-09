using Autenticacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.Negocio.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
