using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Logic;
using PruebaTecnicaAlejandroDiaz.Models;

[Route("api/[controller]")]
[ApiController]
public class AlumnosController : ControllerBase
{
    private readonly AlumnosLogic _alumnosLogic;

    public AlumnosController(AlumnosLogic alumnoLogic)
    {
        _alumnosLogic = alumnoLogic;
    }

    [HttpGet("GetListaAlumnos")]
    public async Task<IActionResult> GetListaAlumnos()
    {
        var response = _alumnosLogic.GetListAlumnos();
        return Ok(response);
    }

    [HttpPost("CreateAlumno")]
    public async Task<IActionResult> CreateAlumno(AlumnoModel requestaModel)
    {
        var response = _alumnosLogic.CreateAlumnos(requestaModel);
        return Ok(response);

    }

    [HttpPost("UpdateAlumno")]
    public async Task<IActionResult> UpdateAlumno(AlumnoModel requestModel)
    {
        var response = _alumnosLogic.UpdateAlumnos(requestModel);
        return Ok(response);

    }

    [HttpPost("DeleteAlumno")]
    public async Task<IActionResult> DeleteAlumno(int aId)
    {
        var response = _alumnosLogic.DeleteAlumnos(aId);
        return Ok(response);

    }

}
