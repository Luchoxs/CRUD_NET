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
    public class matriculaController : ControllerBase
    {
        private readonly CRUD_EF_2Context _context;
        

        public matriculaController(CRUD_EF_2Context context
            )
        {
            _context = context;
        }
        // GET: api/<matriculaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<matriclaDTO>>> Get()
        {
            try
            {
                var matriculas = await _context.Matriculas.Select(x => new matriclaDTO
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo
                }).ToListAsync(); 
                if (matriculas == null)
                {
                    return NotFound();
                }
                else
                {
                    return matriculas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET api/<matriculaController>/5
        [HttpGet("{numero}")]
        public async Task<ActionResult<matriclaDTO>> Get(string numero)
        {
            try
            {
                //numero=int.Parse(Id); 
                var matriculas = await _context.Matriculas.Select(x => new matriclaDTO
                {
                    Id = x.Id,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo
                }).FirstOrDefaultAsync(x => x.Numero == numero);
                if (matriculas == null)
                {
                    return NotFound();
                }
                else
                {
                    return matriculas;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST api/<matriculaController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(matriclaDTO matriculas)
        {
            try
            {
                var entity = new Matricula()
                {

                    Numero = matriculas.Numero,
                    FechaExpedicion = matriculas.FechaExpedicion,
                    ValidaHasta = matriculas.ValidaHasta,
                    Activo = matriculas.Activo
                };
                _context.Matriculas.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.Created;
        }

        // PUT api/<matriculaController>/5
        [HttpPut("{numero}")]
        public async Task<HttpStatusCode> Put(matriclaDTO matriculas)
        {
            try
            {
                var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Numero == matriculas.Numero);
                entity.Numero = matriculas.Numero;
                entity.FechaExpedicion = matriculas.FechaExpedicion;
                entity.ValidaHasta = matriculas.ValidaHasta;
                entity.Activo = matriculas.Activo;
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.NoContent;
        }

        // DELETE api/<matriculaController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var matricula = _context.Matriculas.Find(id);
                if (matricula.Activo == false)
                {
                    return HttpStatusCode.BadRequest;
                }
                else
                {
                    var entity = await _context.Matriculas.FirstOrDefaultAsync(v => v.Id == id);
                    entity.Activo = false;
                    _context.Entry(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    //_context.Entry(matricula).State = EntityState.Deleted;
                    //_context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return HttpStatusCode.OK;
        }
    }
}
