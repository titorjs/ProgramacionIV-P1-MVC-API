using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebColegioPagos.Controllers
{
    public class PagoController : Controller
    {
        // GET: PagoController
        public IActionResult Index()
        {
            return View();
        }
        // GET: PagoController
        public IActionResult Inpago()
        {
            return View();
        }

        // GET: PagoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public IActionResult Create()
        {
            return View();
        }

       // GET: PagoController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // GET: PagoController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
