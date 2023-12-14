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
        public readonly IProductRepository _productWriteRepository;
        public readonly IUnitOfWork _unitOfWork;

        public AddProductCommandHandler(IProductRepository productWriteRepository, IUnitOfWork unitOfWork)
        {
            _productWriteRepository = productWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await CheckExistProduct(request.ManufacturerEmail, request.ProduceDate);

            var newProduct = new Product(request.Name, request.ProduceDate, request.ManufacturerPhone, request.ManufacturerEmail, request.IsAvailable, request.CommandSender.UserId, request.CommandSender.Name);

            _productWriteRepository.Add(newProduct);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }

        private async Task CheckExistProduct(string email, DateTime produceDate)
        {
            var existProduct = await _productWriteRepository.ExistsProductWithEmailOrProduceDate(email, produceDate);

            if (existProduct)
                throw new Exception();
        }
    }
}
