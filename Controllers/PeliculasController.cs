using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/peliculas")]
public class PeliculasController : ControllerBase
{
    private static List<Pelicula> Peliculas = new List<Pelicula>
    {
        new Pelicula { PeliculaId = 1, Title = "Origen", Description = "Dom Cobb roba secretos del subconsciente, pero enfrenta el reto inverso: implantar una idea en otra mente. Un reto único y peligroso.", Director = "Christopher Nolan", Genero = "Acción, Ciencia ficción, Aventura", Clasificacion = "12", Duration = 148, ImageUrl = "https://image.tmdb.org/t/p/original/tXQvtRWfkUUnWJAn2tN3jERIUG.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/8ZTVqvKDQ8emSGUEMjsS4yHAwrp.jpg" },
        new Pelicula { PeliculaId = 2, Title = "Interstellar", Description = "Con la Tierra al borde del colapso, un grupo de astronautas emprende una misión para explorar planetas y salvar a la humanidad.", Director = "Christopher Nolan", Genero = "Aventura, Drama, Ciencia ficción", Clasificacion = "12", Duration = 169, ImageUrl = "https://image.tmdb.org/t/p/original/nrSaXF39nDfAAeLKksRCyvSzI2a.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/l33oR0mnvf20avWyIMxW02EtQxn.jpg" },
        new Pelicula { PeliculaId = 3, Title = "El caballero oscuro", Description = "Batman enfrenta al Joker, su enemigo más peligroso, quien busca llevar el caos absoluto a Gotham en un enfrentamiento épico y letal.", Director = "Christopher Nolan", Genero = "Drama, Acción, Crimen, Suspense", Clasificacion = "16", Duration = 152, ImageUrl = "https://image.tmdb.org/t/p/original/8QDQExnfNFOtabLDKqfDQuHDsIg.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/dqK9Hag1054tghRQSqLSfrkvQnA.jpg" },
        new Pelicula { PeliculaId = 4, Title = "Matrix", Description = "Neo descubre que la Matrix es una simulación que controla a la humanidad y se une a la resistencia para liberar a todos de esta prisión.", Director = "Lana Wachowski", Genero = "Acción, Ciencia ficción", Clasificacion = "18", Duration = 136, ImageUrl = "https://image.tmdb.org/t/p/original/qK76PKQLd6zlMn0u83Ej9YQOqPL.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/l4QHerTSbMI7qgvasqxP36pqjN6.jpg" },
        new Pelicula { PeliculaId = 5, Title = "El club de la lucha", Description = "Un insomne y un vendedor de jabón fundan un club clandestino de peleas que se transforma en una peligrosa organización.", Director = "David Fincher", Genero = "Drama", Clasificacion = "18", Duration = 139, ImageUrl = "https://image.tmdb.org/t/p/original/sgTAWJFaB2kBvdQxRGabYFiQqEK.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/n0ceI4oS4wCad1GPvnf4FMBwBie.jpg" },
        new Pelicula { PeliculaId = 6, Title = "Pulp Fiction", Description = "Varias historias violentas y absurdas en Los Ángeles se entrelazan, mostrando la crudeza, el humor negro y lo impredecible del destino.", Director = "Quentin Tarantino", Genero = "Suspense, Crimen", Clasificacion = "18", Duration = 154, ImageUrl = "https://image.tmdb.org/t/p/original/znOzYX1hOzt1Gd1Oybyan3hII3U.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/5kD1o6exM1RbauVLJjtNzseiM1Q.jpg" },
        new Pelicula { PeliculaId = 7, Title = "Cadena perpetua", Description = "Andy Dufresne, preso por un crimen que no cometió, forma un lazo con otro recluso mientras busca esperanza y redención en prisión.", Director = "Frank Darabont", Genero = "Drama, Crimen", Clasificacion = "12", Duration = 142, ImageUrl = "https://image.tmdb.org/t/p/original/uRRTV7p6l2ivtODWJVVAMRrwTn2.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/wPU78OPN4BYEgWYdXyg0phMee64.jpg" },
        new Pelicula { PeliculaId = 8, Title = "Forrest Gump", Description = "Forrest Gump, un hombre de corazón puro, vive aventuras extraordinarias que, sin proponérselo, transforman la historia de Estados Unidos.", Director = "Robert Zemeckis", Genero = "Comedia, Drama, Romance", Clasificacion = "12", Duration = 142, ImageUrl = "https://image.tmdb.org/t/p/original/oiqKEhEfxl9knzWXvWecJKN3aj6.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/tlEFuIlaxRPXIYVHXbOSAMCfWqk.jpg" },
        new Pelicula { PeliculaId = 9, Title = "El padrino", Description = "La familia Corleone, poderosa en el crimen organizado, enfrenta cambios y tragedias mientras el poder transforma a sus miembros.", Director = "Francis Ford Coppola", Genero = "Drama, Crimen", Clasificacion = "16", Duration = 175, ImageUrl = "https://image.tmdb.org/t/p/original/5HlLUsmsv60cZVTzVns9ICZD6zU.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/es402xnlOLE6jhbiisVwwlazrnM.jpg" },
        new Pelicula { PeliculaId = 10, Title = "El señor de los anillos: La comunidad del anillo", Description = "Frodo y sus amigos emprenden una misión peligrosa para destruir el Anillo Único y evitar que Sauron lo recupere.", Director = "Peter Jackson", Genero = "Aventura, Fantasía, Acción", Clasificacion = "12", Duration = 178, ImageUrl = "https://image.tmdb.org/t/p/original/9xtH1RmAzQ0rrMBNUMXstb2s3er.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/z51Wzj94hvAIsWfknifKTqKJRwp.jpg" },
        new Pelicula { PeliculaId = 11, Title = "Gladiator", Description = "Traicionado y esclavizado, Máximo busca vengar a su familia mientras se convierte en un héroe de la arena en el Coliseo romano.", Director = "Ridley Scott", Genero = "Acción, Drama, Aventura", Clasificacion = "12", Duration = 155, ImageUrl = "https://image.tmdb.org/t/p/original/o6XhzKghQFliN49iE4M4RX94PTB.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/jhk6D8pim3yaByu1801kMoxXFaX.jpg" },
        new Pelicula { PeliculaId = 12, Title = "Salvar al soldado Ryan", Description = "En la Segunda Guerra Mundial, soldados liderados por el Capitán Miller buscan rescatar al soldado Ryan tras líneas enemigas.", Director = "Steven Spielberg", Genero = "Drama, Historia, Bélica", Clasificacion = "12", Duration = 169, ImageUrl = "https://image.tmdb.org/t/p/original/dcKfD8xWf8XnS3tHVp7v331wdNT.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/9oguZXYDMH6X4LOOLiXFf1EtQzP.jpg" },
        new Pelicula { PeliculaId = 13, Title = "El rey león", Description = "Simba, un joven león, debe superar sus miedos para reclamar su lugar como rey tras la trágica muerte de su padre en la sabana africana.", Director = "Jon Favreau", Genero = "Aventura, Drama, Familia", Clasificacion = "Todos los públicos", Duration = 88, ImageUrl = "https://image.tmdb.org/t/p/original/8zkIFKjfajIzTo9U0jDTf2spCzl.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/2XWhIg0aWX83ntm5Oq8w15vfB9c.jpg" },
        new Pelicula { PeliculaId = 14, Title = "Avatar", Description = "Jake Sully, un exmarine parapléjico, se infiltra en un mundo alienígena y lucha por proteger a sus habitantes de los intereses humanos.", Director = "James Cameron", Genero = "Acción, Aventura, Fantasía, Ciencia ficción", Clasificacion = "7", Duration = 162, ImageUrl = "https://image.tmdb.org/t/p/original/tXmTHdrZgNsULqCbThK2Dt2X9Wt.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/tvaFREoQ7ssrPcwfz7Xbj2A7B2t.jpg" },
        new Pelicula { PeliculaId = 15, Title = "Jurassic Park", Description = "En un parque de dinosaurios, el caos surge cuando fallan las medidas de seguridad y los depredadores cazan humanos.", Director = "Steven Spielberg", Genero = "Aventura, Ciencia ficción", Clasificacion = "12", Duration = 127, ImageUrl = "https://image.tmdb.org/t/p/original/1r8TWaAExHbFRzyqT3Vcbq1XZQb.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/mzFjAVLdZAD6UDT5BMRItHL5IVf.jpg" },
        new Pelicula { PeliculaId = 16, Title = "El silencio de los corderos", Description = "Clarice Starling, agente del FBI, busca la ayuda del astuto Hannibal Lecter para capturar a un asesino en serie que aterroriza la región.", Director = "Jonathan Demme", Genero = "Crimen, Drama, Suspense", Clasificacion = "18", Duration = 118, ImageUrl = "https://image.tmdb.org/t/p/original/8FdQQ3cUCs9goEOr1qUFaHackoJ.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/mW2hISHs00yihyYQBqahGYoCcHy.jpg" },
        new Pelicula { PeliculaId = 17, Title = "La lista de Schindler", Description = "Oskar Schindler salva a miles de judíos durante el Holocausto empleándolos en su fábrica y arriesgando todo por la humanidad.", Director = "Steven Spielberg", Genero = "Drama, Historia, Bélica", Clasificacion = "12", Duration = 195, ImageUrl = "https://image.tmdb.org/t/p/original/xnvHaMFNXzemoH4uXHDMtKnpF7l.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/zb6fM1CX41D9rF9hdgclu0peUmy.jpg" },
        new Pelicula { PeliculaId = 18, Title = "Regreso al futuro", Description = "Marty McFly viaja accidentalmente al pasado y debe asegurarse que sus padres se conozcan para proteger su propia existencia.", Director = "Robert Zemeckis", Genero = "Aventura, Comedia, Ciencia ficción", Clasificacion = "Todos los públicos", Duration = 116, ImageUrl = "https://image.tmdb.org/t/p/original/qqWOr3lDYZvywoP7PeFwp8u1NVv.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/hxSB02ksqnkXY4hPGAXqgO2fL01.jpg" },
        new Pelicula { PeliculaId = 19, Title = "La guerra de las galaxias", Description = "Luke Skywalker, un joven granjero, se une a un grupo de rebeldes en su lucha contra el Imperio Galáctico y la Estrella de la Muerte.", Director = "George Lucas", Genero = "Aventura, Acción, Ciencia ficción", Clasificacion = "7", Duration = 121, ImageUrl = "https://image.tmdb.org/t/p/original/hkHIcwbe39ywsT3CeJcFZT1RozG.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/4rjkUgFPDrQEOr1NnZJ5FSKzCIX.jpg" },
        new Pelicula { PeliculaId = 20, Title = "La milla verde", Description = "Un guardia de prisión descubre que un preso en el corredor de la muerte tiene un don especial, cuestionando la justicia de su ejecución.", Director = "Frank Darabont", Genero = "Fantasía, Drama, Crimen", Clasificacion = "12", Duration = 189, ImageUrl = "https://image.tmdb.org/t/p/original/94lRG8bVMnbi3VRS8UXAhlPmaxP.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/amZavErrjrdgDwhsIdpWxHNenIx.jpg" },
        new Pelicula { PeliculaId = 21, Title = "Black Hawk Derribado", Description = "Soldados atrapados en Mogadiscio tras la caída de dos helicópteros luchan por sobrevivir contra fuerzas hostiles.", Director = "Ridley Scott", Genero = "Acción, Bélica, Historia", Clasificacion = "12", Duration = 144, ImageUrl = "https://image.tmdb.org/t/p/original/5chWdaHyaHWd5KaVxK94lbTDCdC.jpg", CartelUrl = "https://image.tmdb.org/t/p/original/o6f1sJ0ZYg6TA2tMgoHdupB68QB.jpg" }
    };

    // Obtener todas las películas
    [HttpGet]
    public ActionResult<List<Pelicula>> GetPeliculas()
    {
        return Ok(Peliculas);
    }

    // Obtener una película por ID
    [HttpGet("{peliculaId}")]
    public ActionResult<Pelicula> GetPeliculaById(int peliculaId)
    {
        var pelicula = Peliculas.FirstOrDefault(p => p.PeliculaId == peliculaId);
        if (pelicula == null)
        {
            return NotFound($"Película con ID {peliculaId} no encontrada.");
        }
        return Ok(pelicula);
    }

    // Buscar películas por género
    [HttpGet("buscar")]
    public ActionResult<List<Pelicula>> GetPeliculasByGenero([FromQuery] string genero)
    {
        var peliculasFiltradas = Peliculas.Where(p => p.Genero.Contains(genero, StringComparison.OrdinalIgnoreCase)).ToList();
        if (!peliculasFiltradas.Any())
        {
            return NotFound($"No se encontraron películas con el género '{genero}'.");
        }
        return Ok(peliculasFiltradas);
    }
}