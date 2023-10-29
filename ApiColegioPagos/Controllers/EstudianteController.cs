﻿using ApiColegioPagos.Data;
using ApiColegioPagos.Models;
using ApiColegioPagos.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiColegioPagos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly ApiColegioPagosDbContext _context;

        public EstudianteController(ApiColegioPagosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstudiantes()
        {
            try
            {
                List<Estudiante> estudiantes = await _context.Estudiantes.ToListAsync();
                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetEstudiante(int id)
        {
            try
            {
                Estudiante estudiante = await _context.Estudiantes.
                    FirstOrDefaultAsync(x => x.Est_id == id);

                //Validar que el estudiante exista
                if (estudiante != null)
                {
                    return Ok(estudiante);
                }

                return BadRequest("No existe el estudiante");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("cedula/{cedula}")]
        public async Task<IActionResult> GetEstudiante(string cedula)
        {
            try
            {
                Estudiante estudiante = await _context.Estudiantes.
                    FirstOrDefaultAsync(x => x.Est_cedula == cedula);

                //Verificar que el estudiante exista
                if (estudiante != null)
                {
                    return Ok(estudiante);
                }

                return BadRequest("No existe el estudiante");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SetEstudiante([FromBody] RegistroEstudiante est)
        {
            try
            {
                //Validar que el estudiante tenga los datos completos
                if (est == null || est.Est_cedula == null || est.Est_nombre == null || est.Est_direccion == null)
                {
                    return BadRequest("Datos incompletos");
                }

                Estudiante estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_cedula == est.Est_cedula);

                //Validar que el estudiante no exista
                if (estudiante != null)
                {
                    return BadRequest("La cédula del estudiante ya existe");
                }

                //Validar la cédula
                if (!Estudiante.validarCedula(est.Est_cedula)) return BadRequest("La cédula ingresada es incorrecta");

                estudiante = new Estudiante
                {
                    Est_activo = true,
                    Est_cedula = est.Est_cedula,
                    Est_direccion = est.Est_direccion,
                    Est_nombre = est.Est_nombre,
                    Pension = 2
                };

                await _context.Estudiantes.AddAsync(estudiante);
                await _context.SaveChangesAsync();

                estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_cedula == estudiante.Est_cedula);

                Global global = await _context.Globals.FirstOrDefaultAsync(x => x.Glo_id == 1);
                int cuota = global.Glo_valor;

                if(cuota > 0)
                {
                    cuota = est.paga? cuota - 1: cuota;
                }

                Pago pago = new Pago
                {
                    Estudiante = estudiante.Est_id,
                    Pag_cuota = cuota,
                    Pension = 1
                };

                await _context.Pagos.AddAsync(pago);
                await _context.SaveChangesAsync();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("cedula/{cedula}")]
        public async Task<IActionResult> UpdateEstudianteCedula(string cedula, [FromBody] ActualizacionEstudiante est)
        {
            try
            {
                if (est == null || cedula == null || est.Est_nombre == null || est.Est_direccion == null)
                {
                    return BadRequest("Datos incompletos");
                }

                Estudiante estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_cedula == cedula);

                if (estudiante == null)
                {
                    return BadRequest("El estudiante no existe");
                }

                Pension pension = await _context.Pensiones.FirstOrDefaultAsync(x => x.Pen_id == est.Pension);
                if (pension == null) return BadRequest("No existe la pensión elegida");

                estudiante.Est_nombre = est.Est_nombre;
                estudiante.Est_direccion = est.Est_direccion;
                estudiante.Pension = est.Pension;

                _context.Estudiantes.Update(estudiante);
                await _context.SaveChangesAsync();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateEstudianteId(int id, [FromBody] ActualizacionEstudiante est)
        {
            try
            {
                if (est == null || id < 1 || est.Est_nombre == null || est.Est_direccion == null)
                {
                    return BadRequest("Datos incompletos");
                }

                Estudiante estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);

                if (estudiante == null)
                {
                    return BadRequest("El estudiante no existe");
                }

                Pension pension = await _context.Pensiones.FirstOrDefaultAsync(x => x.Pen_id == est.Pension);
                if (pension == null) return BadRequest("No existe la pensión elegida");

                estudiante.Est_nombre = est.Est_nombre;
                estudiante.Est_direccion = est.Est_direccion;
                estudiante.Pension = est.Pension;

                _context.Estudiantes.Update(estudiante);
                await _context.SaveChangesAsync();

                return Ok(estudiante);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /* ??? Hacer métodos para activar y desactivar estudiante
            debe tomar en cuenta la tabla de pagos, especialmente que cuando se reinicie 
            cree un pago a la cuota actual
         */

        [HttpPatch("desactivar/{id}")]
        public async Task<IActionResult> desactivar(int id)
        {
            try
            {
                Estudiante est = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);
                if (est == null)
                {
                    return BadRequest("No existe el estudiante");
                }

                if (!est.Est_activo)
                {
                    return BadRequest("El estudiante ya se encuentra deshabilitado");
                }

                est.Est_activo = false;
                _context.Estudiantes.Update(est);
                await _context.SaveChangesAsync();

                return Ok(est);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /* bool paga hace referencia a si pagará la cuota actual o nó */
        [HttpPatch("activar/{id}")]
        public async Task<IActionResult> activar(int id, bool paga)
        {
            try
            {
                Estudiante est = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);

                //Verificar que el estudiante no es nulo
                if (est == null)
                {
                    return BadRequest("No existe el estudiante");
                }

                if (est.Est_activo)
                {
                    return BadRequest("El estudiante ya se encuentra habilitado");
                }

                /* Lógica de reingreso, actualizar cuotas*/

                Pago ultimoPago = (await _context.Pagos.ToListAsync())
                    .FindAll(x => x.Estudiante == id).OrderByDescending(x => x.Pag_cuota).First();

                int cuota = (await _context.Globals.FirstOrDefaultAsync(x => x.Glo_id == 1)).Glo_valor;

                if (paga && cuota > 1) cuota--;

                if(ultimoPago.Pag_cuota < cuota)
                {
                    Pago pago = new Pago
                    {
                        Estudiante = est.Est_id,
                        Pag_cuota = cuota,
                        Pension = 1
                    };

                    await _context.Pagos.AddAsync(pago);
                }

                est.Est_activo = true;
                _context.Estudiantes.Update(est);

                await _context.SaveChangesAsync();
                return Ok(est);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
