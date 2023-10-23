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

		//Debe considerar que no se puede eliminar si hay usuarios con esa pensión
		//[HttpDelete]

	}
}
