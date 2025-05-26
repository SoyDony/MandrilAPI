namespace MandrilAPI.Models;

public class Mandril // Clase que representa un mandril
{
    public int Id { get; set; }

    public string nombre { get; set; } = string.Empty;

    public string apellido { get; set; } = string.Empty;

    public List<Habilidad>? Habilidades { get; set; } = new List<Habilidad>();


}
