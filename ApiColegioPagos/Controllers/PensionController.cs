using ApiColegioPagos.Data;
using ApiColegioPagos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiColegioPagos.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PensionController : Controller
	{
		private readonly ApiColegioPagosDbContext _context;

		public PensionController(ApiColegioPagosDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> getAll()
		{
			List<Pension> pensiones = await _context.Pensiones.ToListAsync();
			return Ok(pensiones);
		}

		[HttpGet("id/{id}")]
		public async Task<IActionResult> getById(int id)
		{
			Pension pension = await _context.Pensiones.FirstOrDefaultAsync(x => x.Pen_id == id);
			return Ok(pension);
		}

		[HttpPost]
		public async Task<IActionResult> set([FromBody] Pension pension)
		{
			if(pension == null || pension.Pen_valor < 0 || pension.Pen_nombre == null)
			{
				return BadRequest("Los datos ingresados no son correctos");
			}

			await _context.Pensiones.AddAsync(pension);
			await _context.SaveChangesAsync();

			return Ok(pension);

		}

		[HttpPut("id/{id}")]
		public async Task<IActionResult> update(int id, [FromBody] Pension pension)
		{
			Pension pen = await _context.Pensiones.FirstOrDefaultAsync(x => x.Pen_id == id);
			if (pen == null)
			{
				return BadRequest("No se ha encontrado la pensión con id " + id);
			}

			if (pension == null || pension.Pen_valor == null || pension.Pen_nombre == null)
			{
				return BadRequest("Valores ingresados para la actualización inválidos");
			}

			pen.Pen_valor = pension.Pen_valor;
			pen.Pen_nombre = pension.Pen_nombre;

			_context.Update(pen);
			await _context.SaveChangesAsync();

			return Ok(pen);
		}

		//Debe considerar que no se puede eliminar si hay usuarios con esa pensión
		[HttpDelete]
		public async Task<IActionResult> deletePension(int id)
		{
			Pension pen = await _context.Pensiones.FirstOrDefaultAsync(x => x.Pen_id == id);

			if (pen == null)
			{
				return BadRequest("No se ha encontrado la pensión con id " + id);
			}

			Estudiante est = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Pension == id);
			Pago pago = await _context.Pagos.FirstOrDefaultAsync(x => x.Pension == id);

			if(est != null || pago != null)
			{
				return BadRequest("Existen registros con esta pensión, no se puede eliminar.");
			}

			_context.Pensiones.Remove(pen);
			await _context.SaveChangesAsync();

			return Ok(pen);
		}

	}
}
