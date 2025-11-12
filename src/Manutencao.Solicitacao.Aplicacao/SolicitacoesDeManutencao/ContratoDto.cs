using System;

namespace Manutencao.Solicitacao.Aplicacao.SolicitacoesDeManutencao
{
    public class ContratoDto
    {
        public string NumeroDoContrato { get; set; }
        public string NomeDaTerceirizadaDoContrato { get; set; }
        public string CnpjDaTerceirizadaDoContrato { get; set; }
        public string GestorDoContrato { get; set; }
        public DateTime DataFinalDaVigenciaDoContrato { get; set; }
        
    }
}