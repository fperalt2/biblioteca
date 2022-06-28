using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pt1_mvc.Models;

namespace pt1_mvc.Controllers
{
    public class AutorController : Controller
    {
        private readonly bibliotecaContext dataContext;

        public AutorController(bibliotecaContext context)
        {
            dataContext = context;
        }
        
        // GET: Autor
        public IActionResult Index()
        {
            var autors = dataContext.Autors;
            return View(autors.ToList());
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nom,Cognoms")] Autor autor)
        {
            dataContext.Add(autor);
            dataContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Autor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = dataContext.Autors
                .FirstOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Nom,Cognoms")] Autor autor)
        {

            //cerquem l'autor a partir de la id que ens arriba del formulari, autor.Id
            var autor0 = dataContext.Autors
                .FirstOrDefault(a => a.Id == autor.Id);
            if (autor0 == null)
            {
                return NotFound();
            }

            try
            {
                // actualitzem les dades de l'autor i persistim en la BDD
                autor0.Nom = autor.Nom;
                autor0.Cognoms = autor.Cognoms;
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

            return View(autor0);

        }

        // GET: Autor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = dataContext.Autors
                .FirstOrDefault(a => a.Id == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var autor = dataContext.Autors.Find(id);
            dataContext.Autors.Remove(autor);
            dataContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }        
    } 
}
