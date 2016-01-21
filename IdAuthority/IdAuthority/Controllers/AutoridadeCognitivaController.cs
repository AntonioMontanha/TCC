using System.Web.Mvc;
using IdAuthority.Models.AutoridadeCognitiva;

namespace IdAuthority.Controllers
{
    public class AutoridadeCognitivaController : Controller
    {
        // GET: AutoridadeCognitiva
        public ActionResult Index()
        {
            return View("AutoridadeCognitiva");
        }

        public ActionResult Search(AutoridadeCognitivaDto model)
        {
            return View("Resultado");
        }
    }
}