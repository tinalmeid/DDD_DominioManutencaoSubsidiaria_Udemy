using System;

namespace Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao
{
    public class Contrato
    {
        public string Numero { get; private set; }
        public string NomeDaTerceirizada { get; private set; }
        public string CNPJDaTerceirizada { get; private set; }
        public string GestorDoContrato { get; private set; }    
        public DateTime DataFinalDaVigencia { get; private set; }

        private Contrato() { }

        public Contrato(
            string numero,
            string nomeDaTerceirizada,
            string cnpjDaTerceirizada,
            string gestorDoContrato,
            DateTime dataFinalDaVigencia)
        {
            Numero = numero;
            NomeDaTerceirizada = nomeDaTerceirizada;
            CNPJDaTerceirizada = cnpjDaTerceirizada;
            GestorDoContrato = gestorDoContrato;
            DataFinalDaVigencia = dataFinalDaVigencia;
        }
    }
}