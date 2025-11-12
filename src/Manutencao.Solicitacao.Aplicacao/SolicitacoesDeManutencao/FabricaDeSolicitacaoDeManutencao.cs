using System;
using Manutencao.Solicitacao.Aplicacao.Subsidiarias;
using Manutencao.Solicitacao.Dominio;
using Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao;

namespace Manutencao.Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public class FabricaDeSolicitacaoDeManutencao
    {
        private readonly ISubsidiariaRepositorio _subsidiariaRepositorio;
        private readonly IBusccadorDeContrato _buscadorDeContrato;

        protected FabricaDeSolicitacaoDeManutencao()
        {
            // Construtor protegido para uso em testes ou herança
        }

        public FabricaDeSolicitacaoDeManutencao(
            ISubsidiariaRepositorio subsidiariaRepositorio,
            IBusccadorDeContrato buscadorDeContrato)
        {
            _subsidiariaRepositorio = subsidiariaRepositorio;
            _buscadorDeContrato = buscadorDeContrato;
        }

        public virtual SolicitacaoDeManutencao Fabricar(SolicitacaoDeManutencao dto)
        {
            var subsidiaria = _subsidiariaRepositorio.ObterPorId(dto.SubsidiariaId);
            ExcecaoDeDominioException.LancarQuando(subsidiaria == null,
             "A subsidiária não foi encontrada.");

            var contratoDto = _buscadorDeContrato.Buscar(dto.NumeroDoContrato).Result;
            ExcecaoDeDominioException.LancarQuando(contratoDto == null,
             "O contrato não foi encontrado.");

            var tipoDeSolicitacaoDeManutencao =
                Enum.Parse(typeof(TipoDeSolicitacaoDeManutencao),
                dto.TipoDeSolicitacaoDeManutencao.ToString());

            return new SolicitacaoDeManutencao(
                subsidiaria.Id,
                dto.SolicitanteId,
                dto.NomeDoSolicitante,
                (TipoDeSolicitacaoDeManutencao)tipoDeSolicitacaoDeManutencao,
                dto.Justificativa,
                contratoDto.NumeroDoContrato,
                contratoDto.NomeDaTerceirizada,
                contratoDto.CnpjDaTerceirizada,
                contratoDto.GestorDoContrato,
                contratoDto.DataFinalDaVigencia,
                dto.InicioDesejadoParaManutencao);
        }
    }   
}