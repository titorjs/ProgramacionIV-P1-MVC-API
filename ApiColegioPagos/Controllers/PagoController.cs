using ApiColegioPagos.Data;
using ApiColegioPagos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ApiColegioPagos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : Controller
    {
        private readonly ApiColegioPagosDbContext _context;

        public PagoController(ApiColegioPagosDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            List<Pago> pagos = await _context.Pagos.ToListAsync();
            return Ok(pagos);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> getAllId(int id)
        {
            List<Pago> pagos = await _context.Pagos.ToListAsync();
            List<Pago> pagoEstudiante = pagos.FindAll(x => x.Estudiante == id);

            return Ok(pagoEstudiante);
        }

        [HttpPost("pagar")]
        public async Task<IActionResult> pagarId(int id)
        {
            Estudiante est = await _context.Estudiantes.FirstOrDefaultAsync(x => x.Est_id == id);

            if (est == null)
            {
                return BadRequest("El estudiante no existe");
            }

            List<Pago> pagos = await _context.Pagos.ToListAsync();
            List<Pago> pagoEstudiante = pagos.FindAll(x => x.Estudiante == id);

            if (pagoEstudiante.IsNullOrEmpty())
            {
                return BadRequest("No hay pagos registrados para el estudiante");
            }

            Pago ultimoPago = pagoEstudiante.OrderByDescending(x => x.Pag_cuota).First();

            Global global = await _context.Globals.FirstOrDefaultAsync(x => x.Glo_id == 1);
            int cuota = global.Glo_valor;

            if (cuota <= ultimoPago.Pag_cuota)
            {
                return BadRequest("El estudiante ya se encuentra al día");
            }

            Pago pago = new Pago
            {
                Estudiante = est.Est_id,
                Pag_cuota = ultimoPago.Pag_cuota + 1,
                Pension = est.Pension
            };

            await _context.Pagos.AddAsync(pago);
            await _context.SaveChangesAsync();

            return Ok(pago);
        }
    }
}
