using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private static List<Ticket> Tickets = new List<Ticket>();

    // Crear un ticket para una función seleccionada
    [HttpPost("crear")]
    public ActionResult<Ticket> CreateTicket([FromBody] Ticket ticket)
    {
        // Validar existencia del usuario
        var usuario = UsuariosController.Usuarios.FirstOrDefault(u => u.UsuarioId == ticket.UsuarioId);
        if (usuario == null)
        {
            return BadRequest($"El usuario con ID {ticket.UsuarioId} no existe.");
        }

        // Validar existencia de la función directamente
        var sesion = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Sesiones)
            .FirstOrDefault(f => f.SesionId == ticket.SesionId);

        if (sesion == null)
        {
            return BadRequest($"La función con ID {ticket.SesionId} no existe.");
        }

        // Validar existencia de la sala asociada a la función
        var sala = DataStoreCines.Cines?
            .SelectMany(c => c.Salas)
            .FirstOrDefault(s => s.SalaId == sesion.SalaId);

        if (sala == null)
        {
            return BadRequest($"No se encontró la sala asociada a la función con ID {ticket.SesionId}.");
        }

        // Validar que la lista de asientos no sea nula
        if (sala.Butacas == null || !sala.Butacas.Any())
        {
            return BadRequest($"La sala con ID {sala.SalaId} no tiene asientos configurados.");
        }

        // Validar existencia del asiento
        var butaca = sala.Butacas.FirstOrDefault(a => a.ButacaId == ticket.ButacaId);
        if (butaca == null)
        {
            return BadRequest($"El asiento con ID {ticket.ButacaId} no existe en la sala con ID {sala.SalaId}.");
        }

        // Validar que el asiento esté disponible
        if (butaca.Estado != "Disponible")
        {
            return BadRequest($"El asiento con ID {ticket.ButacaId} no está disponible.");
        }

        // Crear el ticket
        ticket.FechaDeCompra = DateTime.Now;
        ticket.TicketId = Tickets.Count > 0 ? Tickets.Max(t => t.TicketId) + 1 : 1;

        // Actualizar el estado del asiento
        butaca.Estado = "Reservado";
        butaca.TicketId = ticket.TicketId;

        // Añadir el ticket a la lista en memoria
        Tickets.Add(ticket);

        // Asociar el ticket al usuario
        usuario.Tickets.Add(ticket);

        return CreatedAtAction(nameof(GetTicketById), new { ticketId = ticket.TicketId }, ticket);
    }

    // Obtener todos los tickets
    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetAllTickets()
    {
        return Ok(Tickets);
    }

    // Obtener un ticket específico por su ID
    [HttpGet("{ticketId}")]
    public ActionResult<Ticket> GetTicketById(int ticketId)
    {
        var ticket = Tickets.FirstOrDefault(t => t.TicketId == ticketId);

        if (ticket == null)
        {
            return NotFound($"Ticket con ID {ticketId} no encontrado.");
        }

        return Ok(ticket);
    }

    // Obtener los tickets de un usuario específico
    [HttpGet("usuario/{usuarioId}")]
    public ActionResult<IEnumerable<Ticket>> GetTicketsByUsuarioId(int usuarioId)
    {
        var usuario = UsuariosController.Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {usuarioId} no encontrado.");
        }

        return Ok(usuario.Tickets);
    }

    // Eliminar un ticket por su ID
    [HttpDelete("{ticketId}")]
    public IActionResult DeleteTicket(int ticketId)
    {
        var ticket = Tickets.FirstOrDefault(t => t.TicketId == ticketId);
        if (ticket == null)
        {
            return NotFound($"Ticket con ID {ticketId} no encontrado.");
        }

        Tickets.Remove(ticket);

        var usuario = UsuariosController.Usuarios.FirstOrDefault(u => u.UsuarioId == ticket.UsuarioId);
        if (usuario != null)
        {
            usuario.Tickets.Remove(ticket);
        }

        return NoContent();
    }
}