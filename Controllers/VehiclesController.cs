using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services;

namespace projetNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _vehicleService.GetAllAsync();
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var vehicle = await _vehicleService.GetByIdAsync(id);
        if (vehicle == null)
            return NotFound();
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
    {
        try
        {
            var created = await _vehicleService.CreateAsync(vehicle);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Vehicle vehicle)
    {
        try
        {
            vehicle.Id = id;
            await _vehicleService.UpdateAsync(vehicle);
            return NoContent();
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
            await _vehicleService.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
