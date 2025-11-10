using System;
using System.Runtime.Serialization;
using Manutencao.Solicitacao.Dominio.Subsidiarias;


namespace Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao
{
    public class SolicitacaoDeManutencao : Entidade
    {
        public Solicitante Solicitante { get; private set; }
        public Subsidiaria Subsidiaria { get; private set; }
        public TipoDeSolicitacaoDeManutencao TipoDeSolicitacaoDeManutencao { get; private set; }

        public String Justificativa { get; private set; }
        public Contrato Contrato { get; private set; }
        public DateTime InicioDesejadoParaManutencao { get; private set; }
        public DateTime DataDaSolicitacao { get; private set; }
        public StatusDeSolicitacao Status { get; private set; }

        private SolicitacaoDeManutencao() { }

        public SolicitacaoDeManutencao(
            Solicitante solicitante,
            Subsidiaria subsidiaria,
            TipoDeSolicitacaoDeManutencao tipoDeSolicitacaoDeManutencao,
            String justificativa,
            Contrato contrato,
            DateTime inicioDesejadoParaManutencao)
        {
            ExcecaoDeDominio.LancarQuando(subsidiaria == null, "Subsidiária é obrigatória.");
            ExcecaoDeDominio.LancarQuando(string.IsNullOrWhiteSpace(justificativa), "Justificativa é obrigatória.");
            ExcecaoDeDominio.LancarQuando(inicioDesejadoParaManutencao < DateTime.Now.Date, "Data de Início para manutenção não pode ser inferior a data atual.");

            Solicitante = new Solicitante(identificadorDoSolicitante, nomeDoSolicitante);
            Subsidiaria = subsidiaria;
            TipoDeSolicitacaoDeManutencao = tipoDeSolicitacaoDeManutencao;
            Justificativa = justificativa;
            Contrato = new Contrato(numeroDoContrato, nomeDaTerceirizada, cnpjDaTerceirizada, gestorDoContrato, dataFinalDaVigencia);
            InicioDesejadoParaManutencao = inicioDesejadoParaManutencao;
            DataDaSolicitacao = DateTime.Now;
            Status = StatusDeSolicitacao.Pendente;
        }

        public void Cancelar()
        {
            Status = StatusDeSolicitacao.Cancelada;
        }
    }
}
