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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        public readonly IProductRepository _productWriteRepository;
        public readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IProductRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productWriteRepository.GetByIdAsync(request.Id);
            if (product is null)
                throw new ApplicationServiceNotFoundException("محصول مورد نظر یافت نشد");

            _productWriteRepository.Remove(product);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
