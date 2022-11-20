using CRUD_net2.models;
using EF_02.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sancionesController : ControllerBase
    {
        private readonly CRUD_EF_2Context _context;
        public sancionesController(CRUD_EF_2Context context)
        {
            _context = context;
        }
        // GET: api/<sancionesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<sancionesDTO>>> Get()
        {
            try
            {
                var sancion = await _context.Sanciones.Select(x =>
                new sancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    ConductorId = x.ConductorId,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor= x.Valor,
                }).ToListAsync();
                if (sancion == null)
                {
                    return NotFound();
                }
                else
                {
                    return sancion;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // GET api/<sancionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<sancionesDTO>> Get(int id)
        {
            try
            {
                var conductor = await _context.Sanciones.Select(x =>
                new sancionesDTO
                {
                    Id = x.Id,
                    FechaActual = x.FechaActual,
                    ConductorId = x.ConductorId,
                    Sancion = x.Sancion,
                    Observacion = x.Observacion,
                    Valor = x.Valor,
                }).FirstOrDefaultAsync(x => x.Id == id);
                if (conductor == null)
                {
                    return NotFound();
                }
                else
                {
                    return conductor;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        // POST api/<sancionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(sancionesDTO sancion)
        {
            try
            {
                var entity = new Sancione()
                {



                   
                    ConductorId = sancion.ConductorId,
                    Sancion = sancion.Sancion,
                    Observacion = sancion.Observacion,
                    Valor = sancion.Valor
                };
                _context.Sanciones.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<sancionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(sancionesDTO sancion)
        {
            try
            {
                var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.Id == sancion.Id);
                
                entity.Id= sancion.Id;
                entity.Sancion = sancion.Sancion;
                entity.Observacion = sancion.Observacion;
                entity.Valor = sancion.Valor;
                
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        // DELETE api/<sancionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var entity = new Sancione()
                {
                    Id = id
                };
                _context.Sanciones.Attach(entity);
                _context.Sanciones.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.OK;
        }
    }
}
