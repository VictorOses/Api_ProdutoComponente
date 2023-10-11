using Api_Full06.Data;
using Api_Full06.DTO;
using Api_Full06.Model;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProdutoController(Data.AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("RetornaProdutos")]
        public IActionResult RetornaProdutos()
        {
            return Ok(_context.Produtos.Include(a => a.Componente));
        }

        [HttpGet]
        [Route("RetornaProdutoPorCodigo")]
        public IActionResult RetornaProduto(int codigo)
        {
            var produto = _context.Produtos.Where(p => p.Codigo == codigo ).Include(a => a.Componente).FirstOrDefault();

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }

            return Ok(produto);
        }

        [HttpPost]
        [Route("InsereProduto")]
        public IActionResult InsereProduto([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaProduto), new { codigo = produto.Codigo }, produto);
        }

    }
}
