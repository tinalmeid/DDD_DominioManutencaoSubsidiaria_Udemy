using System;

namespace Manutencao.Solicitacao.Dominio.SolicitacoesDeManutencao
{
    public class Solicitante
    {
        public int Identificador { get; private set; }
        public String Nome { get; private set; }

        private Solicitante() { }
        private Solicitante(int identificador, String nome)
        {
            ExcecaoDeDominio.LancarQuando(string.IsNullOrWhiteSpace(nome), "Nome do solicitante é obrigatório.");

            Identificador = identificador;
            Nome = nome;
        }
    }
}
