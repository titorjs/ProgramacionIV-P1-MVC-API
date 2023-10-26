using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebColegioPagos.Controllers
{
    public class PensionController : Controller
    {
        // GET: PensionController
        public IActionResult Index()
        {
            return View();
        }

        // GET: PensionController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PensionController/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: PensionController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // GET: PensionController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

    }
}
