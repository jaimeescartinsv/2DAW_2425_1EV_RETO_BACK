public class Screening
{
    public int Id { get; set; }
    public int CineId { get; set; }
    public Cinema Cine { get; set; }
    public int PeliculaId { get; set; }
    public Movie Pelicula { get; set; }
    public DateTime FechaDeFuncion { get; set; }
    public DateTime HoraDeInicio { get; set; }
}