using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/salas")]
public class SalasController : ControllerBase
{
    // Obtener todas las butacas por sala
    [HttpGet("{salaId}/butacas")]
    public ActionResult<IEnumerable<Butaca>> GetButacasBySalaId(int salaId)
    {
        var sala = DatosCines.Cines
            .SelectMany(c => c.Salas)
            .FirstOrDefault(s => s.SalaId == salaId);

        if (sala == null)
        {
            return NotFound($"Sala con ID {salaId} no encontrada.");
        }

        return Ok(sala.Butacas);
    }

    // Cambiar el estado de una butaca
    [HttpPut("{salaId}/butacas/{butacaId}")]
    public ActionResult<Butaca> UpdateButacaEstado(int salaId, int butacaId, [FromBody] string nuevoEstado)
    {
        var sala = DatosCines.Cines
            .SelectMany(c => c.Salas)
            .FirstOrDefault(s => s.SalaId == salaId);

        if (sala == null)
        {
            return NotFound($"Sala con ID {salaId} no encontrada.");
        }

        var butaca = sala.Butacas.FirstOrDefault(a => a.ButacaId == butacaId);

        if (butaca == null)
        {
            return NotFound($"Butaca con ID {butacaId} no encontrado en la sala con ID {salaId}.");
        }

        butaca.Estado = nuevoEstado;
        return Ok(butaca);
    }
}