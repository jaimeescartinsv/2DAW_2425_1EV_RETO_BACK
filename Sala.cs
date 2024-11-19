public class Sala
{
    public int SalaId { get; set; }
    public string Nombre { get; set; }
    public int CineId { get; set; }
    public int Capacidad { get; set; }
    public List<Sesion> Sesiones { get; set; }
    public List<Asiento> Asientos { get; set; } = new List<Asiento>();
}