using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.Services;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OffersController : ControllerBase
{
    private readonly IOfferService _offerService;

    public OffersController(IOfferService offerService)
    {
        _offerService = offerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var offers = await _offerService.GetAllAsync();
        return Ok(offers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var offer = await _offerService.GetByIdAsync(id);
        if (offer == null)
            return NotFound();
        return Ok(offer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Offer offer)
    {
        try
        {
            var created = await _offerService.CreateAsync(offer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _offerService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
