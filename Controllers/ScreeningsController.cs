using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class ScreeningsController : ControllerBase
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

    // Obtener funciones de cine para una película en una fecha específica
    [HttpGet("{cineId}/{peliculaId}/{fecha}")]
    public ActionResult<IEnumerable<Screening>> GetScreenings(int cineId, int peliculaId, DateTime fecha)
    {
        var screenings = Cinemas
            .Where(c => c.Id == cineId)
            .SelectMany(c => c.Funciones)
            .Where(s => s.PeliculaId == peliculaId && s.FechaDeFuncion.Date == fecha.Date)
            .ToList();

        if (!screenings.Any())
        {
            return NotFound($"No se encontraron funciones para la película con ID {peliculaId} en el cine con ID {cineId} en la fecha {fecha.ToShortDateString()}.");
        }

        return Ok(screenings);
    }
}