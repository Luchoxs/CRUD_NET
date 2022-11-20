using CRUD_net2.models;
using EF_02.DTOs;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EF_02.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class conductorController : ControllerBase
    {
        private readonly CRUD_EF_2Context _context;

        public conductorController(CRUD_EF_2Context context
           )
        {
            _context = context;
        }
        // GET: api/<conductorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<conductorDTO>>> Get()
        {
            try
            {
                var matriculas = await _context.Conductors.Select(x => new conductorDTO
                {
                    Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Telefono=x.Telefono,
                    Email=x.Email,
                    FechaNacimiento=x.FechaNacimiento,
                    Activo= x.Activo,
                    IdMatricula=x.IdMatricula
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

        // GET api/<conductorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<conductorDTO>> Get(int id)
        {
            try
            {
                var conductor = await _context.Conductors.Select(x =>
                new conductorDTO
                {
                    Id = x.Id,
                    Identificacion = x.Identificacion,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    Direccion = x.Direccion,
                    Telefono = x.Telefono,
                    Email = x.Email,
                    FechaNacimiento = x.FechaNacimiento,
                    Activo = x.Activo,
                    IdMatricula = x.IdMatricula
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

        // POST api/<conductorController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(conductorDTO conductor)
        {
            try
            {
                var entity = new Conductor()
                {

                    
                    Identificacion = conductor.Identificacion,
                    Nombre = conductor.Nombre,
                    Apellidos = conductor.Apellidos,
                    Direccion = conductor.Direccion,
                    Telefono = conductor.Telefono,
                    Email = conductor.Email,
                    FechaNacimiento = conductor.FechaNacimiento,
                    Activo = conductor.Activo,
                    IdMatricula = conductor.IdMatricula
                };
                _context.Conductors.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<conductorController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(conductorDTO conductor)
        {
            try
            {
                var entity = await _context.Conductors.FirstOrDefaultAsync(v => v.Id == conductor.Id);
                entity.Id = conductor.Id;
                entity.Identificacion = conductor.Identificacion;
                entity.Nombre = conductor.Nombre;
                entity.Apellidos = conductor.Apellidos;
                entity.Direccion = conductor.Direccion;
                entity.Telefono = conductor.Telefono;
                entity.Email = conductor.Email;
                entity.FechaNacimiento = conductor.FechaNacimiento;
                entity.Activo = conductor.Activo;
                entity.IdMatricula = conductor.IdMatricula;

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return HttpStatusCode.Accepted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<conductorController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            try
            {
                var entity = new Conductor()
                {
                    Id = id
                };
                _context.Conductors.Attach(entity);
                _context.Conductors.Remove(entity);
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
