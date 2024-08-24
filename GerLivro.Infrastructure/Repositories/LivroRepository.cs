using GerLivro.Domain.Interfaces;
using GerLivro.Domain.Intities;
using GerLivro.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerLivro.Infrastructure.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly LivroContext _context;

        public LivroRepository(LivroContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Livro>> GetAllAsync()
        {
            return await _context.Livros.ToListAsync();
        }
        public async Task<Livro> GetByIdAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                throw new Exception($"Livro com id {id} não encontrado");
            }
            return livro;
        }
        public async Task<Livro> AddAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
        public async Task<Livro> UpdateAsync(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return livro;
        }
        public async Task<Livro> DeleteAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null)
            {
                throw new Exception($"Livro com id {id} não encontrado");
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return livro;
        }
    }
}
