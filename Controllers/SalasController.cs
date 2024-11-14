using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/salas")]
public class SalasController : ControllerBase
{
    // Lista estática de asientos (en memoria)
    private static List<Asiento> Asientos = new List<Asiento>
    {
        new Asiento { AsientoId = 1, SalaId = 1, Estado = "Disponible" },
        new Asiento { AsientoId = 2, SalaId = 1, Estado = "Disponible" },
        new Asiento { AsientoId = 3, SalaId = 1, Estado = "Reservado" },
        new Asiento { AsientoId = 4, SalaId = 2, Estado = "Disponible" }
    };

    // Obtener todos los asientos por sala
    [HttpGet("{salaId}/asientos")]
    public ActionResult<IEnumerable<Asiento>> GetAsientosBySalaId(int salaId)
    {
        var asientos = Asientos.Where(a => a.SalaId == salaId).ToList();
        if (!asientos.Any())
        {
            return NotFound($"No se encontraron asientos para la sala con ID {salaId}.");
        }

        return Ok(asientos);
    }

    // Cambiar el estado de un asiento
    [HttpPut("asientos/{asientoId}")]
    public ActionResult<Asiento> UpdateAsientoEstado(int asientoId, [FromBody] string nuevoEstado)
    {
        var asiento = Asientos.FirstOrDefault(a => a.AsientoId == asientoId);
        if (asiento == null)
        {
            return NotFound($"Asiento con ID {asientoId} no encontrado.");
        }

        asiento.Estado = nuevoEstado;
        return Ok(asiento);
    }
}