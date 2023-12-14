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
    public class DeleteProductCommand : CommandRequestBase
    {
        public Guid Id { get; set; }
        public override void Validate()
        {
        }
    }
}
