using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProductAPI.ModelRequest;
using ProductAPI.Models;

namespace PokemonReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Category, CreateCategoryModel>();
            CreateMap<CreateCategoryModel, Category>();
            CreateMap<Product,CreateProductRequest>();
            CreateMap<CreateProductRequest, Product>();

        }
    }
}
