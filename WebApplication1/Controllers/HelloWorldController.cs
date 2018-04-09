using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    public class HelloWorldController : Controller
    {

        // GET: /HelloWorld/ 
        public ActionResult Index()
        {
            return View();
        }

        // 
        // GET: /HelloWorld/BemVindo/ 
        public string BemVindo()
        {
            return "Bem vindo ao seu controller!";
        }

        // GET: /HelloWorld/Cumprimentar?nome=[NOME]&repetir=[NUM]
        public ActionResult Cumprimentar(string nome, int repetir = 1)
        {
            ViewData["Mensagem"] = "Olá " + nome + "!";
            ViewData["Repetir"] = repetir;

            return View();
        }

        // GET: /HelloWorld/CumprimentarUsuario/[ID]?cumprimento=[Cumprimento]
        public string CumprimentarUsuario(int ID, string cumprimento)
        {
            string[] nomes = { "Foad", "José", "Maria", "Pedro" };
      
            return $"{cumprimento} {nomes[ID]}!";
        }
    }
}
