public class Funcion
{
    public int FuncionId { get; set; }
    public int SalaId { get; set; }  // Relación con la sala
    public int PeliculaId { get; set; }  // Relación con la película
    public DateTime FechaDeFuncion { get; set; }
    public DateTime HoraDeInicio { get; set; }
}