using Fechamento_de_ponto.Models;
using Fechamento_de_ponto.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fechamento_de_ponto.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionariosService _funcionarioService;

        public FuncionarioController(IFuncionariosService funcionariosService)
        {
            _funcionarioService = funcionariosService;

        }


        public IActionResult Index()
        {
           List<FuncionarioModel> funcionarios = _funcionarioService.GetFuncionarios();
          return View(funcionarios);
        }
    }
}
