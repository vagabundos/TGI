using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo.Atributos;

namespace Biblioteca.Modelo
{
    [AtributoClasse(TipoLog = Log.LogTipo.ManutencaoTabelaPisos, NomeTabela = "pisos")]
    public class Piso : ModeloBase<Piso>
    {
        #region Propriedades
        [AtributoPropriedade(Caption = "Código", IsChave = true, NomeColuna = "Codigo", OrdemGrid = 1, Tamanho = 20)]
        public string Codigo { get; set; }

        [AtributoPropriedade(Caption = "Descrição", IsChave = false, NomeColuna = "Descricao", OrdemGrid = 2, Tamanho = 80)]
        public string Descricao { get; set; }

        [AtributoPropriedade(Caption = "Imagem", IsChave = false, NomeColuna = "Imagem", OrdemGrid = 3, OcultaGrid = true)]
        public byte[] Imagem { get; set; }
        #endregion

        #region Construtores
        public Piso()
            : base()
        {
        }
        #endregion
    }
}
