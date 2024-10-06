using Microsoft.AspNetCore.Mvc;
using CadastroEscola.Models;
using System.Linq;
using CadastroEscola.Data; 

namespace CadastroEscola.Controllers
{
    public class TurmasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TurmasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Turmas
        public IActionResult Index()
        {
            var turmas = _context.Turmas.ToList();
            return View(turmas); // Retorna a lista de turmas
        }

        // GET: Turmas/CreateOrEdit/{id}
        public IActionResult CreateOrEdit(int? id)
        {
            if (id == null) // Novo cadastro
            {
                return View(new Turma());
            }
            else // Editar turma existente
            {
                var turma = _context.Turmas.Find(id);
                if (turma == null)
                {
                    return NotFound();
                }
                return View(turma);
            }
        }

        // POST: Turmas/CreateOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrEdit(Turma turma)
        {
            if (ModelState.IsValid)
            {
                if (turma.ID == 0) // Criar nova turma
                {
                    _context.Turmas.Add(turma);
                }
                else // Editar turma existente
                {
                    _context.Turmas.Update(turma);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(turma); // Em caso de erro, retorna a mesma view
        }

        // GET: Turmas/Delete/{id}
        public IActionResult DeleteConfirmed(int id)
        {
            var turma = _context.Turmas.Find(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.Turmas.Remove(turma);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index)); // Retorna para a lista de turmas
        }
    }
}
