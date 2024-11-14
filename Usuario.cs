public class Usuario
{
    public string UsuarioId { get; set; }  // ID único del usuario
    public string Nombre { get; set; }    // Nombre del usuario
    public string Correo { get; set; }    // Correo electrónico del usuario
    public List<Ticket> Tickets { get; set; } = new List<Ticket>(); // Lista de tickets comprados por el usuario
}