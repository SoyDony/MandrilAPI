namespace MandrilAPI.Models;

public class Habilidad // Clase que representa una habilidad de un mandril
{
	public int Id { get; set; }

	public string Name { get; set; } = string.Empty;

	public EPotencia Potencia { get; set; }

	
	public enum EPotencia // Enumeración que representa los niveles de potencia de una habilidad
	{ 
		Suave, 
		Moderado,
		Intenso, 
		RePotente, 
		Extremo 
	}
	
	
	public Habilidad()
	{
	}
}
