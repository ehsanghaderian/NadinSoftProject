using Application.Exceptions;
using DomainModel.Products;
using DomainModel.Products.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        public readonly IProductRepository _productRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IProductRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await CheckExistProduct(request.ManufacturerEmail, request.ProduceDate);

            var newProduct = new Product(request.Name, request.ProduceDate, request.ManufacturerPhone, request.ManufacturerEmail, request.IsAvailable, request.CommandSender.UserId, request.CommandSender.Name);

            _productRepository.Add(newProduct);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        private async Task CheckExistProduct(string email, DateTime produceDate)
        {
            var existProduct = await _productRepository.ExistsProductWithEmailOrProduceDate(email, produceDate);

            if (existProduct)
                throw new ApplicationServiceBadRequestException("محصولی با این مشخصات موجود می باشد");
        }
    }
}
