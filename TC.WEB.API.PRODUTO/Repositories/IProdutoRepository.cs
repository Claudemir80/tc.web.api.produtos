using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TC.WEB.API.PRODUTO.Models;

namespace TC.WEB.API.PRODUTO.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> Get();

        Task<Produto> Get(int id);

        Task<Produto> Create(Produto produto);

        Task Update(Produto produto);

        Task Delete(int id);
    }
}
