using Microsoft.AspNetCore.Mvc;
using ProductApi.Application.Interfaces;
using ProductApi.Application.ViewModels;

namespace ProductApi.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
        this._service = service;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<IEnumerable<ProductViewModel>>> GetAllAsync()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<ProductViewModel>> GetByIdAsync(long id)
    {
        try
        {
            var result = await _service.GetByIdAsync(id);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<ProductViewModel>> AddAsync([FromBody] ProductViewModel model)
    {
        if (model == null)
            return BadRequest("Invalid product data.");

        var result = await _service.AddAsync(model);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = result.Id }, result);
    }

    [HttpPut]
    [Route("")]

    public async Task<IActionResult> UpdateAsync([FromBody] ProductViewModel model)
    {
        try
        {
            await _service.UpdateAsync(model);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}
