using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/opiniones")]
public class OpinionesController : ControllerBase
{
    private static List<Opinion> Opiniones = new List<Opinion>
    {
        new Opinion { PeliculaId = 1, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 1, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 2, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 3, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 4, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 5, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 6, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 7, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 8, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 9, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 10, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 11, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 12, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 13, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 14, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 15, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 16, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 17, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 18, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 19, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 20, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
        new Opinion { PeliculaId = 21, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 22, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2},
    };

    // Obtener todas las opiniones
    [HttpGet]
    public ActionResult<List<Opinion>> GetOpiniones()
    {
        return Ok(Opiniones);
    }

    // Obtener una opinión por ID de película
    [HttpGet("{peliculaId}")]
    public ActionResult<Pelicula> GetOpinionByPeliculaId(int peliculaId)
    {
        var opinion = Opiniones.FindAll(o => o.PeliculaId == peliculaId);
        if (opinion == null)
        {
            return NotFound($"Opinión con películaId {peliculaId} no encontrada.");
        }
        return Ok(opinion);
    }
}