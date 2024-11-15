using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/funciones")]
public class FuncionesController : ControllerBase
{
    // Obtener todas las funciones
    [HttpGet]
    public ActionResult<IEnumerable<Funcion>> GetFunciones()
    {
        var funciones = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Funciones)
            .ToList();

        return Ok(funciones);
    }

    // Obtener una función específica por su ID
    [HttpGet("{funcionId}")]
    public ActionResult<Funcion> GetFuncionById(int funcionId)
    {
        var funcion = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Funciones)
            .FirstOrDefault(f => f.FuncionId == funcionId);

        if (funcion == null)
        {
            return NotFound($"Función con ID {funcionId} no encontrada.");
        }

        return Ok(funcion);
    }

    // Obtener funciones por sala
    [HttpGet("sala/{salaId}")]
    public ActionResult<IEnumerable<Funcion>> GetFuncionesBySalaId(int salaId)
    {
        var funciones = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .Where(s => s.SalaId == salaId)
            .SelectMany(s => s.Funciones)
            .ToList();

        if (!funciones.Any())
        {
            return NotFound($"No se encontraron funciones para la sala con ID {salaId}.");
        }

        return Ok(funciones);
    }

    // Obtener funciones por película
    [HttpGet("pelicula/{peliculaId}")]
    public ActionResult<IEnumerable<Funcion>> GetFuncionesByPeliculaId(int peliculaId)
    {
        var funciones = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Funciones)
            .Where(f => f.PeliculaId == peliculaId)
            .ToList();

        if (!funciones.Any())
        {
            return NotFound($"No se encontraron funciones para la película con ID {peliculaId}.");
        }

        return Ok(funciones);
    }

    // Obtener funciones por fecha específica
    [HttpGet("fecha/{fecha}")]
    public ActionResult<IEnumerable<Funcion>> GetFuncionesByFecha(DateTime fecha)
    {
        var funciones = DataStoreCines.Cines
            .SelectMany(c => c.Salas)
            .SelectMany(s => s.Funciones)
            .Where(f => f.FechaDeFuncion.Date == fecha.Date)
            .ToList();

        if (!funciones.Any())
        {
            return NotFound($"No se encontraron funciones para la fecha {fecha.ToShortDateString()}.");
        }

        return Ok(funciones);
    }
}