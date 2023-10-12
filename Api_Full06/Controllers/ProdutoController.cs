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
    [Route("/api/v1/produto")]
    public class ProdutoController : Controller
    {
        #region :: CONSTRUTOR
        public ProdutoController(Data.AppContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region :: PRODUTO
        // POST /api/v1/produto
        [HttpPost]
        public IActionResult InsereProduto([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = _mapper.Map<Produto>(produtoDTO);
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RetornaProduto), new { codigo = produto.Codigo }, produto);
        }

        // GET /api/v1/produto/{codigo}
        [HttpGet]
        [Route("{codigo}")]
        public IActionResult RetornaProduto(string codigo)
        {
            var produto = _context.Produtos.Where(p => p.Codigo == codigo).Include(a => a.Componente).FirstOrDefault();

            if (produto == null)
            {
                return NotFound("Produto não encontrado!");
            }

            return Ok(produto);
        }

        // GET /api/v1/produto/
        [HttpGet]
        public IActionResult RetornaProdutos()
        {
            return Ok(_context.Produtos.Include(a => a.Componente));
        }

        #endregion

        #region :: VARIÁVEIS GLOBAIS PRIVADAS
        private Data.AppContext _context;
        private readonly IMapper _mapper;
        #endregion

        #region COMPONENTE
        // POST /api/v1/produto/{codigo}/componente
        [HttpPost]
        [Route("{codigo}/componente")]
        public IActionResult InsereComponente(string codigo, [FromBody] ComponenteDTO componente)
        {
            int qtdRetorno = _context.Produtos.Where(p => p.Codigo == codigo).Count();

            if (String.IsNullOrEmpty(codigo))
                return BadRequest("É obrigatório informar o código do Produto para prosseguir com a inclusão do Componente!");

            if (qtdRetorno == 0 )
                return BadRequest("Não possuí um Produto com o código informado! Favor tente novamente ou insira o produto em nosso banco de dados!");

            var componenteNovo = _mapper.Map<Componente>(componente);
            componenteNovo.ProdutoCodigo = codigo;

            _context.Componentes.Add(componenteNovo);
            _context.SaveChanges();
            return Ok();
        }

        // GET /api/v1/produto/{codigo}/componente/{indice}
        [HttpGet]
        [Route("{codigo}/componente/{indice}")]
        public IActionResult RetornaProdutoComponente(string codigo, int indice)
        {
            var componente = _context.Componentes.Where(c => c.ProdutoCodigo == codigo && c.Indice == indice);

            if (componente == null)
            {
                return NotFound("Informação não localizada. Favor revizar o valor dos parâmetros ou incluir a informação na base de dados!");
            }

            return Ok(componente);
        }

        // GET /api/v1/produto/{codigo}/componente/
        [HttpGet]
        [Route("{codigo}/componente")]
        public IActionResult RetornaComponentesPorCodigoProduto(string codigo)
        {
            var componente = _context.Componentes.Where(c => c.ProdutoCodigo == codigo);

            if (componente == null)
            {
                return NotFound("Componente(s) não encontrado(s)!");
            }
            return Ok(componente);
        }

        // GET /api/v1/produto/componente?descricao={descricao}
        [HttpGet]
        [Route("componente")]
        public IActionResult RetornaComponentePorDescricao(string descricao)
        {
            var componente = _context.Componentes.FirstOrDefault(c => c.Descricao.Contains(descricao));

            if (componente == null)
            {
                return NotFound("Componente não encontrado!");
            }
            return Ok(componente);
        }
        #endregion
    }
}
