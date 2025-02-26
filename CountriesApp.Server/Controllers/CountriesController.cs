using CountriesApp.Server.BL;
using CountriesApp.Server.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(CountriesBL _countriesBl) : ControllerBase
{

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var res = await _countriesBl.GetAll();
        return Ok(res);
    }

    [HttpGet("GetByRegion/{region}")]
    public async Task<IActionResult> GetByRegion(string region)
    {
        var res = await _countriesBl.GetByAttribute("region", region);
        return Ok(res);
    }

    [HttpGet("GetByName/{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var res = await _countriesBl.GetByAttribute("name", name);
        return Ok(res);
    }
}
