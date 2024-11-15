public class Asiento
{
    public int AsientoId { get; set; }
    public int SalaId { get; set; }
    public string Estado { get; set; } = "Disponible";
    public int? TicketId { get; set; }

}