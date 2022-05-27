using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TC.WEB.API.PRODUTO.Data;
using TC.WEB.API.PRODUTO.Models;

namespace TC.WEB.API.PRODUTO.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task Delete(int id)
        {
            var categoiadelete = await _context.Categorias.FindAsync(id);
            _context.Remove(categoiadelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
