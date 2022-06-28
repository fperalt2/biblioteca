using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using pt1_mvc.Models;

namespace pt1_mvc.Controllers
{
    public class LlibreController : Controller
    {
        private readonly bibliotecaContext dataContext;

        public LlibreController(bibliotecaContext context)
        {
            dataContext = context;
        }
        
        // GET: Llibre
        public IActionResult Index()
        {
            var llibres = dataContext.Llibres.Include(llibre => llibre.Autor);
            return View(llibres.ToList());
        }

        // GET: Llibre/Create
        public IActionResult Create()
        {
            PopulateAutorsDropDownList();
            return View();
        }

        // POST: Llibre/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Titol,AutorId")] Llibre llibre)
        {
            dataContext.Add(llibre);
            dataContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Llibre/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibre = dataContext.Llibres
                .FirstOrDefault(l => l.Id == id);
            if (llibre == null)
            {
                return NotFound();
            }

            PopulateAutorsDropDownList(llibre.AutorId);
            return View(llibre);
        }

        // POST: Llibre/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Titol,AutorId")] Llibre llibre)
        {

            //cerquem el llibre a partir de la id que ens arriba del formulari, llibre.Id
            var llibre0 = dataContext.Llibres
                .FirstOrDefault(l => l.Id == llibre.Id);
            if (llibre0 == null)
            {
                return NotFound();
            }

            try
            {
                // actualitzem les dades del llibre i persistim en la BDD
                llibre0.Titol = llibre.Titol;
                llibre0.AutorId = llibre.AutorId;
                dataContext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            PopulateAutorsDropDownList(llibre0.AutorId);
            return View(llibre0);

        }

        private void PopulateAutorsDropDownList(object selectedAutor = null)
        {
            var autorsQuery = from a in dataContext.Autors
                                   orderby a.Id
                                   select a;
            ViewBag.AutorId = new SelectList(autorsQuery.AsNoTracking(), "Id", "FullName", selectedAutor);
        }

        // GET: Llibre/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var llibre = dataContext.Llibres.Include(llibre => llibre.Autor)
                .FirstOrDefault(l => l.Id == id);
            if (llibre == null)
            {
                return NotFound();
            }

            return View(llibre);
        }

        // POST: Llibre/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var llibre = dataContext.Llibres.Find(id);
            dataContext.Llibres.Remove(llibre);
            dataContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }        
    } 
}
