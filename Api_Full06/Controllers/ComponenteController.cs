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
    }
}
