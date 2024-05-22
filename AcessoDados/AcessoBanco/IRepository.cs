
using Dominio.Entidades;

namespace AcessoDados.AcessoBanco
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
