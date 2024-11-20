using CadastroProduto.Dominio.ValueObjects;
using CadastroProduto.MessageBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProduto.Dominio.Messages
{
    public class ProdutoMessage : BaseMessage
    {
        public ProdutoMessage(ProdutoVO produtoVO) 
        {
            this.idProduto = produtoVO.idProduto;
            this.nmProduto = produtoVO.nmProduto;
            this.nuValor = produtoVO.nuValor;
        }
        public int idProduto { get; set; }

        public string nmProduto { get; set; }

        public decimal nuValor { get; set; }
    }
}
