using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebColegioPagos.Controllers
{
    public class GlobalController : Controller
    {
        // GET: GlobalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GlobalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GlobalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: GlobalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }


        // GET: GlobalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

    }
}
