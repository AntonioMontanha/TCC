using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Facebook;
using Microsoft.AspNet.Facebook.Client;
using IdAuthority.Models;

namespace IdAuthority.Controllers
{
    public class HomeController : Controller
    {
        [FacebookAuthorize("email", "user_photos")]
        public async Task<ActionResult> Index(FacebookContext context)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Client.
                    GetCurrentUserAsync<MyAppUser>();

                return View(user);
            }

            return View("Error");
        }

        public ActionResult Permissions(FacebookRedirectContext context)
        {
            if (ModelState.IsValid)
            {
                return View(context);
            }

            return View("Error");
        }
        public ActionResult CannotCreateCookie()
        {
            return View("Error");
        }


        [HttpGet]
        public ActionResult Search(string PalavraChave)
        {
            // Aqui implementar a lógica de busca dos posts

            return View("Error");
        }

        
        [HttpPost]
        public ActionResult ConfirmarExpertise(MyAppUser model)
        {
            return View("Permissions");
        }

        public ActionResult OutraPagina()
        {
            return View("Permissions");
        }
    }
}
