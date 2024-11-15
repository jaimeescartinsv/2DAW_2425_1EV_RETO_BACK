public class Usuario
{
    public string UsuarioId { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public List<Ticket> Tickets { get; set; } = new List<Ticket>();
}