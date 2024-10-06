using Microsoft.AspNetCore.Mvc;
using CadastroEscola.Data; 
using CadastroEscola.Models; 
using System.Linq;

namespace CadastroEscola.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var alunos = _context.Alunos.ToList();
            return View(alunos);
        }

        // Executa a exclusão do aluno no banco de dados diretamente
        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            // Recuperar a lista de turmas
            var turmas = _context.Turmas.ToList();
            ViewBag.Turmas = turmas; // Passar a lista de turmas para a ViewBag

            if (id == null)
            {
                return View(new Aluno()); // Criar novo aluno
            }
            else
            {
                var aluno = _context.Alunos.Find(id);
                if (aluno == null)
                {
                    return NotFound();
                }
                return View(aluno); // Editar aluno existente
            }
        }

        // Executa a exclusão do aluno no banco de dados diretamente
        [HttpPost]
        public IActionResult CreateOrEdit(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                if (aluno.ID == 0)
                {
                    // Novo aluno
                    _context.Alunos.Add(aluno);
                }
                else
                {
                    // Editar aluno existente
                    _context.Alunos.Update(aluno);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Caso haja erro, recarregar a lista de turmas
            ViewBag.Turmas = _context.Turmas.ToList();
            return View(aluno);
        }   


        // Executa a exclusão do aluno no banco de dados diretamente
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var aluno = _context.Alunos.Find(id);

            if (aluno != null)
            {
                _context.Alunos.Remove(aluno); // Remove o aluno
                _context.SaveChanges(); // Salva as alterações no banco de dados
            }

            return RedirectToAction(nameof(Index)); // Redireciona para a lista de alunos
        }

    

    }
}
