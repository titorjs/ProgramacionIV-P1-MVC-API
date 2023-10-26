using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebColegioPagos.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: EstudianteController
        public IActionResult Index()
        {
            return View();
        }

        // GET: EstudianteController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EstudianteController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstudianteController/Create
        

        // GET: EstudianteController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }
        //Metodo edicion pago
        public IActionResult EditPago (int id)
        {
            return View();
        }
        //Metodo edicion pension
        public IActionResult EditPension(int id)
        {
            return View();
        }
        // POST: EstudianteController/Edit/5


        // GET: EstudianteController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

      
    }
}
