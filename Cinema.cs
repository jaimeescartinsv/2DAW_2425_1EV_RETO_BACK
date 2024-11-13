public class Cinema
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Ubicacion { get; set; }
    public List<Screening> Funciones { get; set; }  // Las funciones de cine disponibles
}