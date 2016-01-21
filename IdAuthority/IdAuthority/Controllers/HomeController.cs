using System.CodeDom;
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

                client.AccessToken = ((Facebook.JsonObject) (result))["access_token"].ToString();
                

                dynamic testUsers = client.Get(appID + "/accounts/test-users");
                dynamic teste = client.Get("140855076293667/feed");
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
        public ActionResult Search(string PalavraChave)
        {
            // Aqui implementar a lógica de busca dos posts

            return View("Error");
        }
        
        [HttpPost]
        public ActionResult CadastrarExpertise(MyAppUser model)
        {
            var accessToken = "CAAKCZC58CKWUBAIoSTN5BEFvDv02jHkonpg47hV8pMwyJ2TZAZABFx5qZCvJc6HMUfCmtCUqKk2hrjZCZCOkS4QM1ARsIfVdZCmxClhBfWdlpryaux9x4iXfgw5jqVzyK5nHGJwJdsekp041h0I99KZCI6qYmdQNiRDjENYtIfDoZC4gsLdKjmZBfJ6gjoqnZBK5upXynUXZAQuTGBrOwoT0zfma";
            var client = new FacebookClient(accessToken);
            dynamic me = client.Get("me");
            return View("Index");
        }

        public ActionResult BuscarAutoridadeCognitiva()
        {
            return View("BuscarAutoridadeCognitiva");
        }
    }
}
