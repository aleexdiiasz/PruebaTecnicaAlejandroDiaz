using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Logic;
using PruebaTecnicaAlejandroDiaz.Models;


namespace PruebaTecnicaAlejandroDiaz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlumnoProfesorController : ControllerBase
{
    private readonly AlumnoProfesorLogic _alumnosProfLogic;

    public AlumnoProfesorController(AlumnoProfesorLogic alumnosProfLogic)
    {
        _alumnosProfLogic = alumnosProfLogic;
    }

    [HttpGet("GetListaAlumnosProf")]
    public async Task<IActionResult> GetListAlumnosProfesor()
    {
        var response = _alumnosProfLogic.GetListAlumnosProfesor();
        return Ok(response);
    }



    [HttpPost("CreateAlumnosProf")]
    public async Task<IActionResult> CreateAlumnosProf(AlumnoProfesorModel requestModel)
    {
        var response = _alumnosProfLogic.CreateAlumnosProf(requestModel);
        return Ok(response);

    }

    [HttpPost("UpdateAlumnosProf")]
    public async Task<IActionResult> UpdateAlumnosProf(AlumnoProfesorModel requestModel)
    {
        var response = _alumnosProfLogic.UpdateAlumnosProf(requestModel);
        return Ok(response);

    }

    [HttpPost("DeleteAlumnosProf")]
    public async Task<IActionResult> DeleteAlumnosProf(int Id)
    {
        var response = _alumnosProfLogic.DeleteAlumnosProf(Id);
        return Ok(response);

    }

}