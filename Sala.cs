public class Sala
{
    public int SalaId { get; set; }
    public string Nombre { get; set; }  // Nombre o número de la sala
    public int CineId { get; set; }  // Relación con el cine al que pertenece (Id de Cinema)
    public List<Funcion> Funciones { get; set; }  // Funciones que se proyectan en esta sala
}