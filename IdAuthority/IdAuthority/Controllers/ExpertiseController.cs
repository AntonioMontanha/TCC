using System.Web.Mvc;
using IdAuthority.Models.Expertise;

namespace IdAuthority.Controllers
{
    public class ExpertiseController : Controller
    {
        // GET: Expertise
        public ActionResult Index()
        {
            return View("Expertise");
        }

        public ActionResult SalvarExpertise(ExpertiseDto expertise)
        {
            //Código para Salvar a Expertise no banco de dados.
            return View("Expertise");
        }
    }
}