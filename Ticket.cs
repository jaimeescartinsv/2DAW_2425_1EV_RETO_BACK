public class Ticket
{
    public int Id { get; set; }
    public Funcion Funcion { get; set; }  // Objeto Función relacionado
    public Funcion FuncionId { get; set; }  // Relación con la función seleccionada
    public string UsuarioId { get; set; }  // ID del usuario que compra el ticket
    public DateTime FechaDeCompra { get; set; }  // Fecha de compra del ticket
    public int ScreeningId { get; internal set; }
}