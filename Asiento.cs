public class Asiento
{
    public int AsientoId { get; set; }  // ID único del asiento
    public int SalaId { get; set; }    // Relación con la sala
    public string Estado { get; set; } = "Disponible";  // Estado del asiento: Disponible, Reservado, Ocupado
    public int? TicketId { get; set; }  // Asociar ticket si está ocupado

}