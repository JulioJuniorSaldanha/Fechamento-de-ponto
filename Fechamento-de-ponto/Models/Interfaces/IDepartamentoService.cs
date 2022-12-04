namespace Fechamento_de_ponto.Models.Interfaces
{
    public interface IDepartamentoService
    {
        List<DepartamentoModel> getDepartamento();
        double calculaTotalpagar(string mes, int ano);
        void gerarjSon();
    }
}
