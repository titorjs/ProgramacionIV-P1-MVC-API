using ApiColegioPagos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebColegioPagos.Services;

namespace WebColegioPagos.Controllers
{
    public class EstudianteController : Controller
    {
        private readonly IApiService _apiService;

        public EstudianteController(IApiService apiService)
        {
            _apiService = apiService;
        }
        // GET: EstudianteController
        public async Task<IActionResult> Index()
        {
            List<Estudiante> estudiantes = await _apiService.GetEstudiantes();  
            return View(estudiantes);
        }
       
        public async Task<IActionResult> IndexCedula(string cedula)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            estudiantes.Add(await _apiService.GetEstudiante(cedula));
            return View(estudiantes);
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
        // POST: EstudianteController/Edit/5


        // GET: EstudianteController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

      
    }
}
