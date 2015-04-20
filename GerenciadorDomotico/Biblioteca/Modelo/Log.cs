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
        [AtributoPropriedade(Caption = "ID", IsChave = true, NomeColuna = "ID", OrdemGrid = 1, isInternalID = true)]
        public int ID { get; set; }

        [AtributoPropriedade(Caption = "Tipo", IsChave = false, NomeColuna = "Tipo", OrdemGrid = 2)]
        public LogTipo Tipo { get; set; }

        [AtributoPropriedade(Caption = "Descrição", IsChave = false, NomeColuna = "Descricao", OrdemGrid = 3, Tamanho = 4000)]
        public string Descricao { get; set; }

        [AtributoPropriedade(Caption = "Data/Hora Inclusão", IsChave = false, NomeColuna = "DataHoraInclusao", OrdemGrid = 4)]
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
            ManutencaoTabelaDispositivos = 6,
            // Servico
            StatusServico = 7
        }
        #endregion
    }
}