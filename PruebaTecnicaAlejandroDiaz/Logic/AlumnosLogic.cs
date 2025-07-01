using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Logic;

public class AlumnosLogic : ControllerBase
{

    private readonly AppDbContext dbContext;

    public AlumnosLogic(AppDbContext context)
    {
        dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public ResponseModel<object> GetListAlumnos()
    {
        var response = new ResponseModel<object>();

        List<AlumnoModel> lstAlumnos = new List<AlumnoModel>();

        lstAlumnos = dbContext.Alumnos.OrderBy(e => e.AlumnoId).ToList();

        if (lstAlumnos.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Lista de Alumnos";
            response.DataResponse = lstAlumnos;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No hay Alumnos";
        }

        return response;
    }

    public ResponseModel<object> CreateAlumnos(AlumnoModel requertModel)
    {
        var response = new ResponseModel<object>();

        if (string.IsNullOrEmpty(requertModel.Nombre) || string.IsNullOrEmpty(requertModel.Apellido) )
        {
            response.CodeStatus = false;
            response.Message = "No deje campos vacios.";
            response.DataResponse = null;
        }
        else
        {

            AlumnoModel escuelaEntity = new AlumnoModel
            {
                Nombre = requertModel.Nombre.ToUpper(),
                 Apellido= requertModel.Apellido.ToUpper(),
                 FechaNacimiento = requertModel.FechaNacimiento
            };

            escuelaEntity.Insert(dbContext);


            response.CodeStatus = true;
            response.Message = "Alumno creado.";
            response.DataResponse = escuelaEntity;
        }
        return response;

    }

    public ResponseModel<object> UpdateAlumnos(AlumnoModel requertModel)
    {
        var response = new ResponseModel<object>();

        var alumnoEntity = dbContext.Alumnos.FirstOrDefault(u => u.AlumnoId == requertModel.AlumnoId);

        if (alumnoEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontro el alumno.";
            response.DataResponse = null;
        }
        else
        {
            alumnoEntity.Nombre = requertModel.Nombre.ToUpper();
            alumnoEntity.Apellido = requertModel.Apellido.ToUpper();
            alumnoEntity.FechaNacimiento = requertModel.FechaNacimiento;


            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Alumnos actualizado.";
            response.DataResponse = alumnoEntity;
        }

        return response;
    }

    public ResponseModel<object> DeleteAlumnos(int alumnosId)
    {
        var response = new ResponseModel<object>();

        var escuelaEntity = dbContext.Alumnos.FirstOrDefault(e => e.AlumnoId == alumnosId);

        if (escuelaEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontró la escuela.";
            response.DataResponse = null;
        }
        else
        {
            dbContext.Alumnos.Remove(escuelaEntity);
            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Escuela eliminada correctamente.";
            response.DataResponse = null;
        }

        return response;
    }

}
