using Fechamento_de_ponto.Models;
using Fechamento_de_ponto.Models.Interfaces;
using Fechamento_de_ponto.Properties.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fechamento_de_ponto.Controllers
{
    public class DepartamentoController : Controller
    {

        private readonly IDepartamentoService _deparatamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)           
        {
            _deparatamentoService = departamentoService;
        }
       

        public IActionResult Index()
        {
            List <DepartamentoModel>  departamentos= _deparatamentoService.getDepartamento();

            return View(departamentos);
        }
                       
    }
}
