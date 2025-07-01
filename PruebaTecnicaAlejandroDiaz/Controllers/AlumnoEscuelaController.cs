using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Logic;
using PruebaTecnicaAlejandroDiaz.Models;


namespace PruebaTecnicaAlejandroDiaz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlumnoEscuelaController : ControllerBase
{
    private readonly AlumnoEscuelaLogic _alumnosEscLogic;

    public AlumnoEscuelaController(AlumnoEscuelaLogic alumnosEscLogic)
    {
        _alumnosEscLogic = alumnosEscLogic;
    }

    [HttpGet("GetListaAlumnosEsc")]
    public async Task<IActionResult> GetListaAlumnosEsc()
    {
        var response = _alumnosEscLogic.GetListaAlumnosEsc();
        return Ok(response);
    }



    [HttpPost("CreateAlumnosEsc")]
    public async Task<IActionResult> CreateAlumnosEsc(AlumnoEscuelaModel requestModel)
    {
        var response = _alumnosEscLogic.CreateAlumnosEsc(requestModel);
        return Ok(response);

    }

    [HttpPost("UpdateAlumnosEsc")]
    public async Task<IActionResult> UpdateAlumnosEsc(AlumnoEscuelaModel requestModel)
    {
        var response = _alumnosEscLogic.UpdateAlumnosEsc(requestModel);
        return Ok(response);

    }

    [HttpPost("DeleteAlumnosEsc")]
    public async Task<IActionResult> DeleteAlumnosEsc(int Id)
    {
        var response = _alumnosEscLogic.DeleteAlumnosEsc(Id);
        return Ok(response);

    }

}