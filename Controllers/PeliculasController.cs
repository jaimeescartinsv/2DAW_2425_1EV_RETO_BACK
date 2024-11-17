using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/peliculas")]
public class PeliculasController : ControllerBase
{
    private static List<Pelicula> Peliculas = new List<Pelicula>
    {
        new Pelicula { PeliculaId = 1, Title = "Inception", Description = "Dom Cobb, un ladrón experto en la extracción de secretos del subconsciente, se enfrenta al desafío de realizar la tarea inversa: implantar una idea en la mente de otra persona.", Duration = 148, ImageUrl = "https://image.tmdb.org/t/p/original/tXQvtRWfkUUnWJAn2tN3jERIUG.jpg" },
        new Pelicula { PeliculaId = 2, Title = "Interstellar", Description = "En un futuro sombrío donde los recursos de la Tierra se están agotando, un grupo de astronautas se embarca en una misión para explorar planetas potencialmente habitables en otra galaxia.", Duration = 169, ImageUrl = "https://image.tmdb.org/t/p/original/nrSaXF39nDfAAeLKksRCyvSzI2a.jpg" },
        new Pelicula { PeliculaId = 3, Title = "The Dark Knight", Description = "Bruce Wayne, bajo la identidad de Batman, debe enfrentarse a su enemigo más peligroso, el Joker, quien busca sumir a Gotham en el caos absoluto.", Duration = 152, ImageUrl = "https://image.tmdb.org/t/p/original/8QDQExnfNFOtabLDKqfDQuHDsIg.jpg" },
        new Pelicula { PeliculaId = 4, Title = "The Matrix", Description = "Neo, un hacker, descubre la verdad sobre la Matrix, una simulación creada por máquinas para controlar a la humanidad, y se une a la lucha para liberar a la humanidad.", Duration = 136, ImageUrl = "https://image.tmdb.org/t/p/original/qK76PKQLd6zlMn0u83Ej9YQOqPL.jpg" },
        new Pelicula { PeliculaId = 5, Title = "Fight Club", Description = "Un hombre insomne se encuentra con un vendedor de jabón carismático y juntos crean un club de pelea clandestino que se convierte en algo mucho más peligroso.", Duration = 139, ImageUrl = "https://image.tmdb.org/t/p/original/sgTAWJFaB2kBvdQxRGabYFiQqEK.jpg" },
        new Pelicula { PeliculaId = 6, Title = "Pulp Fiction", Description = "La vida de varios personajes de Los Ángeles se entrelaza en una serie de historias violentas y absurdas que exponen la crudeza y lo impredecible del destino.", Duration = 154, ImageUrl = "https://image.tmdb.org/t/p/original/znOzYX1hOzt1Gd1Oybyan3hII3U.jpg" },
        new Pelicula { PeliculaId = 7, Title = "The Shawshank Redemption", Description = "Andy Dufresne, un banquero condenado por asesinato, forma un vínculo inesperado con otro preso y busca la redención y la esperanza dentro de los muros de Shawshank.", Duration = 142, ImageUrl = "https://image.tmdb.org/t/p/original/uRRTV7p6l2ivtODWJVVAMRrwTn2.jpg" },
        new Pelicula { PeliculaId = 8, Title = "Forrest Gump", Description = "La historia de Forrest Gump, un hombre con un corazón puro, que vive experiencias extraordinarias y cambia el curso de la historia estadounidense sin proponérselo.", Duration = 142, ImageUrl = "https://image.tmdb.org/t/p/original/oiqKEhEfxl9knzWXvWecJKN3aj6.jpg" },
        new Pelicula { PeliculaId = 9, Title = "The Godfather", Description = "La crónica de la familia Corleone, una de las más poderosas del crimen organizado en Nueva York, y de cómo el poder cambia a sus miembros a lo largo de las décadas.", Duration = 175, ImageUrl = "https://image.tmdb.org/t/p/original/5HlLUsmsv60cZVTzVns9ICZD6zU.jpg" },
        new Pelicula { PeliculaId = 10, Title = "The Lord of the Rings: The Fellowship of the Ring", Description = "Frodo, un hobbit de la Comarca, emprende una peligrosa misión para destruir el Anillo Único y evitar que caiga en manos de Sauron, el señor oscuro.", Duration = 178, ImageUrl = "https://image.tmdb.org/t/p/original/9xtH1RmAzQ0rrMBNUMXstb2s3er.jpg" },
        new Pelicula { PeliculaId = 11, Title = "Gladiator", Description = "Máximo Décimo Meridio, un general romano traicionado y convertido en esclavo, busca vengar la muerte de su familia en la arena del Coliseo.", Duration = 155, ImageUrl = "https://image.tmdb.org/t/p/original/o6XhzKghQFliN49iE4M4RX94PTB.jpg" },
        new Pelicula { PeliculaId = 12, Title = "Saving Private Ryan", Description = "Durante la Segunda Guerra Mundial, un grupo de soldados liderados por el Capitán Miller se embarca en una peligrosa misión para encontrar y rescatar al soldado James Ryan.", Duration = 169, ImageUrl = "https://image.tmdb.org/t/p/original/dcKfD8xWf8XnS3tHVp7v331wdNT.jpg" },
        new Pelicula { PeliculaId = 13, Title = "The Lion King", Description = "Simba, un joven león, debe reclamar su lugar como rey tras la trágica muerte de su padre, enfrentando su destino y superando sus miedos.", Duration = 88, ImageUrl = "https://image.tmdb.org/t/p/original/8zkIFKjfajIzTo9U0jDTf2spCzl.jpg" },
        new Pelicula { PeliculaId = 14, Title = "Avatar", Description = "Jake Sully, un exmarine parapléjico, se infiltra en un mundo alienígena y lucha por proteger a sus habitantes del intento humano de extraer sus recursos.", Duration = 162, ImageUrl = "https://image.tmdb.org/t/p/original/tXmTHdrZgNsULqCbThK2Dt2X9Wt.jpg" },
        new Pelicula { PeliculaId = 15, Title = "Jurassic Park", Description = "Un parque temático donde dinosaurios clonados cobran vida se convierte en una trampa mortal cuando las medidas de seguridad fallan y los depredadores escapan.", Duration = 127, ImageUrl = "https://image.tmdb.org/t/p/original/1r8TWaAExHbFRzyqT3Vcbq1XZQb.jpg" },
        new Pelicula { PeliculaId = 16, Title = "The Silence of the Lambs", Description = "La agente del FBI Clarice Starling busca la ayuda de Hannibal Lecter, un astuto asesino, para capturar a un peligroso asesino en serie.", Duration = 118, ImageUrl = "https://image.tmdb.org/t/p/original/8FdQQ3cUCs9goEOr1qUFaHackoJ.jpg" },
        new Pelicula { PeliculaId = 17, Title = "Schindler's List", Description = "La historia real de Oskar Schindler, un empresario alemán que salvó la vida de miles de judíos durante el Holocausto empleándolos en su fábrica.", Duration = 195, ImageUrl = "https://image.tmdb.org/t/p/original/xnvHaMFNXzemoH4uXHDMtKnpF7l.jpg" },
        new Pelicula { PeliculaId = 18, Title = "Back to the Future", Description = "Marty McFly, un adolescente de los años 80, viaja accidentalmente al pasado y debe asegurarse de que sus padres se conozcan para evitar cambiar su propia existencia.", Duration = 116, ImageUrl = "https://image.tmdb.org/t/p/original/ntKTiz7tp8xath8qdZLvn0eY5oy.jpg" },
        new Pelicula { PeliculaId = 19, Title = "Star Wars: A New Hope", Description = "Luke Skywalker, un joven granjero, se une a un grupo de rebeldes en su lucha contra el Imperio Galáctico y su superarma, la Estrella de la Muerte.", Duration = 121, ImageUrl = "https://image.tmdb.org/t/p/original/hkHIcwbe39ywsT3CeJcFZT1RozG.jpg" },
        new Pelicula { PeliculaId = 20, Title = "The Green Mile", Description = "Un guardia de prisión descubre que un preso en el corredor de la muerte tiene un don especial, lo que le hace cuestionar la justicia de su ejecución.", Duration = 189, ImageUrl = "https://image.tmdb.org/t/p/original/94lRG8bVMnbi3VRS8UXAhlPmaxP.jpg" },
    };

    // Obtener todas las películas
    [HttpGet]
    public ActionResult<List<Pelicula>> GetPeliculas()
    {
        return Ok(Peliculas);
    }
}