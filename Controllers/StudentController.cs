using GestionEtudiants.Application;
using GestionEtudiants.Interfaces;
using GestionEtudiants.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{
    [Route("students/")]
    public class StudentController : Controller
    {
        private IStudentRepository _studentRepository { get; set; }
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //[HttpPost]
        //public IActionResult Edit(Student student)
        //{
        //    var name = student.StudentId;
        //    return RedirectToAction("Index");

        //}

        public IActionResult Index()
        {
            ViewData["Nom"] = "Koffi SANI";
            return View();
        }

        //public IHttpActionResult Delete(int id)
        //{
        //    if (id <= 0)
        //        return BadRequest("Not a valid student id");

        //    using (var ctx = new SchoolDBEntities())
        //    {
        //        var student = ctx.Students
        //            .Where(s => s.StudentID == id)
        //            .FirstOrDefault();

        //        ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
        //        ctx.SaveChanges();
        //    }

        //    return Ok();
        //}



        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit")]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            if (id == null)
            {
                return Json("Erreur, merci de fournir la valeur de l'Id");
            }
            else
            {
                var student = _studentRepository.GetStudentById(id);

                return Json(student);
            }
        }

        [Route("get-by-id/{id?}")]
        public JsonResult GetStudentById(int? id)
        {
            if (id == null)
            {
                return Json("Erreur, merci de fournir la valeur de l'Id");
            }
            else
            {
                var student = _studentRepository.GetStudentById(id.Value);

                return Json(student);
            }
        }

        [Route("all"),ActionName("GetAll")]
        public IActionResult GetAll([FromServices] IStudentRepository studentRepository)
        {
            var students = studentRepository.GetAll();
            //ViewData["students"] = students;

            return View(students);
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            //ViewData["students"] = students;

            return View();
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Create(Student student)
        {
            _studentRepository.Add(student);
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var ids = _studentRepository.GetStudentById(id);
            if(ids== null)
            {
                return NotFound();
            }
            _studentRepository.Delete(id);

            return RedirectToAction("GetAll");
        }
        // POST: FiliereController/Edit/5
        

        //[HttpPost]
        //[Route("edit")]
        //public IActionResult Edit()
        //{
        //    //ViewData["students"] = students;

        //    return View();
        //}
    }
}
