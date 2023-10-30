using WebColegioPagos.Models;
using Microsoft.AspNetCore.Mvc;
using WebColegioPagos.Services;
using WebColegioPagos.Models.Data;

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

        public async Task<IActionResult> BusquedaCedula(string cedula)
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            Estudiante est = _apiService.GetEstudiante(cedula).Result;
            if(est != null) estudiantes.Add(est);
            return View("Index", estudiantes);
        }

        // GET: EstudianteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Estudiante estudiante = await _apiService.GetEstudiante(id);
            if (estudiante != null)
            {
                return View(estudiante);
            }
            return RedirectToAction("Index");
        }

        // GET: EstudianteController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegistroEstudiante estudiante)
        {
            Estudiante est = _apiService.AddEstudiante(estudiante).Result;
            if (est != null)
            {
                RedirectToAction("Details", est.Est_id);
            }
            return RedirectToAction("Index");
        }

        // GET: EstudianteController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            Estudiante estudiante = await _apiService.GetEstudiante(id);
            if (estudiante != null)
            {
                return View(estudiante);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Estudiante estudiante)
        {
            string cedula = estudiante.Est_cedula;
            ActualizacionEstudiante datos = new ActualizacionEstudiante
            {
                Est_direccion = estudiante.Est_direccion,
                Est_nombre = estudiante.Est_nombre,
                Pension = estudiante.Pension
            };

            Estudiante est = _apiService.UpdateEstudiante(cedula, datos).Result;
            if (est != null)
            {
                RedirectToAction("Details", est.Est_id);
            }
            return RedirectToAction("Index");
        }

        //Metodo edicion pago
        public async Task<IActionResult> EditPago (int id)
        {
            Estudiante estudiante = await _apiService.GetEstudiante(id);
            if (estudiante != null)
            {
                return View(estudiante);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditPagoFuncion(string activo, int id)
        {
            Estudiante est;
            if(activo == "Activo")
            {
                est = _apiService.activarEstudiante(id, false).Result;
            } else
            {
                est = _apiService.desactivarEstudiante(id).Result;
            }

            if (est != null)
            {
                RedirectToAction("Details", est.Est_id);
            }
            return RedirectToAction("Index");
        }
    }
}
