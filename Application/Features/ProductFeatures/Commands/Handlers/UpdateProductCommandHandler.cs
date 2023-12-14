using Application.Exceptions;
using DomainModel.Products;
using DomainModel.Products.Repositories;
using Infrastructure.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        public readonly IProductRepository _productWriteRepository;
        public readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IProductRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productWriteRepository.GetByIdAsync(request.Id);
            if (product is null)
                throw new ApplicationServiceNotFoundException("محصول مورد نظر یافت نشد");

            if (product.OperatorInfo.Id != request.CommandSender.UserId)
                throw new ApplicationServiceForbiddenException("شما مجاز به ویرایش محصول مورد نظر نمی باشید");

            product.Update(request.Name, request.ManufacturerPhone, request.IsAvailable);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
