using AutoMapper;
using ProductService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Products.Command.GetUser
{
    public class GetProductProfile : Profile
    {
        public GetProductProfile() 
        {
            CreateMap<Product, GetProductResult>();
        }
    }
}
