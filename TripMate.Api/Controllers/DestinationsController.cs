using Microsoft.AspNetCore.Mvc;
using TripMate.Application.Destinations.Interfaces;

namespace TripMate.Api.Controllers;

[ApiController]
[Route("api/destinations")]
public class DestinationsController : ControllerBase
{
    private readonly IDestinationService _destinationService;

    public DestinationsController(IDestinationService destinationService)
    {
        _destinationService = destinationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _destinationService.GetAllAsync();
        return Ok(data);
    }
}
