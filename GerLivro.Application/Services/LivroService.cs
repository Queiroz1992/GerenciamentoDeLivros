using GerLivro.Application.DTOs;
using GerLivro.Domain.Interfaces;
using GerLivro.Domain.Intities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerLivro.Application.Services
{
    public class LivroService
    {
        private readonly ILivroRepository _livroRepository = null!;

        public LivroService(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public async Task<IEnumerable<LivroDTO>> GetAllAsync()
        {
            var livros = await _livroRepository.GetAllAsync();
            return livros.Select(x => new LivroDTO
            {
                Id = x.Id,
                Titulo = x.Titulo,
                Autor = x.Autor,
                Genero = x.Genero,
                AnoPublicacao = x.AnoPublicacao
            });
        }

        public async Task<LivroDTO> GetByIdAsync(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);

            if (livro == null) return null!;

            return new LivroDTO
            {
                Id = livro.Id,
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                Genero = livro.Genero,
                AnoPublicacao = livro.AnoPublicacao
            };
        }

        public async Task<int> AddAsync(CreateLivroDTO createLivroDTO)
        {
            var livro = new Livro
            {
                Titulo = createLivroDTO.Titulo,
                Autor = createLivroDTO.Autor,
                Genero = createLivroDTO.Genero,
                AnoPublicacao = createLivroDTO.AnoPublicacao
            };

            await _livroRepository.AddAsync(livro);
            return livro.Id;
        }

        public async Task UpdateAsync(LivroDTO livroDTO)
        {
            var livro = new Livro
            {
                Id = livroDTO.Id,
                Titulo = livroDTO.Titulo,
                Autor = livroDTO.Autor,
                Genero = livroDTO.Genero,
                AnoPublicacao = livroDTO.AnoPublicacao
            };

            await _livroRepository.UpdateAsync(livro);
        }

        public async Task DeleteAsync(int id)
        {
            await _livroRepository.DeleteAsync(id);
        }
    }
}
