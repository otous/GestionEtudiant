using GestionEtudiants.Interfaces;
using GestionEtudiants.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{
    [Route("filiere/")]
    public class FiliereController : Controller
    {
        private IFiliereRepository filiereRepository;

        public FiliereController(IFiliereRepository f)
        {
            filiereRepository = f;
        }

        // GET: FiliereController
        [HttpGet]
        public IActionResult Index()
        {
            var filieres = filiereRepository.GetAll();
            return View(filieres);
        }

        // GET: FiliereController/Details/5
        [HttpGet]
        [Route("/{id}")]
        public JsonResult Details(int id)
        {
            var filiere = filiereRepository.GetFiliereById(id);
            return Json(filiere);
        }

        // GET: FiliereController/Create
        [HttpPost]
        [Route("create")]
        public JsonResult Create(Filiere filiere)
        {
            var t = filiereRepository.Add(filiere);
            return Json(t);
        }

        // POST: FiliereController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: FiliereController/Edit/5
        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FiliereController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FiliereController/Delete/5
        [HttpGet]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FiliereController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
