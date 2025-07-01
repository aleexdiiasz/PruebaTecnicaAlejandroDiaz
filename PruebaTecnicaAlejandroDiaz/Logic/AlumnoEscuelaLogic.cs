using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Logic;

public class AlumnoEscuelaLogic : ControllerBase
{

    private readonly AppDbContext dbContext;

    public AlumnoEscuelaLogic(AppDbContext context)
    {
        dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }



    public ResponseModel<List<AlumnoEscuelaModel2>> GetListaAlumnosEsc()
    {
        var response = new ResponseModel<List<AlumnoEscuelaModel2>>();

        var lstAlumnosEsc = (from ap in dbContext.AlumnoEscuela
                             join a in dbContext.Alumnos on ap.AlumnoId equals a.AlumnoId
                              join p in dbContext.Escuelas on ap.EscuelaId equals p.EscuelaId
                              orderby ap.Id
                              select new AlumnoEscuelaModel2
                              {
                                  Id = ap.Id,
                                  AlumnoId = ap.AlumnoId,
                                  AlumnoNombre = $"{a.Nombre} {a.Apellido}",
                                  EscuelaId = ap.EscuelaId,
                                  EscuelaNombre = $"{p.Nombre}",
                              }).ToList();

        if (lstAlumnosEsc.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Lista de Alumnos";
            response.DataResponse = lstAlumnosEsc;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No hay asiganciones";
        }

        return response;
    }

    public ResponseModel<object> CreateAlumnosEsc(AlumnoEscuelaModel requertModel)
    {
        var response = new ResponseModel<object>();

        AlumnoEscuelaModel apEntity = new AlumnoEscuelaModel
        {
            AlumnoId = requertModel.AlumnoId,
            EscuelaId = requertModel.EscuelaId
        };

        apEntity.Insert(dbContext);


        response.CodeStatus = true;
        response.Message = "Escuela asignado.";
        response.DataResponse = apEntity;

        return response;

    }


    public ResponseModel<object> UpdateAlumnosEsc(AlumnoEscuelaModel requertModel)
    {
        var response = new ResponseModel<object>();

        var apEntity = dbContext.AlumnoEscuela.FirstOrDefault(u => u.Id == requertModel.Id);

        if (apEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontro la escuela.";
            response.DataResponse = null;
        }
        else
        {
            apEntity.AlumnoId = requertModel.AlumnoId;
            apEntity.EscuelaId = requertModel.EscuelaId;


            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Escuela actualizado.";
            response.DataResponse = apEntity;
        }

        return response;

    }

    public ResponseModel<object> DeleteAlumnosEsc(int id)
    {
        var response = new ResponseModel<object>();

        var aeEntity = dbContext.AlumnoEscuela.FirstOrDefault(p => p.Id == id);

        if (aeEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontró el profesor.";
            response.DataResponse = null;
        }
        else
        {
            dbContext.AlumnoEscuela.Remove(aeEntity);
            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Alumno eliminado correctamente.";
            response.DataResponse = null;
        }

        return response;
    }
}
