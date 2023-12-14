using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Queries
{
    public class ProductItemBriefInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public string OperatorName { get; set; }
    }
}
