using Fechamento_de_ponto.Models;
using Fechamento_de_ponto.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fechamento_de_ponto.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionariosService _funcionarioService;
        private readonly IDepartamentoService _deparatmentoService;
  
        public FuncionarioController(IFuncionariosService funcionariosService, IDepartamentoService deparatmentoService)
        {
            _funcionarioService = funcionariosService;
            _deparatmentoService = deparatmentoService;
        }


        public IActionResult Index(int id)
        {
            List<DepartamentoModel> departamentoModels= _deparatmentoService.getDepartamento();
            List<FuncionarioModel> funcionarioModels;

             foreach(var model in departamentoModels)
            {
                if(model.codigo == id)
                {
                    funcionarioModels = _funcionarioService.BuscaEspecifico(model.mesVigencia, model.anoVigencia);
                    return View(funcionarioModels);
                }          
               
            }
            
             return null;
         
        }
    }
}
