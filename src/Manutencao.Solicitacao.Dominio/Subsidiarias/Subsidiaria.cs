using System;
using Manutencao.Solicitacao.Dominio;

namespace Manutencao.Solicitacao.Dominio.Subsidiarias
{
    public class Subsidiaria : Entidade
    {
        public string Nome { get; private set; }

        public Subsidiaria(string nome)
        {
            ExcecaoDeDominio.LancarQuando(string.IsNullOrEmpty(nome), "O nome da subsidiária é Obrigatório.");

            Nome = nome;
        }

    }
}