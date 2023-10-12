using Api_Full06.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Full06.Controllers
{
    [Route("api/v1/produto/[controller]")]
    public class ComponenteController : Controller
    {
        private Data.AppContext _context;

        public ComponenteController(Data.AppContext context)
        {
            _context = context;
        }

    }
}
