using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/peliculas")]
public class PeliculasController : ControllerBase
{
    private static List<Pelicula> Peliculas = new List<Pelicula>
    {
        new Pelicula { PeliculaId = 1, Title = "Origen", Description = "Dom Cobb roba secretos del subconsciente, pero enfrenta el reto inverso: implantar una idea en otra mente. Un reto único y peligroso.", Duration = 148, ImageUrl = "https://image.tmdb.org/t/p/original/tXQvtRWfkUUnWJAn2tN3jERIUG.jpg" },
        new Pelicula { PeliculaId = 2, Title = "Interstellar", Description = "Con la Tierra al borde del colapso, un grupo de astronautas emprende una misión para explorar planetas y salvar a la humanidad.", Duration = 169, ImageUrl = "https://image.tmdb.org/t/p/original/nrSaXF39nDfAAeLKksRCyvSzI2a.jpg" },
        new Pelicula { PeliculaId = 3, Title = "El caballero oscuro", Description = "Batman enfrenta al Joker, su enemigo más peligroso, quien busca llevar el caos absoluto a Gotham en un enfrentamiento épico y letal.", Duration = 152, ImageUrl = "https://image.tmdb.org/t/p/original/8QDQExnfNFOtabLDKqfDQuHDsIg.jpg" },
        new Pelicula { PeliculaId = 4, Title = "Matrix", Description = "Neo descubre que la Matrix es una simulación que controla a la humanidad y se une a la resistencia para liberar a todos de esta prisión.", Duration = 136, ImageUrl = "https://image.tmdb.org/t/p/original/qK76PKQLd6zlMn0u83Ej9YQOqPL.jpg" },
        new Pelicula { PeliculaId = 5, Title = "El club de la lucha", Description = "Un insomne y un vendedor de jabón fundan un club clandestino de peleas que se transforma en una organización peligrosa y subversiva.", Duration = 139, ImageUrl = "https://image.tmdb.org/t/p/original/sgTAWJFaB2kBvdQxRGabYFiQqEK.jpg" },
        new Pelicula { PeliculaId = 6, Title = "Pulp Fiction", Description = "Varias historias violentas y absurdas en Los Ángeles se entrelazan, mostrando la crudeza, el humor negro y lo impredecible del destino.", Duration = 154, ImageUrl = "https://image.tmdb.org/t/p/original/znOzYX1hOzt1Gd1Oybyan3hII3U.jpg" },
        new Pelicula { PeliculaId = 7, Title = "Cadena perpetua", Description = "Andy Dufresne, preso por un crimen que no cometió, forma un lazo con otro recluso mientras busca esperanza y redención en prisión.", Duration = 142, ImageUrl = "https://image.tmdb.org/t/p/original/uRRTV7p6l2ivtODWJVVAMRrwTn2.jpg" },
        new Pelicula { PeliculaId = 8, Title = "Forrest Gump", Description = "Forrest Gump, un hombre de corazón puro, vive aventuras extraordinarias que, sin proponérselo, transforman la historia de Estados Unidos.", Duration = 142, ImageUrl = "https://image.tmdb.org/t/p/original/oiqKEhEfxl9knzWXvWecJKN3aj6.jpg" },
        new Pelicula { PeliculaId = 9, Title = "El padrino", Description = "La familia Corleone, poderosa en el crimen organizado, enfrenta cambios y tragedias mientras el poder transforma a sus miembros.", Duration = 175, ImageUrl = "https://image.tmdb.org/t/p/original/5HlLUsmsv60cZVTzVns9ICZD6zU.jpg" },
        new Pelicula { PeliculaId = 10, Title = "El señor de los anillos: La comunidad del anillo", Description = "Frodo y sus amigos emprenden una misión peligrosa para destruir el Anillo Único y evitar que Sauron, el señor oscuro, lo recupere.", Duration = 178, ImageUrl = "https://image.tmdb.org/t/p/original/9xtH1RmAzQ0rrMBNUMXstb2s3er.jpg" },
        new Pelicula { PeliculaId = 11, Title = "Gladiator", Description = "Traicionado y esclavizado, Máximo busca vengar a su familia mientras se convierte en un héroe de la arena en el Coliseo romano.", Duration = 155, ImageUrl = "https://image.tmdb.org/t/p/original/o6XhzKghQFliN49iE4M4RX94PTB.jpg" },
        new Pelicula { PeliculaId = 12, Title = "Salvar al soldado Ryan", Description = "En la Segunda Guerra Mundial, un grupo de soldados liderados por el Capitán Miller buscan rescatar al soldado Ryan tras líneas enemigas.", Duration = 169, ImageUrl = "https://image.tmdb.org/t/p/original/dcKfD8xWf8XnS3tHVp7v331wdNT.jpg" },
        new Pelicula { PeliculaId = 13, Title = "El rey león", Description = "Simba, un joven león, debe superar sus miedos para reclamar su lugar como rey tras la trágica muerte de su padre en la sabana africana.", Duration = 88, ImageUrl = "https://image.tmdb.org/t/p/original/8zkIFKjfajIzTo9U0jDTf2spCzl.jpg" },
        new Pelicula { PeliculaId = 14, Title = "Avatar", Description = "Jake Sully, un exmarine parapléjico, se infiltra en un mundo alienígena y lucha por proteger a sus habitantes de los intereses humanos.", Duration = 162, ImageUrl = "https://image.tmdb.org/t/p/original/tXmTHdrZgNsULqCbThK2Dt2X9Wt.jpg" },
        new Pelicula { PeliculaId = 15, Title = "Jurassic Park", Description = "En un parque de dinosaurios, el caos surge cuando fallan las medidas de seguridad y los depredadores cazan humanos.", Duration = 127, ImageUrl = "https://image.tmdb.org/t/p/original/1r8TWaAExHbFRzyqT3Vcbq1XZQb.jpg" },
        new Pelicula { PeliculaId = 16, Title = "El silencio de los corderos", Description = "Clarice Starling, agente del FBI, busca la ayuda del astuto Hannibal Lecter para capturar a un asesino en serie que aterroriza la región.", Duration = 118, ImageUrl = "https://image.tmdb.org/t/p/original/8FdQQ3cUCs9goEOr1qUFaHackoJ.jpg" },
        new Pelicula { PeliculaId = 17, Title = "La lista de Schindler", Description = "Oskar Schindler salva a miles de judíos durante el Holocausto empleándolos en su fábrica y arriesgando todo por la humanidad.", Duration = 195, ImageUrl = "https://image.tmdb.org/t/p/original/xnvHaMFNXzemoH4uXHDMtKnpF7l.jpg" },
        new Pelicula { PeliculaId = 18, Title = "Regreso al futuro", Description = "Marty McFly viaja accidentalmente al pasado y debe asegurar que sus padres se conozcan para proteger su propia existencia.", Duration = 116, ImageUrl = "https://image.tmdb.org/t/p/original/ntKTiz7tp8xath8qdZLvn0eY5oy.jpg" },
        new Pelicula { PeliculaId = 19, Title = "La guerra de las galaxias", Description = "Luke Skywalker, un joven granjero, se une a un grupo de rebeldes en su lucha contra el Imperio Galáctico y su superarma, la Estrella de la Muerte.", Duration = 121, ImageUrl = "https://image.tmdb.org/t/p/original/hkHIcwbe39ywsT3CeJcFZT1RozG.jpg" },
        new Pelicula { PeliculaId = 20, Title = "La milla verde", Description = "Un guardia de prisión descubre que un preso en el corredor de la muerte tiene un don especial, lo que le hace cuestionar la justicia de su ejecución.", Duration = 189, ImageUrl = "https://image.tmdb.org/t/p/original/94lRG8bVMnbi3VRS8UXAhlPmaxP.jpg" },
    };

    // Obtener todas las películas
    [HttpGet]
    public ActionResult<List<Pelicula>> GetPeliculas()
    {
        return Ok(Peliculas);
    }
}