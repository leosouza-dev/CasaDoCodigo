using AutoMapper;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Data;

namespace CasaDoCodigo.AutoMapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();

            CreateMap<SubCategoria, SubcategoriaViewModel>().ReverseMap();
            //.ForMember(dest => dest.Categoria, source => source.MapFrom(src => src.CategoriaId));
            
            CreateMap<Autor, AutorViewModel>().ReverseMap();
            CreateMap<Livro, LivroViewModel>().ReverseMap();

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }

    }
}
