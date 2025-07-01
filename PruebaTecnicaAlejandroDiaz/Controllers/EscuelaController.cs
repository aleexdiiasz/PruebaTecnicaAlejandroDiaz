using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Logic;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EscuelaController : ControllerBase
{
    private readonly EscuelaLogic _escuelaLogic;

    public EscuelaController(EscuelaLogic escuelaLogic)
    {
        _escuelaLogic = escuelaLogic;
    }

    [HttpGet("GetListaEscuelas")]
    public async Task<IActionResult> GetListaEscuelas()
    {
        var response = _escuelaLogic.GetListEscuelas();
        return Ok(response);
    }

    [HttpPost("CreateEscuelas")]
    public async Task<IActionResult> CreateEscuelas(EscuelaModel requestEscuelaModel)
    {
        var response = _escuelaLogic.CreateEscuela(requestEscuelaModel);
        return Ok(response);

    }

    [HttpPost("UpdateEscuelas")]
    public async Task<IActionResult> UpdateUser(EscuelaModel requestEscuelaModel)
    {
        var response = _escuelaLogic.UpdateEscuela(requestEscuelaModel);
        return Ok(response);

    }

    [HttpPost("DeleteEscuelas")]
    public async Task<IActionResult> DeleteEscuelas(int escuelaId)
    {
        var response = _escuelaLogic.DeleteEscuelas(escuelaId);
        return Ok(response);

    }

}
