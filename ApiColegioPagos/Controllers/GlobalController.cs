﻿using ApiColegioPagos.Data;
using ApiColegioPagos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiColegioPagos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalController : Controller
    {
        private readonly ApiColegioPagosDbContext _context;

        public GlobalController(ApiColegioPagosDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}/{valor}")]
        public async Task<IActionResult> actualizarValor(int id, int valor)
        {
            Global g = await _context.Globals.FindAsync(id);

            //Verificar que existe el valor global
            if (g == null)
            {
                return BadRequest("No se encontró la variable global");
            }

            //Actualizar el valor
            g.Glo_valor = valor;
            _context.Globals.Update(g);
            await _context.SaveChangesAsync();

            return Ok(g);
        }

        [HttpPut("cuota/{valor}")]
        public async Task<IActionResult> actualizarValor(int valor)
        {
            Global g = await _context.Globals.FindAsync(1);

            //Verificar que existe el valor global
            if (g == null)
            {
                return BadRequest("No se encontró la variable global");
            }

            //Actualizar el valor
            g.Glo_valor = valor;
            _context.Globals.Update(g);
            await _context.SaveChangesAsync();

            return Ok(g);
        }
    }
}
