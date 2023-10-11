using Api_Full06.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Full06.Controllers
{
    public class ComponenteController : Controller
    {
        private Data.AppContext _context;

        public ComponenteController(Data.AppContext context)
        {
            _context = context;
        }

        //POST - /api/v1/produto/{codigo}/componente
        [HttpPost]
        [Route("InsereComponente")]
        public IActionResult InsereProduto([FromBody] Componente componente)
        {
            _context.Componentes.Add(componente);
            _context.SaveChanges();
            return Ok();
        }

        //GET - /api/v1/produto/{codigo/componente/{indice}
        [HttpGet]
        [Route("RetornaComponentePorDescricao")]
        public IActionResult RetornaProdutoComponente(string descricao)
        {
            var componente = _context.Componentes.FirstOrDefault(c => c.Descricao.Contains(descricao));

            if (componente == null)
            {
                return NotFound("Componente não encontrado!");
            }
            return Ok(componente);
        }

        //GET - /api/v1/produto/{codigo}/componente/
        [HttpGet]
        [Route("RetornaComponentePorProduto")]
        public IActionResult RetornaComponentePorProduto(int codigoProduto)
        {
            var componente = _context.Componentes.FirstOrDefault(c => c.Descricao.Contains(descricao));

            if (componente == null)
            {
                return NotFound("Componente não encontrado!");
            }
            return Ok(componente);
        }

        //GET - /api/v1/produto/componente?descricao={descricao}
        [HttpGet]
        [Route("RetornaComponentePorDescricao")]
        public IActionResult RetornaProdutoComponente(string descricao)
        {
            var componente = _context.Componentes.FirstOrDefault(c => c.Descricao.Contains(descricao));

            if (componente == null)
            {
                return NotFound("Componente não encontrado!");
            }
            return Ok(componente);
        }

    }
}
