using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Logic;
using PruebaTecnicaAlejandroDiaz.Models;


namespace PruebaTecnicaAlejandroDiaz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VistasController : ControllerBase
{
    private readonly VistaLogic _vistaLogic;

    public VistasController(VistaLogic vistaLogic)
    {
        _vistaLogic = vistaLogic;
    }

    [HttpGet("GetListaAlumnosProfesorEscuela")]
    public async Task<IActionResult> GetListaAlumnosProfesorEscuela(int proId)
    {
        var response = _vistaLogic.GetListaAlumnosProfesorEscuela(proId);
        return Ok(response);
    } 
    
    [HttpGet("GetEscuelasConAlumnosPorProfesor")]
    public async Task<IActionResult> GetEscuelasConAlumnosPorProfesor(int proId)
    {
        var response = _vistaLogic.GetEscuelasConAlumnosPorProfesor(proId);
        return Ok(response);
    }

}