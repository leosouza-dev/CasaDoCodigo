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

            CreateMap<Cliente, ClienteViewModel>()
                .ForMember(c => c.CEP, v => v.MapFrom(p => p.Endereco.CEP))
                .ForMember(c => c.Cidade, v => v.MapFrom(pv => pv.Endereco.Cidade))
                .ForMember(c => c.Complemento, v => v.MapFrom(pv => pv.Endereco.Complemento))
                .ForMember(c => c.Estado, v => v.MapFrom(pv => pv.Endereco.Estado))
                .ForMember(c => c.Numero, v => v.MapFrom(pv => pv.Endereco.Numero))
                .ForMember(c => c.Pais, v => v.MapFrom(pv => pv.Endereco.Pais))
                .ForMember(c => c.Rua, v => v.MapFrom(pv => pv.Endereco.Rua))
                .ReverseMap();

        }

    }
}
