using Fechamento_de_ponto.Models;
using Fechamento_de_ponto.Models.Interfaces;
using System.Globalization;

namespace Fechamento_de_ponto.Properties.Services
{
    public class FuncionarioService : IFuncionariosService
    {
        const string documentPath = @"C:\Arquivo a Importar";

        public List<FuncionarioModel> GetFuncionarios()
        {
            List<FuncionarioModel> funcionarioModels = new List<FuncionarioModel>();
            var files = Directory.GetFiles(documentPath);

            foreach (var file in files) {
                if (file.Contains(".csv"))
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            var pathline = sr.ReadLine();
                            string[] x = pathline.Split(';');
                            if (!x[1].Contains("Nome"))
                            {
                               double valorHora =Double.Parse(x[2].Remove(0, 3).Replace(", ", ","), new CultureInfo("pt"));
                                string[] horaAlmoco = x[6].Split(" - ");
                                FuncionarioModel funcionario = new FuncionarioModel(x[0], x[1], valorHora, DateTime.Parse(x[3]), TimeSpan.Parse(x[4]), TimeSpan.Parse(x[5]), TimeSpan.Parse(horaAlmoco[0]), TimeSpan.Parse(horaAlmoco[1]),horaTrabalhada(TimeSpan.Parse(x[4]), TimeSpan.Parse(x[5]), TimeSpan.Parse(horaAlmoco[0]), TimeSpan.Parse(horaAlmoco[1])));
                                funcionarioModels.Add(funcionario);
                            }
                        }
                    }
                }
            }

            return funcionarioModels;
        }

        public List<FuncionarioModel> BuscaEspecifico(String mes,int ano){

            List<FuncionarioModel> funcionarioModels = new List<FuncionarioModel>();
            List<FuncionarioModel> listaTudo= GetFuncionarios();
            int numMes=0;
            int maxdays = 0;

            if (mes.Contains("Janeiro")) 
            {
                numMes= 1;
                maxdays = 31;
            }
            else if (mes.Contains("Fevereiro")) 
            { 
                numMes= 2;
            maxdays = 29;
            }
            else if (mes.Contains("Março")) { 
                numMes = 3;
            maxdays = 31;}
            else if (mes.Contains("Abril")) { 
                numMes = 4;
            maxdays = 30;}
            else if (mes.Contains("Maio")) { 
                numMes = 5;
            maxdays = 31;}
            else if (mes.Contains("Junho")) { 
                numMes = 6;
            maxdays = 30;}
            else if (mes.Contains("Julho")) { 
                numMes = 7;
            maxdays = 31;}
            else if (mes.Contains("Agosto")) { 
                numMes = 8;
            maxdays = 31;}
            else if (mes.Contains("Setembro")) { 
                numMes = 9;
            maxdays = 30;}
            else if (mes.Contains("Outubro")) { 
                numMes = 10;
            maxdays = 31;}
            else if (mes.Contains("Novembro")) { 
                numMes = 11;
            maxdays = 30;}
            else if (mes.Contains("Dezembro")) { 
                numMes = 12;
            maxdays = 31;}



            DateTime data1 = new DateTime(ano, numMes, 1);
            DateTime data2 = new DateTime(ano, numMes, maxdays);

            foreach(var x in listaTudo)
            if(DateTime.Compare(data1,x.data) == -1 && DateTime.Compare(data2, x.data) == 1)
                {
                    funcionarioModels.Add(x);
                }
            return funcionarioModels;



        }

        public TimeSpan horaTrabalhada(TimeSpan horaEntrada, TimeSpan horaSaida, TimeSpan horaSaidaAlmoco, TimeSpan horaVoltaAlmoco)
        {
            TimeSpan manha = horaSaidaAlmoco - horaEntrada;
            TimeSpan tarde = horaSaida - horaVoltaAlmoco;

            TimeSpan horaTrabalhada = tarde + manha;
            return horaTrabalhada;
        }
      }
    }



