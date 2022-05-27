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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository iprodutoRepository)
        {
            _produtoRepository = iprodutoRepository;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _produtoRepository.Get();
        }

        // GET api/<ProdutoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            return await _produtoRepository.Get(id);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult<Produto>> Create([FromBody] Produto produto)
        {
            var novoproduto = await _produtoRepository.Create(produto);
            return produto;
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }
            else
            {
                await _produtoRepository.Update(produto);

                return NoContent();
            }
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var itemproduto = await _produtoRepository.Get(id);

            if (itemproduto == null)
            {
                return NotFound();
            }
            else
            {
                await _produtoRepository.Delete(itemproduto.Id);
                return NoContent();
            }
        }
    }
}
