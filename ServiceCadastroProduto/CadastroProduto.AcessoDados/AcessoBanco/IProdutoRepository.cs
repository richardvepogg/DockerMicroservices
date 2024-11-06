using CadastroProduto.Dominio.ValueObjects;

namespace CadastroProduto.AcessoDados.AcessoBanco
{
    public interface IProdutoRepository

    {
        void Add(ProdutoVO produtoVO);
        IEnumerable<ProdutoVO> GetAll();
        ProdutoVO Find(long id);
        void Remove(long id);
        void Update(ProdutoVO produtoVO);

    }
}
