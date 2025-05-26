
using Microsoft.AspNetCore.Mvc;
using MandrilAPI.Models;
using MandrilAPI.Services;
using MandrilAPI.Helpers;


namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/Mandril/{MandrilId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet] //Get para obtener todas las habilidades de un mandril
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int MandrilId)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == MandrilId);

        if (mandril == null)
        
            return NotFound(Mensajes.Mandril.NotFound);
        return Ok(mandril.Habilidades);

    }

    [HttpGet("{habilidadId}")] //Get para obtener una habilidad específica de un mandril
    public ActionResult<Habilidad?> GetHabilidad(int MandrilId, int habilidadId)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == MandrilId);
        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);
        if (habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.NotFound);
        }
        return Ok(habilidad);
    }

    [HttpPost] //Post para agregar una nueva habilidad a un mandril
    public ActionResult<Habilidad> PostHabilidad(int mandrilId, Habilidad habilidadInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }
        var HabilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Name == habilidadInsert.Name);

        if (HabilidadExistente != null)
        {
            return BadRequest(Mensajes.Habilidad.BadRequest);
        }
        var MaxHabilidadId = mandril.Habilidades?.Max(h => h.Id) ?? 0;
        var nuevaHabilidad = new Habilidad()
        {
            Id = MaxHabilidadId + 1,
            Name = habilidadInsert.Name,
            Potencia = habilidadInsert.Potencia
        };
        mandril.Habilidades?.Add(nuevaHabilidad);
        return CreatedAtAction(nameof(GetHabilidad), new { MandrilId = mandrilId, habilidadId = nuevaHabilidad.Id }, nuevaHabilidad);

    }

    [HttpPut("{HabilidadId}")] //Put para actualizar una habilidad de un mandril
    public ActionResult<Habilidad?> PutHabilidad(int MandrilId, int HabilidadId, Habilidad habilidadInsert)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == MandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == HabilidadId);

        if (habilidadExistente == null)
        {
            return NotFound(Mensajes.Habilidad.NotFound);
        }

        var habilidadConMismoNombre = mandril.Habilidades?.FirstOrDefault(h => h.Name == habilidadInsert.Name && h.Id != HabilidadId);
        if (habilidadConMismoNombre != null)
        {
            return BadRequest(Mensajes.Habilidad.BadRequest);
        }

        habilidadExistente.Name = habilidadInsert.Name;
        habilidadExistente.Potencia = habilidadInsert.Potencia;

        return NoContent();
    }

    [HttpDelete("{HabilidadId}")] //Delete para eliminar una habilidad de un mandril
    public ActionResult DeleteHabilidad(int mandrilId, int HabilidadId)
    {
        var mandril = MandrilDataStore.Current.Mandriles?.FirstOrDefault(m => m.Id == mandrilId);

        if (mandril == null)
        {
            return NotFound(Mensajes.Mandril.NotFound);
        }

        var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == HabilidadId);

        if (habilidad == null)
        {
            return NotFound(Mensajes.Habilidad.NotFound);
        }

        mandril.Habilidades?.Remove(habilidad);
        return NoContent();
    }
    
}