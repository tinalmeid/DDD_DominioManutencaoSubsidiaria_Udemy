using System.Threading.Tasks;
using Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao;

namespace Manuetncao.Solicitaco.Aplicacao.SolicitacoesDeManutencao
{
    public interface INotificaContextoDeServico
    {
        Task Notificar(SolicitacaoDeManutencao solicitacaoDeManutencao);
    }
}