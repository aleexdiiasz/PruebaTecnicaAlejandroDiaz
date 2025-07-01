using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Logic;

public class VistaLogic : ControllerBase
{

    private readonly AppDbContext dbContext;

    public VistaLogic(AppDbContext context)
    {
        dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public class AlumnoProfesorEscuelaDTO
    {
        public int AlumnoId { get; set; }
        public string AlumnoNombre { get; set; }
        public string EscuelaNombre { get; set; }
        public string ProfesorNombre { get; set; }
    }

    public ResponseModel<List<AlumnoProfesorEscuelaDTO>> GetListaAlumnosProfesorEscuela(int profesorId)
    {
        var response = new ResponseModel<List<AlumnoProfesorEscuelaDTO>>();

        var lista = (from ap in dbContext.AlumnoProfesor
                     join a in dbContext.Alumnos on ap.AlumnoId equals a.AlumnoId
                     join p in dbContext.Profesores on ap.ProfesorId equals p.ProfesorId
                     join e in dbContext.Escuelas on p.EscuelaId equals e.EscuelaId
                     where p.ProfesorId == profesorId
                     select new AlumnoProfesorEscuelaDTO
                     {
                         AlumnoId = a.AlumnoId,
                         AlumnoNombre = a.Nombre + " " + a.Apellido,
                         EscuelaNombre = e.Nombre,
                         ProfesorNombre = p.Nombre + " " + p.Apellido
                     }).ToList();

        if (lista.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Lista de Alumnos";
            response.DataResponse = lista;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No hay asignaciones";
            response.DataResponse = null;
        }

        return response;
    }


    public class EscuelaConAlumnosDto
    {
        public int EscuelaId { get; set; }
        public string EscuelaNombre { get; set; }
        public List<AlumnoDto> Alumnos { get; set; }
    }

    public class AlumnoDto
    {
        public int AlumnoId { get; set; }
        public string NombreCompleto { get; set; }
    }

    public ResponseModel<List<EscuelaConAlumnosDto>> GetEscuelasConAlumnosPorProfesor(int profesorId)
    {
        var response = new ResponseModel<List<EscuelaConAlumnosDto>>();

        var datos = (from p in dbContext.Profesores
                     join e in dbContext.Escuelas on p.EscuelaId equals e.EscuelaId
                     join ap in dbContext.AlumnoProfesor on p.ProfesorId equals ap.ProfesorId
                     join a in dbContext.Alumnos on ap.AlumnoId equals a.AlumnoId
                     where p.ProfesorId == profesorId
                     select new
                     {
                         EscuelaId = e.EscuelaId,
                         EscuelaNombre = e.Nombre,
                         AlumnoId = a.AlumnoId,
                         AlumnoNombre = a.Nombre + " " + a.Apellido
                     }).ToList();  // Aquí se ejecuta la consulta y se trae todo a memoria

        var resultado = datos
            .GroupBy(x => new { x.EscuelaId, x.EscuelaNombre })
            .Select(g => new EscuelaConAlumnosDto
            {
                EscuelaId = g.Key.EscuelaId,
                EscuelaNombre = g.Key.EscuelaNombre,
                Alumnos = g.Select(a => new AlumnoDto
                {
                    AlumnoId = a.AlumnoId,
                    NombreCompleto = a.AlumnoNombre
                })
                .Distinct()
                .ToList()
            }).ToList();


        if (resultado.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Escuelas con alumnos del profesor";
            response.DataResponse = resultado;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No se encontraron escuelas o alumnos para el profesor";
        }

        return response;
    }

}
