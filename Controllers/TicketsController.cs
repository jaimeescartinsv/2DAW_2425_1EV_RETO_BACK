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
        ticket.FechaDeCompra = DateTime.Now;  // Fecha de compra del ticket

        // Asignar un ID único al ticket (puedes ajustarlo según cómo quieras generar los ID)
        ticket.Id = Tickets.Count > 0 ? Tickets.Max(t => t.Id) + 1 : 1;

        // Añadir el ticket a la lista en memoria
        Tickets.Add(ticket);

        return CreatedAtAction(nameof(PurchaseTicket), new { id = ticket.Id }, ticket);  // Retornar el ticket creado
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