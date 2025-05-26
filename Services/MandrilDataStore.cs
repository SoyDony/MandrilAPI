namespace MandrilAPI.Services;
using MandrilAPI.Models;

public class MandrilDataStore // Clase que representa el almacén de datos de mandriles
{
    public List<Mandril>? Mandriles { get; set; } // Lista de mandriles (propiedad que almacena los mandriles)
    // Esta lista contiene los mandriles que serán utilizados en la aplicación.
    
    public static MandrilDataStore Current { get; } = new MandrilDataStore();
    // Singleton instance of MandrilDataStore (creo una instancia única de MandrilDataStore)
    // para que pueda ser accedida desde cualquier parte de la aplicación.
    public MandrilDataStore()
    {
        Mandriles = new List<Mandril>
        {
            new Mandril
            {
                Id = 1,
                nombre = "Mini Mandril",
                apellido = "Rodriguez",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad() { Id = 1, Name = "Saltar", Potencia = Habilidad.EPotencia.Moderado },

                }
            },
            new Mandril()
            {
                Id = 2,
                nombre = "Spuer Mandril",
                apellido = "Fernandez",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad() { Id = 1, Name = "Saltar", Potencia = Habilidad.EPotencia.Moderado },
                    new Habilidad() { Id = 2, Name = "Camina", Potencia = Habilidad.EPotencia.Intenso },
                    new Habilidad() { Id = 3, Name = "Grita", Potencia = Habilidad.EPotencia.RePotente},
                }

            },
            new Mandril()
            {
                Id = 3,
                nombre = "Mega Mandril",
                apellido = "Legrand",
                Habilidades = new List<Habilidad>
                {
                    new Habilidad() { Id = 1, Name = "nadar", Potencia = Habilidad.EPotencia.Intenso },
                    new Habilidad() { Id = 2, Name = "Correr", Potencia = Habilidad.EPotencia.Extremo },
                    new Habilidad() { Id = 3, Name = "Vomitar", Potencia = Habilidad.EPotencia.RePotente},

                }

            }

        };
    }
}