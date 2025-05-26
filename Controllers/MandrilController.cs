using Microsoft.AspNetCore.Mvc;
using MandrilAPI.Models;
using MandrilAPI.Services;
using MandrilAPI.Helpers;


namespace MandrilAPI.Controllers;

[ApiController]

[Route("api/[controller]")] // Ruta base para el controlador Mandril
public class MandrilController : ControllerBase

{
    [HttpGet] //Get para obtener todos los mandriles
    public ActionResult<IEnumerable<Mandril>?> GetMandriles()
    {
        return Ok(MandrilDataStore.Current.Mandriles);
    }

    [HttpGet("{MandrilId}")]

    public ActionResult<Mandril?> GetMandril(int MandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == MandrilId);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }
        return Ok(mandril);
    }

    [HttpPost] //Post para agregar un nuevo mandril
    public ActionResult<Mandril> PostMandril(MandrilInsert mandrilInsert)
    {
        var MaxMandrilId = MandrilDataStore.Current.Mandriles?.Max(m => m.Id) ?? 0;
        var MandrilNuevo = new Mandril()
        {
            Id = MaxMandrilId + 1,
            nombre = mandrilInsert.nombre,
            apellido = mandrilInsert.apellido,

        };

        MandrilDataStore.Current.Mandriles?.Add(MandrilNuevo);
        return CreatedAtAction(nameof(GetMandril), new { MandrilId = MandrilNuevo.Id }, MandrilNuevo);

    }

    [HttpPut("{MandrilId}")] //Put para actualizar un mandril existente

    public ActionResult<Mandril?> PutMandril([FromRoute] int MandrilId, [FromBody] MandrilInsert mandrilInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == MandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        mandril.nombre = mandrilInsert.nombre;
        mandril.apellido = mandrilInsert.apellido;

        return NoContent();
    }

    [HttpDelete("{MandrilId}")] //Delete para eliminar un mandril existente
    public ActionResult DeleteMandril(int MandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == MandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        MandrilDataStore.Current.Mandriles?.Remove(mandril);
        return NoContent();
    }

}


