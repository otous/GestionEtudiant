using Microsoft.AspNetCore.Mvc;

namespace GestionEtudiants.Controllers
{
    [Route("/")]
    public class HelloController : Controller
    {
        public string Index() {
            return "Hello World !!!";
        }

        [Route("bonjour")]
        public string Bonjour()
        {
            return "Bonjour le monde";
        }
    }
}
