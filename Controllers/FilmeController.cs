using Fiap.Web.Aula03.DataBase;
using Fiap.Web.Aula03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Aula03.Controllers
{
    public class FilmeController : Controller
    {        
        private StreamingContext _context;

        //O contexto é injetado no construtor
        public FilmeController(StreamingContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Filmes.ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Filme filme)
        {
            _context.Filmes.Add(filme);
            _context.SaveChanges();
            TempData["mensagem"] = "Veículo cadastrado!";
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            _context.Filmes.Remove(_context.Filmes.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_context.Filmes.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Filme filme)
        {
            _context.Filmes.Update(filme);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
