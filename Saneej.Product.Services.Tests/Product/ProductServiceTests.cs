using AutoFixture;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Saneej.Product.Repository.Query;
using Saneej.Product.Services.Product;

namespace Saneej.Product.Services.Tests.Product
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Fixture _fixture;
        private ProductService _sut;
        private IProductQuery _productQueryStub;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture() { RepeatCount = 5 };
            _productQueryStub = Substitute.For<IProductQuery>();
            _sut = new ProductService(_productQueryStub);
        }

        [Test]
        public async Task GetProductsAsync_FiveRecords_ReturnsAllTheProducts()
        {
            // Arrange
            var products = _fixture.Create<List<Data.Product>>();
            _productQueryStub.GetAllProduct().ReturnsForAnyArgs(products);

            // Act
            var result = await _sut.GetProductsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();

            result.Data.Count.Should().BeGreaterThan(0);

            result.IsClientError.Should().BeFalse();
            result.ClientError.Should().BeNull();

            result.NotFound.Should().BeFalse();
            result.NoFoundMessage.Should().BeNull();
        }

        [Test]
        public async Task GetProductsAsync_ZeroRecords_ReturnsNoProductsAvailable()
        {
            // Arrange
            _productQueryStub.GetAllProduct().ReturnsForAnyArgs(new List<Data.Product> { });

            // Act
            var result = await _sut.GetProductsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().BeNull();

            result.IsClientError.Should().BeFalse();
            result.ClientError.Should().BeNull();

            result.NotFound.Should().BeTrue();
            result.NoFoundMessage.Should().Be("No products available.");
        }

        [Test]
        public async Task GetProductsByColorAsync_WithInValidColor_ReturnsInvalidColorClientError()
        {
            // Arrange
            var products = _fixture.Create<List<Data.Product>>();
            _productQueryStub.GetAllProductByColor("red").ReturnsForAnyArgs(products);

            // Act
            var result = await _sut.GetProductsByColorAsync(String.Empty);

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().BeNull();

            result.IsClientError.Should().BeTrue();
            result.ClientError.Should().Be("Please enter a valid color.");

            result.NotFound.Should().BeFalse();
            result.NoFoundMessage.Should().BeNull();
        }

        [Test]
        public async Task GetProductsByColorAsync_WithProductColorNotExist_ReturnsNoProductsFound()
        {
            // Arrange
            _productQueryStub.GetAllProduct().ReturnsForAnyArgs(new List<Data.Product> { });
            _productQueryStub.GetAllProductByColor("red").ReturnsForAnyArgs(new List<Data.Product> { });

            // Act
            var result = await _sut.GetProductsByColorAsync("blue");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().BeNull();

            result.IsClientError.Should().BeFalse();
            result.ClientError.Should().BeNull();

            result.NotFound.Should().BeTrue();
            result.NoFoundMessage.Should().Be("No products available with blue color.");
        }

        [Test]
        public async Task GetProductsByColorAsync_WithProductColorExist_ReturnsAllRedProducts()
        {
            // Arrange
            var products = _fixture.Create<List<Data.Product>>();
            _productQueryStub.GetAllProduct().ReturnsForAnyArgs(products);
            _productQueryStub.GetAllProductByColor("red").ReturnsForAnyArgs(products);

            // Act
            var result = await _sut.GetProductsByColorAsync("red");

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().NotBeNull();

            result.IsClientError.Should().BeFalse();
            result.ClientError.Should().BeNull();

            result.NotFound.Should().BeFalse();
            result.NoFoundMessage.Should().BeNull();
        }
    }
}
