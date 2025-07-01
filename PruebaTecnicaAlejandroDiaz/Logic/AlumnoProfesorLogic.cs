using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Logic;

public class AlumnoProfesorLogic : ControllerBase
{

    private readonly AppDbContext dbContext;

    public AlumnoProfesorLogic(AppDbContext context)
    {
        dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }



    public ResponseModel<List<AlumnoProfesorModel2>> GetListAlumnosProfesor()
    {
        var response = new ResponseModel<List<AlumnoProfesorModel2>>();

        var lstAlumnosProf = (from ap in dbContext.AlumnoProfesor
                              join a in dbContext.Alumnos on ap.AlumnoId equals a.AlumnoId
                              join p in dbContext.Profesores on ap.ProfesorId equals p.ProfesorId
                              orderby ap.Id
                              select new AlumnoProfesorModel2
                              {
                                  Id = ap.Id,
                                  AlumnoId = ap.AlumnoId,
                                  AlumnoNombre = $"{a.Nombre} {a.Apellido}",
                                  ProfesorId = ap.ProfesorId,
                                  ProfesorNombre = $"{p.Nombre} {p.Apellido}",
                              }).ToList();

        if (lstAlumnosProf.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Lista de Alumnos";
            response.DataResponse = lstAlumnosProf;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No hay asiganciones";
        }

        return response;
    }

    public ResponseModel<object> CreateAlumnosProf(AlumnoProfesorModel requertModel)
    {
        var response = new ResponseModel<object>();

        AlumnoProfesorModel apEntity = new AlumnoProfesorModel
        {
            AlumnoId = requertModel.AlumnoId,
            ProfesorId = requertModel.ProfesorId
        };

        apEntity.Insert(dbContext);


        response.CodeStatus = true;
        response.Message = "Profesor asignado.";
        response.DataResponse = apEntity;

        return response;

    }


    public ResponseModel<object> UpdateAlumnosProf(AlumnoProfesorModel requertModel)
    {
        var response = new ResponseModel<object>();

        var apEntity = dbContext.AlumnoProfesor.FirstOrDefault(u => u.Id == requertModel.Id);

        if (apEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontro la escuela.";
            response.DataResponse = null;
        }
        else
        {
            apEntity.AlumnoId = requertModel.AlumnoId;
            apEntity.ProfesorId = requertModel.ProfesorId;


            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Escuela actualizado.";
            response.DataResponse = apEntity;
        }

        return response;

    }

    public ResponseModel<object> DeleteAlumnosProf(int id)
    {
        var response = new ResponseModel<object>();

        var apEntity = dbContext.AlumnoProfesor.FirstOrDefault(e => e.Id == id);

        if (apEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontró la asignacion";
            response.DataResponse = null;
        }
        else
        {
            dbContext.AlumnoProfesor.Remove(apEntity);
            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Asignacion eliminada correctamente.";
            response.DataResponse = null;
        }

        return response;
    }

}
