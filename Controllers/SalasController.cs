using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/salas")]
public class SalasController : ControllerBase
{
    // Obtener todos los asientos por sala
    [HttpGet("{salaId}/asientos")]
    public ActionResult<IEnumerable<Asiento>> GetAsientosBySalaId(int salaId)
    {
        var sala = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .FirstOrDefault(s => s.SalaId == salaId);

        if (sala == null)
        {
            return NotFound($"Sala con ID {salaId} no encontrada.");
        }

        return Ok(sala.Asientos);
    }

    // Cambiar el estado de un asiento
    [HttpPut("{salaId}/asientos/{asientoId}")]
    public ActionResult<Asiento> UpdateAsientoEstado(int salaId, int asientoId, [FromBody] string nuevoEstado)
    {
        var sala = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .FirstOrDefault(s => s.SalaId == salaId);

        if (sala == null)
        {
            return NotFound($"Sala con ID {salaId} no encontrada.");
        }

        var asiento = sala.Asientos.FirstOrDefault(a => a.AsientoId == asientoId);

        if (asiento == null)
        {
            return NotFound($"Asiento con ID {asientoId} no encontrado en la sala con ID {salaId}.");
        }

        asiento.Estado = nuevoEstado;
        return Ok(asiento);
    }
}