using Projetão.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projetão.DAL
{
    public class LivroDAO
    {
        private readonly Context _context;

        public LivroDAO(Context context) => _context = context;

        public List<Livro> Listar() => _context.Livros.ToList();

        public Livro BuscarID(int id) => _context.Livros.Find(id);

        public bool Cadastrar(Livro livro) 
        {
            if (BuscarNome(livro.Nome) == null)
            {
                _context.Livros.Add(livro);
                _context.SaveChanges();
                return true;
            }
            return false;
            
        }
        public void Remover(int id)
        {
            _context.Livros.Remove(_context.Livros.Find(id));
            _context.SaveChanges();
        }

        public void Alterar(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges();
        }

        public Livro BuscarNome(string nome) => _context.Livros.FirstOrDefault(x => x.Nome == nome);
    }
}
