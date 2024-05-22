using Dominio.Entidades;
using AcessoDados.AcessoBanco;
using AcessoDados.Contexto;


namespace Negocio.Servicos
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ProdutoDbContext _contexto;

        public ProdutoRepository(ProdutoDbContext ctx)
        {
            _contexto = ctx;
        }
            
        public void Add(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
        }

        public Produto Find(long id)
        {
            return _contexto.Produtos.FirstOrDefault(u => u.idproduto == id)!;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _contexto.Produtos.ToList();
        }

        public void Remove(long id)
        {
            var entity = _contexto.Produtos.First(u => u.idproduto
             == id);
            _contexto.Produtos.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            _contexto.SaveChanges();
        }
    }
}
