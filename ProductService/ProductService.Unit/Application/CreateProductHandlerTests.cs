using AutoMapper;
using FluentAssertions;
using NSubstitute;
using ProductService.Application.Products.Command.CreateProduct;
using ProductService.Domain.Events;
using ProductService.Domain.Interfaces;


namespace ProductService.Unit.Application
{
    public class CreateProductHandlerTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductHandler _handlerProductHandler;
        private readonly IEventHandler<ProductInsertedEvent> _eventHandler;


        public CreateProductHandlerTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _eventHandler = Substitute.For<IEventHandler<ProductInsertedEvent>>();
            _handlerProductHandler = new CreateProductHandler(_productRepository, _mapper, _eventHandler);
        }

        [Fact]
        public async Task GenerateValidCommand_ShouldGenerateCommandWithValidValuesAsync()
        {
            // Arrange
            var faker = CreateProductHandlerTestData.GerarComandoValido();

            // Act
            var command = faker.Generate();

            var createProductResult = await _handlerProductHandler.Handle(command,new CancellationToken());

            // Assert
            createProductResult.Should().NotBeNull();
            command.name.Should().NotBeNullOrEmpty();
            command.price.Should().BeGreaterThan(0);
        }
    }

}
