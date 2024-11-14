using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    // Lista estática de tickets (en memoria)
    private static List<Ticket> Tickets = new List<Ticket>();

    // Crear un ticket para una función seleccionada
    [HttpPost]
    public ActionResult<Ticket> PurchaseTicket([FromBody] Ticket ticket)
    {
        // Validar existencia de la función
        var funcion = DataStore.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Funciones)
            .FirstOrDefault(f => f.FuncionId == ticket.Funcion.FuncionId);

        if (funcion == null)
        {
            return BadRequest($"La función con ID {ticket.Funcion.FuncionId} no existe.");
        }

        // Validar capacidad de la sala
        var sala = DataStore.Cines
            .SelectMany(c => c.Salas)
            .FirstOrDefault(s => s.SalaId == funcion.SalaId);

        if (sala == null || sala.Capacidad <= Tickets.Count(t => t.Funcion.FuncionId == funcion.FuncionId))
        {
            return BadRequest("No hay asientos disponibles para esta función.");
        }

        // Crear el ticket
        ticket.FechaDeCompra = DateTime.Now;  // Fecha de compra del ticket
        ticket.Id = Tickets.Count > 0 ? Tickets.Max(t => t.Id) + 1 : 1;

        // Añadir el ticket a la lista en memoria
        Tickets.Add(ticket);

        return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
    }

    // Obtener todos los tickets (opcional)
    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> GetTickets()
    {
        return Ok(Tickets);  // Retornar todos los tickets almacenados en memoria
    }

    // Obtener un ticket específico por su ID (opcional)
    [HttpGet("{id}")]
    public ActionResult<Ticket> GetTicketById(int id)
    {
        var ticket = Tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null)
        {
            return NotFound($"Ticket con ID {id} no encontrado.");
        }

        return Ok(ticket);  // Retornar el ticket encontrado
    }
}