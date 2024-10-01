﻿using AppAPS.DTOs;
using AppAPS.Entities;
using AutoMapper;

namespace AppAPS.Mapeamento
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<Pedido, ItemGrafico>()
                .ForMember(destino => destino.Indicador, opt => opt.MapFrom(x => EnumHelper.GetEnumDescription(x.Bairro)))
                .ForMember(destino => destino.Periodo, opt => opt.MapFrom(x => x.DataAbertura.ToString("dd/MM")));
        }
    }
}
