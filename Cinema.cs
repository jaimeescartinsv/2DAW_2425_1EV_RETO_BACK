public class Cinema
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public List<Sala> Salas { get; set; }  // Salas disponibles en el cine
}