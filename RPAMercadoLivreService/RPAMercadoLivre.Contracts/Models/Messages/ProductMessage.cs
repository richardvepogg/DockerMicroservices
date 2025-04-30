using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPAMercadoLivre.Contracts.Models.Messages
{
    public class ProductMessage : BaseMessage
    {
        public int id { get; set; }

        public string name { get; set; } = string.Empty;

        public decimal value { get; set; }
    }
}
