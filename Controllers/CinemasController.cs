using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class CinemasController : ControllerBase
{
    // Lista estática de cines y sus funciones (en memoria)
    private static List<Cinema> Cinemas = new List<Cinema>
    {
        new Cinema
        {
            Id = 1,
            Nombre = "Cineplex",
            Ubicacion = "123 Main St, Ciudad",
            Funciones = new List<Screening>
            {
                new Screening 
                { 
                    Id = 1, 
                    CineId = 1, 
                    PeliculaId = 1, 
                    Pelicula = new Movie { Id = 1, Title = "Inception" }, 
                    FechaDeFuncion = new DateTime(2024, 12, 1),
                    HoraDeInicio = new DateTime(2024, 12, 1, 18, 0, 0) 
                },
                new Screening 
                { 
                    Id = 2, 
                    CineId = 1, 
                    PeliculaId = 2, 
                    Pelicula = new Movie { Id = 2, Title = "Interstellar" }, 
                    FechaDeFuncion = new DateTime(2024, 12, 1),
                    HoraDeInicio = new DateTime(2024, 12, 1, 20, 30, 0) 
                }
            }
        },
        new Cinema
        {
            Id = 2,
            Nombre = "CineStar",
            Ubicacion = "456 Broadway, Ciudad",
            Funciones = new List<Screening>
            {
                new Screening 
                { 
                    Id = 3, 
                    CineId = 2, 
                    PeliculaId = 3, 
                    Pelicula = new Movie { Id = 3, Title = "The Dark Knight" }, 
                    FechaDeFuncion = new DateTime(2024, 12, 2),
                    HoraDeInicio = new DateTime(2024, 12, 2, 18, 30, 0) 
                },
                new Screening 
                { 
                    Id = 4, 
                    CineId = 2, 
                    PeliculaId = 4, 
                    Pelicula = new Movie { Id = 4, Title = "The Matrix" }, 
                    FechaDeFuncion = new DateTime(2024, 12, 2),
                    HoraDeInicio = new DateTime(2024, 12, 2, 21, 0, 0) 
                }
            }
        }
    };

    // Obtener lista de cines con sus funciones
    [HttpGet]
    public ActionResult<IEnumerable<Cinema>> GetCinemas()
    {
        return Ok(Cinemas);
    }

    // Obtener un cine por ID con sus funciones
    [HttpGet("{id}")]
    public ActionResult<Cinema> GetCinemaById(int id)
    {
        var cinema = Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null)
        {
            return NotFound($"Cine con ID {id} no encontrado.");
        }
        return Ok(cinema);
    }

    // Obtener funciones de un cine por ID
    [HttpGet("{id}/funciones")]
    public ActionResult<IEnumerable<Screening>> GetFuncionesPorCineId(int id)
    {
        var cinema = Cinemas.FirstOrDefault(c => c.Id == id);
        if (cinema == null)
        {
            return NotFound($"Cine con ID {id} no encontrado.");
        }

        return Ok(cinema.Funciones);
    }

    // Obtener una función por ID
    [HttpGet("funcion/{id}")]
    public ActionResult<Screening> GetFuncionById(int id)
    {
        var screening = Cinemas.SelectMany(c => c.Funciones).FirstOrDefault(f => f.Id == id);
        if (screening == null)
        {
            return NotFound($"Función con ID {id} no encontrada.");
        }
        return Ok(screening);
    }
}