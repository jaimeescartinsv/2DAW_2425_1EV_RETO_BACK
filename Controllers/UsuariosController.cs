using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    public static List<Usuario> Usuarios = new List<Usuario>
    {
        new Usuario { UsuarioId = 1, Nombre = "Jaime Escartín", Correo = "jaime.escartin@example.com", Contrasena = "1234" },
        new Usuario { UsuarioId = 2, Nombre = "Gabriel Galán", Correo = "gabriel.galan@example.com", Contrasena = "1234" }
    };

    // Obtener todos los usuarios
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(Usuarios);
    }

    // Obtener un usuario por ID
    [HttpGet("{usuarioId}")]
    public ActionResult<Usuario> GetUsuarioById(int usuarioId)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {usuarioId} no encontrado.");
        }

        return Ok(usuario);
    }

    // Crear un nuevo usuario
    [HttpPost]
    public ActionResult<Usuario> CrearUsuario([FromBody] Usuario nuevoUsuario)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var usuarioExistente = Usuarios.FirstOrDefault(u => u.Correo.Equals(nuevoUsuario.Correo, StringComparison.OrdinalIgnoreCase));
        if (usuarioExistente != null)
        {
            return BadRequest(new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                title = "Bad Request",
                status = 400,
                detail = $"El usuario con el correo '{nuevoUsuario.Correo}' ya existe."
            });
        }

        if (Usuarios.Any(u => u.UsuarioId == nuevoUsuario.UsuarioId))
        {
            return BadRequest(new
            {
                type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                title = "Bad Request",
                status = 400,
                detail = $"El usuario con el ID {nuevoUsuario.UsuarioId} ya existe."
            });
        }

        nuevoUsuario.Tickets = nuevoUsuario.Tickets ?? new List<Ticket>();
        Usuarios.Add(nuevoUsuario);

        return CreatedAtAction(nameof(GetUsuarioById), new { usuarioId = nuevoUsuario.UsuarioId }, nuevoUsuario);
    }

    // Obtener los tickets de un usuario por ID
    [HttpGet("{usuarioId}/tickets")]
    public ActionResult<IEnumerable<Ticket>> GetTicketsByUsuarioId(int usuarioId)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {usuarioId} no encontrado.");
        }

        return Ok(usuario.Tickets);
    }

    // Eliminar un usuario por ID
    [HttpDelete("{usuarioId}")]
    public IActionResult DeleteUsuario(int usuarioId)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == usuarioId);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {usuarioId} no encontrado.");
        }

        Usuarios.Remove(usuario);
        return NoContent();
    }
}