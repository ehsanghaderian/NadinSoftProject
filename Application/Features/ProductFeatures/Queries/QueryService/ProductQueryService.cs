using AutoMapper;
using DomainModel.Products;
using DomainModel.Products.Repositories;
using Infrastructure.Helpers.PaginationHelpers;
using MediatR;

namespace Application.Features.ProductFeatures.Queries.Handlers
{
    public class ProductQueryService : 
        IRequestHandler<GetAllProductsInfoQuery, ProductBriefInfoDto>,
        IRequestHandler<GetProductInfoQuery, ProductInfoDto>
    {
        public readonly IProductRepository _productWriteRepository;

        public ProductQueryService(IProductRepository productWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
        }

        public async Task<ProductBriefInfoDto> Handle(GetAllProductsInfoQuery query, CancellationToken cancellationToken)
        {
            var products = await _productWriteRepository.GetAllWithPaginationAsync(query.PageQuery);
            var totalCount = await _productWriteRepository.CountAsync();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductItemBriefInfoDto>()

                .ForMember(dest => dest.OperatorName, act => act.MapFrom(src => src.OperatorInfo.Name));
            });

            var mapper = new Mapper(config);

            var productDtos = products.Select(c => mapper.Map<ProductItemBriefInfoDto>(c)).ToList();

            return new ProductBriefInfoDto
            {
                Products = productDtos,
                TotalCount = totalCount
            };
        }

        public async Task<ProductInfoDto> Handle(GetProductInfoQuery query, CancellationToken cancellationToken)
        {
            var product = await _productWriteRepository.GetByIdAsync(query.ProductId);
            if (product is null)
                throw new Exception();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductItemBriefInfoDto>()

                .ForMember(dest => dest.OperatorName, act => act.MapFrom(src => src.OperatorInfo.Name));
            });

            var mapper = new Mapper(config);

            var productInfoDto = mapper.Map<ProductInfoDto>(product);

            return productInfoDto;
        }
    }

    public class GetAllProductsInfoQuery : IRequest<ProductBriefInfoDto>
    {
        public PageQuery PageQuery { get; set; }
    }

    public class GetProductInfoQuery : IRequest<ProductInfoDto>
    {
        public Guid ProductId { get; set; }
    }
}
