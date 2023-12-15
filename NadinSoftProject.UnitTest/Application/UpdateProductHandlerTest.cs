using Application;
using Application.Features.ProductFeatures.Commands;
using Application.Features.ProductFeatures.Commands.Handlers;
using DomainModel.Products.Repositories;
using Infrastructure.Shared;
using MediatR;
using NSubstitute;
using Xunit;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using Application.Exceptions;
using DomainModel.Products;

namespace NadinSoftProject.UnitTest.Application
{
    public class UpdateProductHandlerTest
    {
        #region Arranges
        private readonly IRequestHandler<UpdateProductCommand> _updateProductHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly UserInfo _userInfo;

        public UpdateProductHandlerTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _productRepository = Substitute.For<IProductRepository>();
            _updateProductHandler = new UpdateProductCommandHandler(_productRepository, _unitOfWork);
            _userInfo = new UserInfo() { UserId = Guid.NewGuid(), Email = "nadinSoft@gmail.com", Name = "nadin", PhoneNumber = string.Empty, UserName = "nadinSoft@gmail.com" };
        }
        #endregion

        async Task Act(UpdateProductCommand command) => await _updateProductHandler.Handle(command, new CancellationToken());

        [Fact]
        public async void Update_product_Throw_Forbidden_When_User_does_not_same_With_Product_Operator()
        {
            var productId = Guid.NewGuid();
            var command = new UpdateProductCommand() { CommandSender = _userInfo, Id = productId ,Name = "product1" };
            var productForUpdate = new Product("product1", DateTime.Now, _userInfo.PhoneNumber, _userInfo.Email, false, Guid.NewGuid(), _userInfo.Name);
            _productRepository.GetByIdAsync(productId).Returns(productForUpdate);

            var result = async () => { await Act(command); };

            await result.Should().ThrowAsync<ApplicationServiceForbiddenException>();
        }
    }
}