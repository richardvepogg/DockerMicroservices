using Autenticacao.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.AcessoDados.AcessoBanco
{
    public interface IUsuariosRepository
    {
        Usuario Find(Usuario usuario);
    }
}
