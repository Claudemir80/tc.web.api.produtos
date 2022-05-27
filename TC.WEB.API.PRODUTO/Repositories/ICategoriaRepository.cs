using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TC.WEB.API.PRODUTO.Models;

namespace TC.WEB.API.PRODUTO.Repositories
{
   public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> Get();

        Task<Categoria> Get(int id);

        Task<Categoria> Create(Categoria categoria);

        Task Update(Categoria categoria);

        Task Delete(int id);
    }
}
