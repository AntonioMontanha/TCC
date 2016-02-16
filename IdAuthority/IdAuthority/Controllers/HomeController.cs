using System.Threading.Tasks;
using System.Web.Mvc;
using Facebook;
using Microsoft.AspNet.Facebook;
using Microsoft.AspNet.Facebook.Client;
using IdAuthority.Models;

namespace IdAuthority.Controllers
{
    public class HomeController : Controller
    {
        private const string appID = "706984349411685";

        [FacebookAuthorize("email", "user_photos")]
        public async Task<ActionResult> Index(FacebookContext context)
        {
            if (ModelState.IsValid)
            {
                var user = await context.Client.GetCurrentUserAsync<MyAppUser>();


                var client = new FacebookClient();
                dynamic result = client.Get("oauth/access_token", new
                {
                    client_id = appID,
                    redirect_uri = @"https://localhost:44300/",
                    client_secret = "7a0dad24c1dae8c8eaec7fdf2bbec5f0",
                    grant_type = "client_credentials"
                    //user_token = "CAAKCZC58CKWUBAKhX7OXkvXYn1X2tZC6UQK4oeZAOAYkEkWZAT7eZAVM1DrzN62heqZBDm4yBMLJe5AywBlGHCFm8gMJGhptEXMMgxZA8cv3PPk99jU9McnMbZBFv0z8IAwskuk6YfOiHTph3tTfvkJa368TZBWQefVfBdgwwdPlDjs7cmqeJXNRyWXJFsBdqWRqDymZABOnZAVewZDZD"
                });

                client.AccessToken = ((Facebook.JsonObject)(result))["access_token"].ToString(); // Obtendo o token de acesso

                dynamic testUsers = client.Get(appID + "/accounts/test-users"); // Busca os amigos
                string id = ((JsonObject) ((JsonArray) ((JsonObject) testUsers)["data"])[0])["id"].ToString();
                dynamic teste = client.Get(id + "/feed"); // Busca os posts
                
                return View("Index");

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
        public JsonResult Search(string PalavraChave)
        {
            var client = new FacebookClient();
            dynamic result = client.Get("oauth/access_token", new
            {
                client_id = appID,
                redirect_uri = @"https://localhost:44300/",
                client_secret = "7a0dad24c1dae8c8eaec7fdf2bbec5f0",
                grant_type = "client_credentials"
                //user_token = "CAAKCZC58CKWUBAKhX7OXkvXYn1X2tZC6UQK4oeZAOAYkEkWZAT7eZAVM1DrzN62heqZBDm4yBMLJe5AywBlGHCFm8gMJGhptEXMMgxZA8cv3PPk99jU9McnMbZBFv0z8IAwskuk6YfOiHTph3tTfvkJa368TZBWQefVfBdgwwdPlDjs7cmqeJXNRyWXJFsBdqWRqDymZABOnZAVewZDZD"
            });

            client.AccessToken = ((Facebook.JsonObject)(result))["access_token"].ToString(); // Obtendo o token de acesso

            dynamic testUsers = client.Get(appID + "/accounts/test-users"); // Busca os amigos
            dynamic teste = client.Get("140855076293667/feed"); // Busca os posts



            return Json(teste);
        }
        
        [HttpPost]
        public ActionResult CadastrarExpertise(MyAppUser model)
        {
            return View("Index");
        }

        public ActionResult BuscarAutoridadeCognitiva()
        {
            return View("BuscarAutoridadeCognitiva");
        }

        public ActionResult SalvarExpertise()
        {
            return View("Index");
        }

    }
}
