using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private static List<Ticket> Tickets = new List<Ticket>();

    // Crear un ticket para una función seleccionada
    [HttpPost("crear")]
    public ActionResult<Ticket> CreateTicket([FromBody] Ticket ticket, [FromServices] FuncionesController funcionesController)
    {
        // Validar existencia del usuario
        var usuario = UsuariosController.Usuarios.FirstOrDefault(u => u.UsuarioId == ticket.UsuarioId);
        if (usuario == null)
        {
            return BadRequest($"El usuario con ID {ticket.UsuarioId} no existe.");
        }

        // Validar existencia de la función
        var result = funcionesController.GetFuncionById(ticket.FuncionId);
        if (result.Result is NotFoundObjectResult)
        {
            return BadRequest($"La función con ID {ticket.FuncionId} no existe.");
        }

        var funcion = result.Value;

        // Crear el ticket
        ticket.FechaDeCompra = DateTime.Now;
        ticket.Id = Tickets.Count > 0 ? Tickets.Max(t => t.Id) + 1 : 1;

        // Añadir el ticket a la lista en memoria
        Tickets.Add(ticket);

        // Asociar el ticket al usuario
        usuario.Tickets.Add(ticket);

        return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
    }

    // Obtener todos los tickets
    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetAllTickets()
    {
        return Ok(Tickets);
    }

    // Obtener un ticket específico por su ID
    [HttpGet("{id}")]
    public ActionResult<Ticket> GetTicketById(int id)
    {
        var ticket = Tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
        {
            return NotFound($"Ticket con ID {id} no encontrado.");
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
    [HttpDelete("{id}")]
    public IActionResult DeleteTicket(int id)
    {
        var ticket = Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound($"Ticket con ID {id} no encontrado.");
        }

        Tickets.Remove(ticket);

        // También eliminarlo del usuario asociado
        var usuario = UsuariosController.Usuarios.FirstOrDefault(u => u.UsuarioId == ticket.UsuarioId);
        if (usuario != null)
        {
            usuario.Tickets.Remove(ticket);
        }

        return NoContent();
    }
}