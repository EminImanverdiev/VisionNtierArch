using AutoMapper;
using Entities.Concrete;
using Entities.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Utilities.Profiles
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            CreateMap<GetProductDto, Product>().ReverseMap();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, GetAllProductDto>();
        }
    }
}
