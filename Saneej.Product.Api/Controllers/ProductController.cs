using Microsoft.AspNetCore.Mvc;
using Saneej.Product.Api.Attributes;
using Saneej.Product.Models.Products;
using Saneej.Product.Services.Product;

namespace Saneej.Product.Api.Controllers;

[ApiController]
[Route("api/saneej/v1.0")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(IProductService productService, ILogger<ProductController> logger)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpGet]
    public ActionResult HealthCheck()
    {
        return Ok("I am in good health!");
    }

    [APIKeyAuthentication]
    [Route("products")]
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>>  GetAllProducts()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    [APIKeyAuthentication]
    [Route("products/{color}")]
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetProductsByColor(string color)
    {
        return Ok(await _productService.GetProductsByColorAsync(color));
    }
}
