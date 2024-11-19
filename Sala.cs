public class Sala
{
    public int SalaId { get; set; }
    public string Nombre { get; set; }
    public int CineId { get; set; }
    public List<Sesion> Sesiones { get; set; }
    public List<Butaca> Butacas { get; set; } = new List<Butaca>();
}