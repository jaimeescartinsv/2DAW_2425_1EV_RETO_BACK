using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuariosController : ControllerBase
{
    public static List<Usuario> Usuarios = new List<Usuario>
    {
        new Usuario { UsuarioId = "1", Nombre = "Juan Perez", Correo = "juan.perez@example.com" },
        new Usuario { UsuarioId = "2", Nombre = "Maria Lopez", Correo = "maria.lopez@example.com" }
    };

    // Obtener todos los usuarios
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(Usuarios);
    }

    // Obtener un usuario por ID
    [HttpGet("{id}")]
    public ActionResult<Usuario> GetUsuarioById(string id)
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
    [HttpGet("{id}/tickets")]
    public ActionResult<IEnumerable<Ticket>> GetTicketsByUsuarioId(string id)
    {
        var usuario = Usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if (usuario == null)
        {
            return NotFound($"Usuario con ID {id} no encontrado.");
        }

        return Ok(usuario.Tickets);
    }

    // Eliminar un usuario por ID
    [HttpDelete("{id}")]
    public IActionResult DeleteUsuario(string id)
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