public class Sala
{
    public int Id { get; set; }
    public string Nombre { get; set; }  // Nombre o número de la sala
    public int CineId { get; set; }  // Relación con el cine al que pertenece
    public List<Screening> Funciones { get; set; }  // Funciones que se proyectan en esta sala
}