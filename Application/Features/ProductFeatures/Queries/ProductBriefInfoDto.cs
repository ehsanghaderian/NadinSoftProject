using Infrastructure.Helpers.PaginationHelpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class ProductBriefInfoDto : IRequest<PageQuery>
    {
        public List<ProductItemBriefInfoDto> Products { get; set; }
        public int TotalCount { get; set; }
    }
}
