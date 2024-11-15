using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    public static List<Usuario> Usuarios = new List<Usuario>
    {
        new Usuario { UsuarioId = 1, Nombre = "Jaime Escartín", Correo = "jaime.escartin@example.com" },
        new Usuario { UsuarioId = 2, Nombre = "Gabriel Galán", Correo = "gabriel.galan@example.com" }
    };

    // Obtener todos los usuarios
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(Usuarios);
    }

    // Obtener un usuario por ID
    [HttpGet("{usuarioId}")]
    public ActionResult<Usuario> GetUsuarioById(int id)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {id} no encontrado.");
        }

        return Ok(usuario);
    }

    // Crear un nuevo usuario
    [HttpPost]
    public ActionResult<Usuario> CrearUsuario([FromBody] Usuario nuevoUsuario)
    {
        if (Usuarios.Any(u => u.UsuarioId == nuevoUsuario.UsuarioId))
        {
            return BadRequest("El usuario con este ID ya existe.");
        }

        Usuarios.Add(nuevoUsuario);
        return CreatedAtAction(nameof(GetUsuarioById), new { id = nuevoUsuario.UsuarioId }, nuevoUsuario);
    }

    // Obtener los tickets de un usuario por ID
    [HttpGet("{usuarioId}/tickets")]
    public ActionResult<IEnumerable<Ticket>> GetTicketsByUsuarioId(int id)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {id} no encontrado.");
        }

        return Ok(usuario.Tickets);
    }

    // Eliminar un usuario por ID
    [HttpDelete("{usuarioId}")]
    public IActionResult DeleteUsuario(int id)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {id} no encontrado.");
        }

        Usuarios.Remove(usuario);
        return NoContent();
    }
}