using ApiColegioPagos.Data;
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
            List<Estudiante> estudiantes = await _context.Estudiantes.ToListAsync();
            return Ok(estudiantes);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetEstudiante(int id)
        {
            Estudiante estudiante = await _context.Estudiantes.
                FirstOrDefaultAsync(x => x.Est_id == id);

            if (estudiante != null)
            {
                return Ok(estudiante);
            }

            return BadRequest("No existe el estudiante");
        }

        [HttpGet("cedula/{cedula}")]
        public async Task<IActionResult> GetEstudiante(string cedula)
        {
            Estudiante estudiante = await _context.Estudiantes.
                FirstOrDefaultAsync(x => x.Est_cedula == cedula);

            if (estudiante != null)
            {
                return Ok(estudiante);
            }

            return BadRequest("No existe el estudiante");
        }

        [HttpPost]
        public async Task<IActionResult> SetEstudiante([FromBody] RegistroEstudiante est)
        {
            //Validar que el estudiante tenga los datos completos
            if (est == null || est.Est_cedula == null || est.Est_nombre == null || est.Est_direccion == null)
            {
                return BadRequest("Datos incompletos");
            }

            Estudiante estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_cedula == est.Est_cedula);

            if (estudiante != null)
            {
                return BadRequest("La cédula del estudiante ya existe");
            }

            // ??? Revisar validaciones: cédula, pensión existente

            estudiante = new Estudiante
            {
                Est_activo = true,
                Est_cedula = est.Est_cedula,
                Est_direccion = est.Est_direccion,
                Est_nombre = est.Est_nombre,
                Pension = est.Pension
            };

            //Como añadir correctamente el estudiante cuando 
            await _context.Estudiantes.AddAsync(estudiante);
            await _context.SaveChangesAsync();

            estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_cedula == estudiante.Est_cedula);

            Global global = await _context.Globals.FirstOrDefaultAsync(x => x.Glo_id == 1);
            int cuota = global.Glo_valor;

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

        [HttpPut("cedula/{cedula}")]
        public async Task<IActionResult> UpdateEstudianteCedula(string cedula, [FromBody] Estudiante est)
        {
            if (est == null || est.Est_cedula == null || est.Est_nombre == null || est.Est_direccion == null)
            {
                return BadRequest("Datos incompletos");
            }

            Estudiante estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_cedula == cedula);

            if (estudiante == null)
            {
                return BadRequest("El estudiante no existe");
            }

            estudiante.Est_nombre = est.Est_nombre;
            estudiante.Est_direccion = est.Est_direccion;
            // ??? Validar que la pensión exista
            estudiante.Pension = est.Pension;

            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();

            return Ok(estudiante);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateEstudianteId(int id, [FromBody] Estudiante est)
        {
            if (est == null || est.Est_id == null || est.Est_nombre == null || est.Est_direccion == null)
            {
                return BadRequest("Datos incompletos");
            }

            Estudiante estudiante = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);

            if (estudiante == null)
            {
                return BadRequest("El estudiante no existe");
            }

            estudiante.Est_nombre = est.Est_nombre;
            estudiante.Est_direccion = est.Est_direccion;
            // ??? Validar que la pensión exista
            estudiante.Pension = est.Pension;

            _context.Estudiantes.Update(estudiante);
            await _context.SaveChangesAsync();

            return Ok(estudiante);
        }

        /* ??? Hacer métodos para activar y desactivar estudiante
            debe tomar en cuenta la tabla de pagos, especialmente que cuando se reinicie 
            cree un pago a la cuota actual
         */

        [HttpPatch("desactivar/{id}")]
		public async Task<IActionResult> desactivar(int id)
        {
            Estudiante est = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);
            if(est == null)
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

        /* bool paga hace referencia a si pagará la cuota actual o nó */
		[HttpPatch("activar/{id}")]
		public async Task<IActionResult> activar(int id, bool paga)
		{
			Estudiante est = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);
			if (est == null)
			{
				return BadRequest("No existe el estudiante");
			}

			if (est.Est_activo)
			{
				return BadRequest("El estudiante ya se encuentra habilitado");
			}

			est.Est_activo = true;
			_context.Estudiantes.Update(est);

			/* Lógica de reingreso, actualizar cuotas*/

			Pago utlimoPago = (await _context.Pagos.ToListAsync()).FindAll(x => x.Estudiante == id).OrderByDescending(x => x.Pag_cuota).First();


			if (paga)
            {

            } else
            {

            }


			await _context.SaveChangesAsync();

			return Ok(est);
		}


	}
}
