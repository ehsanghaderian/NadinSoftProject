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
    public class AddProductHandlerTest
    {
        #region Arranges
        private readonly IRequestHandler<AddProductCommand> _addProductHandler;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly UserInfo _userInfo;

        public AddProductHandlerTest()
        {
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _productRepository = Substitute.For<IProductRepository>();
            _addProductHandler = new AddProductCommandHandler(_productRepository, _unitOfWork);
            _userInfo = new UserInfo() { UserId = Guid.NewGuid(), Email = "nadinSoft@gmail.com", Name = "nadin", PhoneNumber = string.Empty, UserName = "nadinSoft@gmail.com" };
        }
        #endregion

        async Task Act(AddProductCommand command) => await _addProductHandler.Handle(command, new CancellationToken());

        [Fact]
        public async void Add_New_Product_Throw_BadRequest_When_Product_With_same_ManufacturerEmail_or_ProduceDate_Already_Exists()
        {
            var produceDate = DateTime.Now;
            var command = new AddProductCommand() { CommandSender = _userInfo, Name = "product1", ManufacturerEmail = _userInfo.Email, ProduceDate = produceDate };
            _productRepository.ExistsProductWithEmailOrProduceDate(_userInfo.Email, produceDate).Returns(true);

            var result = async () => { await Act(command); };

            await result.Should().ThrowAsync<ApplicationServiceBadRequestException>();
        }
    }
}