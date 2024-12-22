using Autenticacao.Dominio.Entidades;
using Autenticacao.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autenticacao.AcessoDados.AcessoBanco
{
    public interface IUsuariosRepository
    {
        UsuarioVO Find(UsuarioVO usuariovo);
    }
}
