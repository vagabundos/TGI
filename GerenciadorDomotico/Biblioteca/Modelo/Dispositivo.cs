using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo.Atributos;

namespace Biblioteca.Modelo
{
    [AtributoClasse(TipoLog = Log.LogTipo.ManutencaoTabelaDispositivos, NomeTabela = "dispositivos")]
    public class Dispositivo : ModeloBase<Dispositivo>
    {
        #region Propriedades
        [AtributoPropriedade(Caption = "Código", IsChave = true, NomeColuna = "Codigo", OrdemGrid = 1, Tamanho = 20)]
        string Codigo { get; set; }

        [AtributoPropriedade(Caption = "Descrição", IsChave = false, NomeColuna = "Descricao", OrdemGrid = 2, Tamanho = 80)]
        string Descricao { get; set; }

        [AtributoPropriedade(Caption = "Tipo", IsChave = false, NomeColuna = "Tipo", OrdemGrid = 3)]
        TipoSensor Tipo { get; set; }

        [AtributoPropriedade(Caption = "Piso", IsChave = true, NomeColuna = "Piso", OrdemGrid = 4, Tamanho = 20)]
        int Piso { get; set; }

        [AtributoPropriedade(Caption = "Posição X", IsChave = false, NomeColuna = "PosicaoX", OrdemGrid = 5)]
        int PosicaoX { get; set; }

        [AtributoPropriedade(Caption = "Posição Y", IsChave = false, NomeColuna = "PosicaoY", OrdemGrid = 6)]
        int PosicaoY { get; set; }
        #endregion

        #region Construtores
        public Dispositivo()
            : base()
        {
        }
        #endregion

        #region Enums
        public enum TipoSensor
        {
            Temperatura = 1,
            Iluminacao = 2,
            Umidade = 3,
            Presenca = 4,
            Distancia = 5,
            ServoMotor = 6
        }
        #endregion
    }
}
