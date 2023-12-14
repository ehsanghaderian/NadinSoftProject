using Application.Extensions;
using Application.Features.ProductFeatures.Commands.Validators;
using Application.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand : CommandRequestBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerPhone { get; set; }
        public bool IsAvailable { get; set; }

        public override void Validate()
        {
            new UpdateProductCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}
