using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cines")]
public class CinesController : ControllerBase
{
    // Obtener lista de cines con sus salas y funciones
    [HttpGet]
    public ActionResult<IEnumerable<Cine>> GetCines()
    {
        return Ok(DataStoreCines.Cines);
    }

    // Obtener un cine por ID con sus salas y funciones
    [HttpGet("{cineId}")]
    public ActionResult<Cine> GetCineById(int cineId)
    {
        var cine = DataStoreCines.Cines.FirstOrDefault(c => c.CineId == cineId);
        if (cine == null)
        {
            return NotFound($"Cine con ID {cineId} no encontrado.");
        }
        return Ok(cine);
    }

    // Obtener las salas de un cine por ID
    [HttpGet("{cineId}/salas")]
    public ActionResult<IEnumerable<Sala>> GetSalasPorCineId(int cineId)
    {
        var cine = DataStoreCines.Cines.FirstOrDefault(c => c.CineId == cineId);
        if (cine == null)
        {
            return NotFound($"Cine con ID {cineId} no encontrado.");
        }

        return Ok(cine.Salas);
    }

    // Obtener funciones de una sala específica en un cine
    [HttpGet("{cineId}/salas/{salaId}/funciones")]
    public ActionResult<IEnumerable<Funcion>> GetFuncionesPorSalaId(int cineId, int salaId)
    {
        var cine = DataStoreCines.Cines.FirstOrDefault(c => c.CineId == cineId);
        if (cine == null)
        {
            return NotFound($"Cine con ID {cineId} no encontrado.");
        }

        var sala = cine.Salas.FirstOrDefault(s => s.SalaId == salaId);
        if (sala == null)
        {
            return NotFound($"Sala con ID {salaId} no encontrada en el cine con ID {cineId}.");
        }

        return Ok(sala.Funciones);
    }

    // Obtener una función específica por cine, sala y función
    [HttpGet("{cineId}/salas/{salaId}/funciones/{funcionId}")]
    public ActionResult<Funcion> GetFuncionById(int cineId, int salaId, int funcionId)
    {
        var cine = DataStoreCines.Cines.FirstOrDefault(c => c.CineId == cineId);
        if (cine == null)
        {
            return NotFound($"Cine con ID {cineId} no encontrado.");
        }

        var sala = cine.Salas.FirstOrDefault(s => s.SalaId == salaId);
        if (sala == null)
        {
            return NotFound($"Sala con ID {salaId} no encontrada en el cine con ID {cineId}.");
        }

        var funcion = sala.Funciones.FirstOrDefault(f => f.FuncionId == funcionId);

        if (funcion == null)
        {
            return NotFound($"Función con ID {funcionId} no encontrada en la sala con ID {salaId} del cine con ID {cineId}.");
        }

        return Ok(funcion);
    }
}