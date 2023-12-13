using Microsoft.AspNetCore.Mvc;
using Saneej.Product.Api.Attributes;
using Saneej.Product.Models.Products;
using Saneej.Product.Services.Product;

namespace Saneej.Product.Api.Controllers;

[ApiController]
[Route("api/saneej/v1.0")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Health check/OK endpoint, not secured (API key authentication)
    /// </summary>
    /// <response code="200"> Returns health check message</response>
    [HttpGet]
    public ActionResult HealthCheck()
    {
        return Ok("I am in good health!");
    }


    /// <summary>
    /// Get all products, secured (API key authentication)
    /// </summary>
    /// <response code="200"> Returns list of products</response>
    [APIKeyAuthentication]
    [Route("products")]
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetAllProducts()
    {
        return Ok(await _productService.GetProductsAsync());
    }

    /// <summary>
    /// Get all products of a specific colour, secured (API key authentication)
    /// </summary>
    /// <response code="200"> Returns list of products</response>
    [APIKeyAuthentication]
    [Route("products/{color}")]
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetProductsByColor(string color)
    {
        return Ok(await _productService.GetProductsByColorAsync(color));
    }
}
