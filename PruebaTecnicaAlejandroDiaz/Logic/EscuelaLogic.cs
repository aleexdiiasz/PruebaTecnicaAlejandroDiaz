using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAlejandroDiaz.Context;
using PruebaTecnicaAlejandroDiaz.Models;

namespace PruebaTecnicaAlejandroDiaz.Logic;

public class EscuelaLogic : ControllerBase
{

    private readonly AppDbContext dbContext;

    public EscuelaLogic(AppDbContext context)
    {
        dbContext = context ?? throw new ArgumentNullException(nameof(context));
    }

    public ResponseModel<List<EscuelaModel>> GetListEscuelas()
    {
        var response = new ResponseModel<List<EscuelaModel>>();

        List<EscuelaModel> lstEscuelas = new();

        lstEscuelas = dbContext.Escuelas.OrderBy(e => e.EscuelaId).ToList();

        if (lstEscuelas.Count > 0)
        {
            response.CodeStatus = true;
            response.Message = "Lista de Escuelas";
            response.DataResponse = lstEscuelas;
        }
        else
        {
            response.CodeStatus = false;
            response.Message = "No hay escuelas";
        }

        return response;
    }

    public ResponseModel<object> CreateEscuela(EscuelaModel requertEscuelaModel)
    {
        var response = new ResponseModel<object>();

        if (string.IsNullOrEmpty(requertEscuelaModel.Codigo) || string.IsNullOrEmpty(requertEscuelaModel.Nombre) || string.IsNullOrEmpty(requertEscuelaModel.Descripcion))
        {
            response.CodeStatus = false;
            response.Message = "No deje campos vacios.";
            response.DataResponse = null;
        }
        else
        {

            EscuelaModel escuelaEntity = new EscuelaModel
            {
                Codigo = requertEscuelaModel.Codigo.ToUpper(),
                Nombre = requertEscuelaModel.Nombre.ToUpper(),
                Descripcion = requertEscuelaModel.Descripcion
            };

            escuelaEntity.Insert(dbContext);


            response.CodeStatus = true;
            response.Message = "Escuela creado.";
            response.DataResponse = escuelaEntity;
        }
        return response;

    }

    public ResponseModel<object> UpdateEscuela(EscuelaModel requertEscuelaModel)
    {
        var response = new ResponseModel<object>();

        var escuelaEntity = dbContext.Escuelas.FirstOrDefault(u => u.EscuelaId == requertEscuelaModel.EscuelaId);

        if (escuelaEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontro la escuela.";
            response.DataResponse = null;
        }
        else
        {
            escuelaEntity.Codigo = requertEscuelaModel.Codigo.ToUpper();
            escuelaEntity.Nombre = requertEscuelaModel.Nombre.ToUpper();
            escuelaEntity.Descripcion = requertEscuelaModel.Descripcion;
           

            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Escuela actualizado.";
            response.DataResponse = escuelaEntity;
        }

        return response;
    }

    public ResponseModel<object> DeleteEscuelas(int escuelaId)
    {
        var response = new ResponseModel<object>();

        var escuelaEntity = dbContext.Escuelas.FirstOrDefault(e => e.EscuelaId == escuelaId);

        if (escuelaEntity == null)
        {
            response.CodeStatus = false;
            response.Message = "No se encontró la escuela.";
            response.DataResponse = null;
        }
        else
        {
            dbContext.Escuelas.Remove(escuelaEntity);
            dbContext.SaveChanges();

            response.CodeStatus = true;
            response.Message = "Escuela eliminada correctamente.";
            response.DataResponse = null;
        }

        return response;
    }

}
