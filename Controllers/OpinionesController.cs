using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/opiniones")]
public class OpinionesController : ControllerBase
{
    private static List<Opinion> Opiniones = new List<Opinion>
    {
        new Opinion { PeliculaId = 1, Usuario = "Alex", Comentario = "Me ha gustado mucho la película, la recomiendo", Estrellas = 5},
        new Opinion { PeliculaId = 1, Usuario = "Vanessa", Comentario = "No me ha gustado nada la película, no la recomiendo", Estrellas = 2}
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