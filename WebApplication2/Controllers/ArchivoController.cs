using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoController : ControllerBase
    {
        private readonly ETITCContext _context;

        public ArchivoController(ETITCContext context)
        {
            _context = context;
        }

        // GET: api/Archivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Archivo>>> GetArchivos()
        {
            return await _context.Archivos.ToListAsync();
        }

        // GET: api/Archivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivo>> GetArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);

            if (archivo == null)
            {
                return NotFound();
            }

            return archivo;
        }

        // PUT: api/Archivo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivo(int id, Archivo archivo)
        {
            if (id != archivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(archivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        // POST: api/Archivo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public ActionResult PostArchivo([FromForm]List<IFormFile> files)
        {
            List<Archivo> archivos = new List<Archivo>();
            try
            {
                if (files.Count > 0)
                {
                    foreach (var file in files)
                    {
                        Archivo archivo = new Archivo();
                        var filePath = "C:\\Users\\User\\source\\repos\\WebApplication2\\WebApplication2\\uploads\\"+file.FileName; 
                        using (var stream = System.IO.File.Create(filePath))
                        {
                            file.CopyToAsync(stream); 
                        }
                         
                        archivo.Nombre = Path.GetFileNameWithoutExtension(file.FileName);
                        archivo.Ubicacion = filePath; 
                        archivos.Add(archivo);  
                    }
                    _context.Archivos.AddRange(archivos);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); 
            }
            return Ok(archivos); 
            
        }

        // DELETE: api/Archivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivo(int id)
        {
            var archivo = await _context.Archivos.FindAsync(id);
            if (archivo == null)
            {
                return NotFound();
            }

            _context.Archivos.Remove(archivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchivoExists(int id)
        {
            return _context.Archivos.Any(e => e.Id == id);
        }
    }
}
