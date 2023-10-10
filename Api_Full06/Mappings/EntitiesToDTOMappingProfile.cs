using Api_Full06.DTO;
using Api_Full06.Model;
using AutoMapper;
using System.ComponentModel;

namespace Api_Full06.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Componente, ComponenteDTO>().ReverseMap();
        }
    }
}
