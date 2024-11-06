using AutoMapper;
using AutoMapper.QueryableExtensions;
using CadastroProduto.AcessoDados.AcessoBanco;
using CadastroProduto.AcessoDados.Contexto;
using CadastroProduto.Dominio.Entidades;
using CadastroProduto.Dominio.ValueObjects;


namespace CadastroProduto.Negocio.Services
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ProdutoDbContext _contexto;
        private readonly IMapper _mapper;

        public ProdutoRepository(ProdutoDbContext ctx, IMapper mapper)
        {
            _contexto = ctx;
            _mapper = mapper;
        }

        public void Add(ProdutoVO produtoVO)
        {

            _contexto.Produtos.Add(_mapper.Map<Produto>(produtoVO));
            _contexto.SaveChanges();
        }

        public ProdutoVO Find(long id)
        {
            Produto produto = _contexto.Produtos.FirstOrDefault(u => u.idproduto == id)!;

            if (produto == null)
                return null;

            return _mapper.Map<ProdutoVO>(produto);
        }

        public IEnumerable<ProdutoVO> GetAll()
        {
            return _contexto.Produtos
                            .ProjectTo<ProdutoVO>(_mapper.ConfigurationProvider)
                            .ToList();
        }

        public void Remove(long id)
        {
            Produto produto = _contexto.Produtos.FirstOrDefault(u => u.idproduto == id);

            if (produto == null)
                return;

            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
        }

        public void Update(ProdutoVO produtoVO)
        {

            Produto produto = _contexto.Produtos.FirstOrDefault(u => u.idproduto == produtoVO.idProduto);

            if (produto != null)
                return;

            _mapper.Map(produtoVO, produto);
            _contexto.SaveChanges();


            return;
        }
    }
}
