using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CinesController : ControllerBase
{
    // Obtener lista de cines con sus salas y funciones
    [HttpGet]
    public ActionResult<IEnumerable<Cine>> GetCines()
    {
        return Ok(DataStoreCines.Cines);
    }

    // Obtener un cine por ID con sus salas y funciones
    [HttpGet("{id}")]
    public ActionResult<Cine> GetCineById(int id)
    {
        var cine = DataStoreCines.Cines.FirstOrDefault(c => c.CineId == id);
        if (cine == null)
        {
            return NotFound($"Cine con ID {id} no encontrado.");
        }
        return Ok(cine);
    }

    // Obtener las salas de un cine por ID
    [HttpGet("{id}/salas")]
    public ActionResult<IEnumerable<Sala>> GetSalasPorCineId(int id)
    {
        var cine = DataStoreCines.Cines.FirstOrDefault(c => c.CineId == id);
        if (cine == null)
        {
            return NotFound($"Cine con ID {id} no encontrado.");
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

    // Obtener funciones de cine para una película en una fecha específica en una sala específica
    [HttpGet("{cineId}/salas/{salaId}/funciones/{peliculaId}/{fecha}")]
    public ActionResult<IEnumerable<Funcion>> GetScreeningsByCineAndSalaAndPelicula(int cineId, int salaId, int peliculaId, DateTime fecha)
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

        var screenings = sala.Funciones
            .Where(s => s.PeliculaId == peliculaId && s.FechaDeFuncion.Date == fecha.Date)
            .ToList();

        if (!screenings.Any())
        {
            return NotFound($"No se encontraron funciones para la película con ID {peliculaId} en la sala con ID {salaId} del cine con ID {cineId} en la fecha {fecha.ToShortDateString()}.");
        }

        return Ok(screenings);
    }
}