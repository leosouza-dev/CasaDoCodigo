using AutoMapper;
using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.AutoMapper
{
    public class AutoMapperConfig : Profile
    {

        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<SubCategoria, SubcategoriaViewModel>().ReverseMap();
            CreateMap<Autor, AutorViewModel>().ReverseMap();
            CreateMap<Livro, LivroViewModel>().ReverseMap();
        }

    }
}
