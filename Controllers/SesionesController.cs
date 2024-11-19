using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/sesiones")]
public class SesionesController : ControllerBase
{
    // Obtener todas las sesiones
    [HttpGet]
    public ActionResult<IEnumerable<Sesion>> GetSesiones()
    {
        var sesiones = DatosCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Sesiones)
            .ToList();

        return Ok(sesiones);
    }

    // Obtener una sesion específica por su ID
    [HttpGet("{sesionId}")]
    public ActionResult<Sesion> GetSesionById(int sesionId)
    {
        var sesion = DatosCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Sesiones)
            .FirstOrDefault(f => f.SesionId == sesionId);

        if (sesion == null)
        {
            return NotFound($"Sesion con ID {sesionId} no encontrada.");
        }

        return Ok(sesion);
    }

    // Obtener sesiones por sala
    [HttpGet("sala/{salaId}")]
    public ActionResult<IEnumerable<Sesion>> GetSesionesBySalaId(int salaId)
    {
        var sesiones = DatosCines.Cines
            .SelectMany(c => c.Salas)
            .Where(s => s.SalaId == salaId)
            .SelectMany(s => s.Sesiones)
            .ToList();

        if (!sesiones.Any())
        {
            return NotFound($"No se encontraron sesiones para la sala con ID {salaId}.");
        }

        return Ok(sesiones);
    }

    // Obtener sesiones por cineId y por peliculaId
    [HttpGet("cine/{cineId}/pelicula/{peliculaId}")]
    public ActionResult<IEnumerable<Sesion>> GetSesionesByCineYPelicula(int cineId, int peliculaId)
    {
        var sesiones = DatosCines.Cines
            .Where(c => c.CineId == cineId) // Filtrar por cineId
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Sesiones)
            .Where(f => f.PeliculaId == peliculaId) // Filtrar por peliculaId
            .ToList();

        if (!sesiones.Any())
        {
            return NotFound($"No se encontraron sesiones para la película con ID {peliculaId} en el cine con ID {cineId}.");
        }

        return Ok(sesiones);
    }

    // Obtener sesiones por fecha específica
    [HttpGet("fecha/{fecha}")]
    public ActionResult<IEnumerable<Sesion>> GetSesionesByFecha(DateTime fecha)
    {
        var sesiones = DatosCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Sesiones)
            .Where(f => f.FechaDeSesion.Date == fecha.Date)
            .ToList();

        if (!sesiones.Any())
        {
            return NotFound($"No se encontraron sesiones para la fecha {fecha.ToShortDateString()}.");
        }

        return Ok(sesiones);
    }
}