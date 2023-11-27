using AutoMapper;
using CadastroPessoa.DTOs;
using CadastroPessoa.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastroPessoa.Mappings
{
    public class EntitiesToDTOMappingProfile:Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
        }
    }
}
