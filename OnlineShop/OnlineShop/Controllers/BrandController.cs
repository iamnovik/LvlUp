using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models.ScaffDir;

namespace OnlineShop.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly ShopDbContext _context;

    public BrandController(ShopDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
    {
        var brands = await _context.Brands.ToListAsync();
        if (!brands.Any())
        {
            return NotFound();
        }

        return Ok(brands);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Brand>> GetBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);

        if (brand == null)
        {
            return NotFound();
        }

        return Ok(brand);
    }
    
    [HttpPost]
    public async Task<ActionResult<Brand>> CreateBrand( Brand newBrand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Brands.Add(newBrand);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBrand), new { id = newBrand.BrandId }, newBrand);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBrand(int id, Brand updatedBrand)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingBrand = await _context.Brands.FindAsync(id);
        if (existingBrand == null)
        {
            return NotFound();
        }

        existingBrand.BrandName = updatedBrand.BrandName;

        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }

        _context.Brands.Remove(brand);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}