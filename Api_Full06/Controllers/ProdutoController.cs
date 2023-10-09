using Api_Full06.Data;
using Api_Full06.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Full06.Controllers
{
    [Route("[controller]")]
    public class ProdutoController : Controller
    {
        private Data.AppContext _context;

        public ProdutoController(Data.AppContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("RetornaProdutos")]
        public IActionResult RetornaProdutos()
        {
            return Ok(_context.Produtos.Include("Componente"));
        }

        [HttpGet]
        [Route("RetornaProdutoPorCodigo")]
        public IActionResult RetornaProduto(string codigo)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Codigo == codigo);    

            if(produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost]
        [Route("InsereProduto")]
        public IActionResult InsereProduto([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaProduto), new {id = produto.Id}, produto);
        }

    }
}
