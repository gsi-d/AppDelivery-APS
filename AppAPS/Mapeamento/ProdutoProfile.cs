using AppAPS.DTOs;
using AppAPS.Entities;
using AutoMapper;

namespace AppAPS.Mapeamento
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoItemDTO>().ReverseMap();
        }
    }
}
