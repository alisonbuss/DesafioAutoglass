
using AutoMapper;

using DesafioAutoglass.Domain.Entities;
using DesafioAutoglass.Application.Dtos;

namespace DesafioAutoglass.Application.Mappers
{
    public class DtoToEntityMappingProduto : Profile
    {
        public DtoToEntityMappingProduto()
        {
            this.DtoToEntityMapping();
        }

        private void DtoToEntityMapping()
        {
            CreateMap<DtoProduto, Produto>()
                .ForMember(entity => entity.Id,                  opt => opt.MapFrom(dto => dto.Id))
                .ForMember(entity => entity.Codigo,              opt => opt.MapFrom(dto => dto.Codigo))
                .ForMember(entity => entity.Descricao,           opt => opt.MapFrom(dto => dto.Descricao))
                // .ForMember(entity => entity.Situacao,         opt => opt.Ignore());
                .ForMember(entity => entity.Situacao,            opt => opt.MapFrom(dto => dto.Situacao))
                .ForMember(entity => entity.DataFabricacao,      opt => opt.MapFrom(dto => dto.DataFabricacao))
                .ForMember(entity => entity.DataValidade,        opt => opt.MapFrom(dto => dto.DataValidade))
                .ForMember(entity => entity.CodigoFornecedor,    opt => opt.MapFrom(dto => dto.CodigoFornecedor))
                .ForMember(entity => entity.DescricaoFornecedor, opt => opt.MapFrom(dto => dto.DescricaoFornecedor))
                .ForMember(entity => entity.CNPJFornecedor,      opt => opt.MapFrom(dto => dto.CNPJFornecedor));
        }

    }
}