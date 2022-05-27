using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TC.WEB.API.PRODUTO.Data;
using TC.WEB.API.PRODUTO.Models;

namespace TC.WEB.API.PRODUTO.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(int id)
        {
            var produtodelete = await _context.Produtos.FindAsync(id);
            _context.Remove(produtodelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<Produto> Get(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
