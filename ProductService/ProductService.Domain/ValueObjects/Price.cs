using ProductService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Domain.ValueObjects
{
    public class Price
    {
        public decimal Value { get; set; }
        public Currency Currency { get; set; }

        public Price(decimal value, Currency currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
