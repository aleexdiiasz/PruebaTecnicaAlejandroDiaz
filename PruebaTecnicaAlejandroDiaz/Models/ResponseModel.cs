namespace PruebaTecnicaAlejandroDiaz.Models;

public class ResponseModel<T>
{
    public bool CodeStatus { get; set; }
    public string Message { get; set; }
    public T DataResponse { get; set; }

}

public class AlumnoProfesorEscuelaDTO
{
    public int AlumnoId { get; set; }
    public string AlumnoNombre { get; set; }
    public string EscuelaNombre { get; set; }
    public string ProfesorNombre { get; set; }
}