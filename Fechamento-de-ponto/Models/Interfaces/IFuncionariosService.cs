

namespace Fechamento_de_ponto.Models.Interfaces
{
    public interface IFuncionariosService
    {
        List<FuncionarioModel> GetFuncionarios();
        List<FuncionarioModel> BuscaEspecifico(String mes, int ano);
        TimeSpan horaTrabalhada(TimeSpan horaEntrada, TimeSpan horaSaida, TimeSpan horaSaidaAlmoco, TimeSpan horaVoltaAlmoco);
    }
}
