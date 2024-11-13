public class Ticket
{
    public int Id { get; set; }
    public int FuncionId { get; set; }  // Relación con la función seleccionada
    public Screening Funcion { get; set; }  // Objeto Función relacionado
    public string UsuarioId { get; set; }  // ID del usuario que compra el ticket
    public DateTime FechaDeCompra { get; set; }  // Fecha de compra del ticket
}