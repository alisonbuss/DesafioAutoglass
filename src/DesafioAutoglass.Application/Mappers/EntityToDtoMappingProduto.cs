
using AutoMapper;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Application.Dtos;

namespace DesafioAutoglass.Application.Mappers
{
    public class EntityToDtoMappingProduto : Profile
    {
        public EntityToDtoMappingProduto()
        {
            EntityToDtoMapping();
        }

        private void EntityToDtoMapping()
        {
            CreateMap<Produto, DtoProduto>()
                .ForMember(dto => dto.Id,                  opt => opt.MapFrom(entity => entity.Id))
                .ForMember(dto => dto.Codigo,              opt => opt.MapFrom(entity => entity.Codigo))
                .ForMember(dto => dto.Descricao,           opt => opt.MapFrom(entity => entity.Descricao))
                // .ForMember(dto => dto.Situacao,         opt => opt.Ignore());
                .ForMember(dto => dto.Situacao,            opt => opt.MapFrom(entity => entity.Situacao))
                .ForMember(dto => dto.DataFabricacao,      opt => opt.MapFrom(entity => entity.DataFabricacao))
                .ForMember(dto => dto.DataValidade,        opt => opt.MapFrom(entity => entity.DataValidade))
                .ForMember(dto => dto.CodigoFornecedor,    opt => opt.MapFrom(entity => entity.CodigoFornecedor))
                .ForMember(dto => dto.DescricaoFornecedor, opt => opt.MapFrom(entity => entity.DescricaoFornecedor))
                .ForMember(dto => dto.CNPJFornecedor,      opt => opt.MapFrom(entity => entity.CNPJFornecedor));
        }

    }
}
