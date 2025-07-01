using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Logic;

public class ProfesoresLogic : ControllerBase
{
    private readonly AppDbContext dbContext;

    public ProfesoresLogic(AppDbContext context)
    {
        dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public ResponseModel<object> GetListProfesores()
    {
        var response = new ResponseModel<object>();

        var lstProfesores = dbContext.Profesores.OrderBy(p => p.ProfesorId).ToList();

        if (lstProfesores.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Lista de profesores";
            response.DataResponse = lstProfesores;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No hay profesores registrados.";
        }

        return response;
    }

    public ResponseModel<object> CreateProfesor(ProfesorModel requestModel)
    {
        var response = new ResponseModel<object>();

        if (string.IsNullOrEmpty(requestModel.Nombre) ||
            string.IsNullOrEmpty(requestModel.Apellido))
        {
            response.CodeStatus = false;
            response.Message = "No deje campos vacíos.";
            response.DataResponse = null;
        }
        else
        {
            var profesorEntity = new ProfesorModel
            {
                Nombre = requestModel.Nombre.ToUpper(),
                Apellido = requestModel.Apellido.ToUpper(),
                EscuelaId = requestModel.EscuelaId
            };

            profesorEntity.Insert(dbContext);

            response.CodeStatus = true;
            response.Message = "Profesor creado.";
            response.DataResponse = profesorEntity;
        }

        return response;
    }

    public ResponseModel<object> UpdateProfesor(ProfesorModel requestModel)
    {
        var response = new ResponseModel<object>();

        var profesorEntity = dbContext.Profesores.FirstOrDefault(p => p.ProfesorId == requestModel.ProfesorId);

        if (profesorEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontró el profesor.";
            response.DataResponse = null;
        }
        else
        {
            profesorEntity.Nombre = requestModel.Nombre.ToUpper();
            profesorEntity.Apellido = requestModel.Apellido.ToUpper();
            profesorEntity.EscuelaId = requestModel.EscuelaId;

            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Profesor actualizado.";
            response.DataResponse = profesorEntity;
        }

        return response;
    }

    public ResponseModel<object> DeleteProfesor(int profesorId)
    {
        var response = new ResponseModel<object>();

        var profesorEntity = dbContext.Profesores.FirstOrDefault(p => p.ProfesorId == profesorId);

        if (profesorEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontró el profesor.";
            response.DataResponse = null;
        }
        else
        {
            dbContext.Profesores.Remove(profesorEntity);
            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Profesor eliminado correctamente.";
            response.DataResponse = null;
        }

        return response;
    }
}
