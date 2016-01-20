using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Facebook;
using Microsoft.AspNet.Facebook;
using Microsoft.AspNet.Facebook.Client;
using IdAuthority.Models;
using IdAuthority.Models.Authority;
using Newtonsoft.Json.Linq;

namespace IdAuthority.Controllers
{
    public class HomeController : Controller
    {
        [FacebookAuthorize("email", "user_photos")]
        public async Task<ActionResult> Index(FacebookContext context)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Client.GetCurrentUserAsync<MyAppUser>();

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
            var accessToken = "CAAKCZC58CKWUBAIoSTN5BEFvDv02jHkonpg47hV8pMwyJ2TZAZABFx5qZCvJc6HMUfCmtCUqKk2hrjZCZCOkS4QM1ARsIfVdZCmxClhBfWdlpryaux9x4iXfgw5jqVzyK5nHGJwJdsekp041h0I99KZCI6qYmdQNiRDjENYtIfDoZC4gsLdKjmZBfJ6gjoqnZBK5upXynUXZAQuTGBrOwoT0zfma";
            var client = new FacebookClient(accessToken);
            dynamic me = client.Get("me");

            




            return View("Permissions");
        }

        public ActionResult OutraPagina()
        {
            return View("Permissions");
        }
    }
}
