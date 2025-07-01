using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Logic;
using PruebaTecnicaAlejandroDiaz.Models;

[Route("api/[controller]")]
[ApiController]
public class ProfesoresController : ControllerBase
{
    private readonly ProfesoresLogic _profesoresLogic;

    public ProfesoresController(ProfesoresLogic profesoresLogic)
    {
        _profesoresLogic = profesoresLogic;
    }

    [HttpGet("GetListaProfesores")]
    public async Task<IActionResult> GetListaProfesores()
    {
        var response = _profesoresLogic.GetListProfesores();
        return Ok(response);
    }

    [HttpPost("CreateProfesor")]
    public async Task<IActionResult> CreateProfesor(ProfesorModel requestModel)
    {
        var response = _profesoresLogic.CreateProfesor(requestModel);
        return Ok(response);
    }

    [HttpPost("UpdateProfesor")]
    public async Task<IActionResult> UpdateProfesor(ProfesorModel requestModel)
    {
        var response = _profesoresLogic.UpdateProfesor(requestModel);
        return Ok(response);
    }

    [HttpPost("DeleteProfesor")]
    public async Task<IActionResult> DeleteProfesor(int pId)
    {
        var response = _profesoresLogic.DeleteProfesor(pId);
        return Ok(response);
    }
}
