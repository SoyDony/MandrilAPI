

using static MandrilAPI.Models.Habilidad;

namespace MandrilAPI.Models;

public class HabilidadInsert // Clase que representa una habilidad de un mandril para inserción
{
    public string Name { get; set; } = string.Empty;

    public EPotencia Potencia { get; set; }


}