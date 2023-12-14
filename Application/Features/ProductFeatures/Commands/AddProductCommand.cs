using Application.Extensions;
using Application.Features.ProductFeatures.Commands.Validators;
using Application.Share;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class AddProductCommand : CommandRequestBase
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturerPhone { get; set; }
        public string ManufacturerEmail { get; set; }
        public bool IsAvailable { get; set; }

        public override void Validate()
        {
            new AddProductCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}
