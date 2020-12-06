using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projetão.DAL;
using Projetão.Models;

namespace Projetão.Controllers
{
    public class LivroController : Controller
    {
        private readonly LivroDAO _livroDAO;

        public LivroController(LivroDAO livroDAO) => _livroDAO = livroDAO;

        public IActionResult Index() 
        {
            List<Livro> livros = _livroDAO.Listar ();
            ViewBag.Livros = livros;
            ViewBag.Quantidade = livros.Count;
            ViewBag.Data = DateTime.Now;
            return View();
        }


        public IActionResult Cadastrar() => View();


        [HttpPost]
        public IActionResult Cadastrar(string nome, string data, string resumo, string valor,string quant) 
        {

            Livro livro = new Livro
            {
                Nome = nome,
                Lançamento = data,
                Resumo = resumo,
                Valor = valor,
                Quantidade = quant
            };
            {
                livro.Nome = nome;
                livro.Lançamento = data;
                livro.Resumo = resumo;
                livro.Valor = valor;
                livro.Quantidade = quant;

            }
            if (_livroDAO.Cadastrar(livro)) 
            {
                return RedirectToAction("Index", "Livro");
            }
            ModelState.AddModelError("", "Livro já Cadastrado!!");
            return View();

            
        }

        [HttpPost]
        public IActionResult Alterar( int Id,string nome, string data, string resumo, string valor, string quant)
        {

            Livro livro = _livroDAO.BuscarID(Id);

                livro.Nome = nome;
                livro.Lançamento = data;
                livro.Resumo = resumo;
                livro.Valor = valor;
                livro.Quantidade = quant;
            _livroDAO.Alterar(livro);
            
            

            return RedirectToAction("Index", "Livro");
        }
        public IActionResult Remover(int id)
        {
            _livroDAO.Remover(id);
            return RedirectToAction("Index", "Livro");
        }

        public IActionResult Alterar(int Id) 
        {
            ViewBag.Livro = _livroDAO.BuscarID(Id);
            return View();
        }



    }
}
