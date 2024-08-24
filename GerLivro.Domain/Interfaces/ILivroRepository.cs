using GerLivro.Domain.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerLivro.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> GetAllAsync();
        Task<Livro> GetByIdAsync(int id);
        Task<Livro> AddAsync(Livro livro);
        Task<Livro> UpdateAsync(Livro livro);
        Task<Livro> DeleteAsync(int id);
    }
}
