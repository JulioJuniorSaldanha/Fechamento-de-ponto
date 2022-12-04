namespace Fechamento_de_ponto.Models
{
    public class FuncionarioModel
    {
       public int codigo { get; set; }
       public string nome { get; set; }
       public double valorHora { get; set; }
       public DateTime data { get; set; }
       public TimeSpan horaEntrada { get; set; }
       public TimeSpan horaSaida { get; set; }
       public TimeSpan horaSaidaAlmoco { get; set; }
       public TimeSpan horaVoltaAlmoco { get; set; }
       public TimeSpan horaTrabalhada { get; set; }

        public FuncionarioModel(string codigo, string nome, double valorHora, DateTime data, TimeSpan horaEntrada, TimeSpan horaSaida, TimeSpan horaSaidaAlmoco, TimeSpan horaVoltaAlmoco,TimeSpan horaTrabalhada)
        {
            this.codigo = int.Parse(codigo);
            this.nome= nome;
            this.valorHora= valorHora;
            this.data = data;
            this.horaEntrada= horaEntrada;
            this.horaSaidaAlmoco = horaSaidaAlmoco;
            this.horaVoltaAlmoco= horaVoltaAlmoco;
            this.horaSaida= horaSaida;     
            this.horaTrabalhada= horaTrabalhada;
        }
    }
}
