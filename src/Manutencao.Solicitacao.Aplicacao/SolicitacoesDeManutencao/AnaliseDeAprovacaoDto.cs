namespace Manutencao.Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public class AnaliseDeAprovacaoDto
    {
        public int AprovadoId { get; set; }
        public string NomeDoAprovador { get; set; }
        public string IdDaSolicitacao { get; set; }
        public bool Aprovado { get; set; }
    }
}