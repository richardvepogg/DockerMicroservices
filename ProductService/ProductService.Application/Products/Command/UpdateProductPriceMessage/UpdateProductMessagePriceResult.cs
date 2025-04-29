using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.UpdateProductPriceMessage
{
    public class UpdateProductMessagePriceResult
    {
        public UpdateProductMessagePriceResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; } 
    }
}
