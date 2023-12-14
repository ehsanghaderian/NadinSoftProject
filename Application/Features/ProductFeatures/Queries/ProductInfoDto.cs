using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class ProductInfoDto : IRequest<ProductInfoDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string? ManufacturerPhone { get; set; }
        public string ManufacturerEmail { get; set; }
        public bool IsAvailable { get; set; }
        public string OperatorName { get; set; }
    }
}
