using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Facebook;
using Microsoft.AspNet.Facebook.Client;
using IdAuthority.Models;
//using System.Data.SQLite;

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

        #region Banco De Dados - Jogar pra outra Classe se der tempo.
        //private string _ConnectionString = @"Data Source=..\App_Data\BancoDeDados.db;" +
        //                                     "Version=3;";

        //private SQLiteConnection Conexao;

        //public SQLiteConnection AbreConexão()
        //{
        //    if (Conexao == null)
        //    {
        //        Conexao = new SQLiteConnection(_ConnectionString);
        //    }
        //    Conexao.Open();
        //    return Conexao;
        //}

        //public void FechaConexão()
        //{
        //    Conexao.Close();
        //}


        //public void Salva()
        //{
        //    string sqlSalva = @"INSERT INTO User_Expertise (Nome,Endereco,Telefone) VALUES (@nome,@end,@tel)";

        //    SQLiteCommand command = new SQLiteCommand(sqlSalva, AbreConexão());
        //    command.CommandText = sqlSalva;
        //    //command.Parameters.AddWithValue("@nome", NomeMissionaria);
        //    //command.Parameters.AddWithValue("@end", EnderecoMissionaria);
        //    //command.Parameters.AddWithValue("@tel", TelefoneMissionaria);
        //    command.ExecuteNonQuery();
        //    FechaConexão();
        //}



        #endregion

    }
}
