using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo.Atributos;
using Dados;

namespace Biblioteca.Modelo
{
    [AtributoClasse(NomeTabela = "SistemaLogs")]
    public class Log : ModeloBase<Log>
    {
        #region Propriedades
        public int ID { get; set; }
        public LogTipo Tipo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHoraInclusao { get; set; }
        #endregion

        #region Construtores
        public Log()
            : base()
        {

        }
        #endregion

        #region Enums
        public enum LogTipo
        {
            // Erro geral
            Erro = 1,
            // Troca de mensagens
            RequisicaoEnvio = 2,
            RequisicaoRecebida = 3,
            // Entidades
            ManutencaoTabelaUsuarios = 4,
            ManutencaoTabelaPisos = 5,
            ManutencaoTabelaDispositivos = 6
        }
        #endregion
    }
}