using AutoMapper;
using AvaliacaoQuestor.Api.DTO;
using AvaliacaoQuestor.Domain.Features;

namespace AvaliacaoQuestor.Api.Configurations;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Bancos, BancosDTO>();
        CreateMap<BancosDTO, Bancos>();

        CreateMap<Boletos, BoletosDTO>();
        CreateMap<BoletosDTO, Boletos>();
    }
}
