using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelo.Atributos;

namespace Biblioteca.Modelo
{
    [AtributoClasse(DataHoraInativacao = "DataHoraInativacao", TipoLog = Log.LogTipo.ManutencaoTabelaUsuarios, NomeTabela = "usuarios")]
    public class Usuario : ModeloBase<Usuario>
    {
        #region Propriedades
        [AtributoPropriedade(Caption = "Código", IsChave = true, NomeColuna = "Codigo", OrdemGrid = 1, Tamanho = 20)]
        public string Codigo { get; set; }

        [AtributoPropriedade(Caption = "Nome", IsChave = false, NomeColuna = "Nome", OrdemGrid = 2, Tamanho = 80)]
        public string Nome { get; set; }

        [AtributoPropriedade(Caption = "Senha", IsChave = false, NomeColuna = "Senha", OcultaGrid = true, Tamanho = 32)]
        public string Senha { get; set; }

        [AtributoPropriedade(Caption = "Data/Hora Cadastro", IsChave = false, NomeColuna = "DataHoraCadastro", OrdemGrid = 3)]
        public DateTime DataHoraCadastro { get; set; }

        [AtributoPropriedade(Caption = "Data/Hora Inativação", IsChave = false, NomeColuna = "DataHoraInativacao", OrdemGrid = 4)]
        public DateTime DataHoraInativacao { get; set; }
        #endregion

        #region Construtores
        public Usuario()
            : base()
        {
        }
        #endregion

        #region Enums
        public enum TipoUsuario
        {
            Master = 1,
            Padrao = 2,
            Visualizacao = 3
        }
        #endregion
    }
}
