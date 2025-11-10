using System;
using Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao;
using Manutencao.Solicitacao.Dominio.Subsidiarias;
using Manutencao.Solicitacao.Testes._Util;
using Nosbor.FluentBuilder.Lib;
using Xunit;

namespace Manutencao.Solicitacao.Testes.Dominio.SolicitacoesDeManutencao
{
    public class SolicitacaoDeManutencaoTeste
    {
        private const string identificadorDoSolicitante = "10";
        private const string nomeDoSolicitante = "Solicitante Teste";
        private const string numeroDoContrato = "12345";
        private const string nomeDaTerceirizadaDoContrato = "Terceirizada Teste";
        private const string cnpjDaTerceirizadaDoContrato = "12.345.678/0001-90";
        private const string gestorDoContrato = "Gestor Teste";
        private readonly DateTime _dataFinalDaVigenciaDoContrato = DateTime.Now.AddMonths(2);
        private readonly TipoDeSolicitacaoDeManutencao _tipoDeSolicitacaoDeManutencao = TipoDeSolicitacaoDeManutencao.Jardinagem;
        private string _justificativa = "Justificativa Teste";
        private Subsidiaria _subsidiaria = FluentBuilder<Subsidiaria>.Um().Build();

        private SolicitacaoDeManutencao CriarNovaSolicitacao()
        {
            return new SolicitacaoDeManutencao(
                _subsidiaria,
                identificadorDoSolicitante,
                nomeDoSolicitante,
                _tipoDeSolicitacaoDeManutencao,
                _justificativa,
                numeroDoContrato,
                nomeDaTerceirizadaDoContrato,
                cnpjDaTerceirizadaDoContrato,
                gestorDoContrato,
                _dataFinalDaVigenciaDoContrato,
                _inicioDesejadoParaManutencao);
        }
        [Fact]
        public void Deve_criar_solicitacao_de_manutencao()
        {
            var solicitacao = new
            {
                Subsidiaria = _subsidiaria,
                Solicitante = new Solicitante(identificadorDoSolicitante, nomeDoSolicitante),
                TipoDeSolicitacaoDeManutencao = _tipoDeSolicitacaoDeManutencao,
                Justificativa = _justificativa,
                Contrato = new Contrato(
                    numeroDoContrato,
                    nomeDaTerceirizadaDoContrato,
                    cnpjDaTerceirizadaDoContrato,
                    gestorDoContrato,
                    _dataFinalDaVigenciaDoContrato),
                InicioDesejadoParaManutencao = _inicioDesejadoParaManutencao
            };

            var solicitacaoDeManutencao = CriarNovaSolicitacao();

            solicitacao.ToExpectedObject().ShouldMatch(solicitacaoDeManutencao);

        }

