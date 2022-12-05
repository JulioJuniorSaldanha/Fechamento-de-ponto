using Fechamento_de_ponto.Models;
using Fechamento_de_ponto.Models.Interfaces;
using System.Text.Json;

namespace Fechamento_de_ponto.Properties.Services
{
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IFuncionariosService _funcionarioService;

        public DepartamentoService(IFuncionariosService funcionariosService)
        {
            _funcionarioService = funcionariosService;

        }


        const string documentPath = @"C:\Arquivo a Importar";
        int codigo = 1;

        public List<DepartamentoModel> getDepartamento()
        {
            List<DepartamentoModel> departamentoModels = new List<DepartamentoModel>();
            var files = Directory.GetFiles(documentPath);
            foreach (string file in files)
            {
                if ( file.Contains(".csv"))
                {
                    char delimiter = '-';
                    string[] substrings = file.Split(delimiter);            
                    string[] anoVigencia = substrings[2].Split('.');
                    List<FuncionarioModel> funcionarios= new List<FuncionarioModel>();
                    funcionarios = _funcionarioService.BuscaEspecifico(substrings[1], int.Parse(anoVigencia[0]));

                    DepartamentoModel departamento = new DepartamentoModel(codigo,substrings[0].Remove(0,22), substrings[1], int.Parse(anoVigencia[0]),calculaTotalpagar(substrings[1], int.Parse(anoVigencia[0])),funcionarios);
                    codigo++;

                   departamentoModels.Add(departamento);                  

                }
            }

            string jsonString = JsonSerializer.Serialize(departamentoModels);
            File.WriteAllText("Fechamento de ponto.json", jsonString);
            Console.WriteLine(File.ReadAllText("Fechamento de ponto.json"));

            return departamentoModels;
        }

        public double calculaTotalpagar(string mes,int ano)
        {
            double totalpagar = 0;
            List<FuncionarioModel> funcionarios= new List<FuncionarioModel>();
            funcionarios = _funcionarioService.BuscaEspecifico(mes,ano);
            foreach(var funcionario in funcionarios)
            {
                var horasTrabalhadas = funcionario.horaTrabalhada.ToString();
               string[] x = horasTrabalhadas.Split(":");
                var calculhora = int.Parse(x[0])*funcionario.valorHora;


                totalpagar = totalpagar + calculhora;
            } 
            return totalpagar;
        }
       
    }
}
