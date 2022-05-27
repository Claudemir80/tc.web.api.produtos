using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TC.WEB.API.PRODUTO.Models;
using TC.WEB.API.PRODUTO.Repositories;

namespace TC.WEB.API.PRODUTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(ICategoriaRepository icategoriaRepository)
        {
            _categoriaRepository = icategoriaRepository;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _categoriaRepository.Get();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await _categoriaRepository.Get(id);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult<Categoria>> Create(Categoria categoria)
        {
            var novacategoria = await _categoriaRepository.Create(categoria);
            return categoria;
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }
            else
            {
                await _categoriaRepository.Update(categoria);

                return NoContent();
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var itemcategoria = await _categoriaRepository.Get(id);

            if (itemcategoria == null)
            {
                return NotFound();
            }
            else
            {
                await _categoriaRepository.Delete(itemcategoria.Id);
                return NoContent();
            }
        }
    }
}
