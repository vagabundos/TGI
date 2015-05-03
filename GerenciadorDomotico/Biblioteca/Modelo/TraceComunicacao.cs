using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo.Atributos;
using Dados;

namespace Biblioteca.Modelo
{
    [AtributoClasse(NomeTabela = "TraceComunicacao")]
    public class TraceComunicacao : ModeloBase<TraceComunicacao>
    {
        #region Propriedades
        [AtributoPropriedade(Caption = "ID", IsChave = true, NomeColuna = "ID", OrdemGrid = 1, isInternalID = true)]
        public int ID { get; set; }

        [AtributoPropriedade(Caption = "Procedencia", IsChave = false, NomeColuna = "Procedencia", OrdemGrid = 2)]
        public ProcedenciaTrace Procedencia { get; set; }

        [AtributoPropriedade(Caption = "Controlador", IsChave = false, NomeColuna = "Controlador", OrdemGrid = 3)]
        public string Controlador { get; set; }

        [AtributoPropriedade(Caption = "Dispositivo", IsChave = false, NomeColuna = "Dispositivo", OrdemGrid = 4)]
        public string Dispositivo { get; set; }

        [AtributoPropriedade(Caption = "Data/Hora Ocorrência", IsChave = false, NomeColuna = "DataHoraOcorrencia", OrdemGrid = 5)]
        public DateTime DataHoraOcorrencia { get; set; }

        [AtributoPropriedade(Caption = "Mensagem", IsChave = false, NomeColuna = "Mensagem", OrdemGrid = 6, Tamanho = 4000)]
        public string Mensagem { get; set; }
        #endregion

        #region Construtores
        public TraceComunicacao()
            : base()
        {

        }
        #endregion

        #region Enums
        public enum ProcedenciaTrace
        {
            // Diferenciará se a mensagem foi enviada pelo HomeOn ou pelo Controlador
            HomeOn = 1,
            Controlador = 2
        }
        #endregion
    }
}