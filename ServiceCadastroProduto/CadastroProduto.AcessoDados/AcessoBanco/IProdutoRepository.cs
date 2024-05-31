using CadastroProduto.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto.AcessoDados.AcessoBanco
{
    public interface IProdutoRepository

    {
        void Add(Produto produto);
        IEnumerable<Produto> GetAll();
        Produto Find(long id);
        void Remove(long id);
        void Update(Produto produto);

    }
}
