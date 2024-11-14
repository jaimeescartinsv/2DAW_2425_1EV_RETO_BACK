using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CinesController : ControllerBase
{
    // Lista estática de cines, salas y funciones (en memoria)
    private static List<Cine> Cines = new List<Cine>
    {
        new Cine
        {
            CineId = 1,
            Nombre = "MUELMO Cines Puerto Venecia",
            Ubicacion = "Zaragoza",
            Salas = new List<Sala>
            {
                new Sala
                {
                    SalaId = 1,
                    Nombre = "Sala 1",
                    CineId = 1,
                    Funciones = new List<Funcion>
                    {
                        new Funcion 
                        { 
                            FuncionId = 1, 
                            SalaId = 1, 
                            PeliculaId = 1, 
                            FechaDeFuncion = new DateTime(2024, 12, 1),
                            HoraDeInicio = new DateTime(2024, 12, 1, 18, 0, 0) 
                        },
                        new Funcion 
                        { 
                            FuncionId = 2, 
                            SalaId = 1, 
                            PeliculaId = 2, 
                            FechaDeFuncion = new DateTime(2024, 12, 1),
                            HoraDeInicio = new DateTime(2024, 12, 1, 20, 30, 0) 
                        }
                    }
                },

                new Sala
                {
                    SalaId = 2,
                    Nombre = "Sala 2",
                    CineId = 1,
                    Funciones = new List<Funcion>
                    {
                        new Funcion 
                        { 
                            FuncionId = 3, 
                            SalaId = 2, 
                            PeliculaId = 3, 
                            FechaDeFuncion = new DateTime(2024, 12, 2),
                            HoraDeInicio = new DateTime(2024, 12, 2, 18, 30, 0) 
                        },
                        new Funcion 
                        { 
                            FuncionId = 4, 
                            SalaId = 2, 
                            PeliculaId = 4, 
                            FechaDeFuncion = new DateTime(2024, 12, 2),
                            HoraDeInicio = new DateTime(2024, 12, 2, 21, 0, 0) 
                        }
                    }
                }
            }
        }
    };

    // Obtener lista de cines con sus salas y funciones
    [HttpGet]
    public ActionResult<IEnumerable<Cine>> GetCines()
    {
        return Ok(Cines);
    }

    // Obtener un cine por ID con sus salas y funciones
    [HttpGet("{id}")]
    public ActionResult<Cine> GetCineById(int id)
    {
        var cine = Cines.FirstOrDefault(c => c.CineId == id);
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
        var cine = Cines.FirstOrDefault(c => c.CineId == id);
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
        var cine = Cines.FirstOrDefault(c => c.CineId == cineId);
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
        var cine = Cines.FirstOrDefault(c => c.CineId == cineId);
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