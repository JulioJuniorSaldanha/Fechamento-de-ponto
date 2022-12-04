using Fechamento_de_ponto.Properties.Services;

namespace Fechamento_de_ponto.Models
{
    public class DepartamentoModel
    {
       public int codigo { get; set; }
       public string nomeDepartamento { get; set; }
       public string mesVigencia { get; set; }
       public int anoVigencia { get; set; }
       public double totalPagar { get; set; }
       public float totalDescontos { get; set; }
       public float totalExtras { get; set; }
       public List<FuncionarioModel> funcionarios { get; set; }

        public DepartamentoModel(int codigo,string nomeDepartamento,string mesVigencia,int anoVigencia,double totalPagar,List<FuncionarioModel> funcionarios)
        {
            this.codigo = codigo;
            this.nomeDepartamento = nomeDepartamento;
            this.mesVigencia= mesVigencia;
            this.anoVigencia= anoVigencia;
            this.totalPagar = totalPagar;
            this.funcionarios= funcionarios;
        }
    }
}
