using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Modelo.Atributos
{
    /// <summary>
    /// Atributo para propriedades das classes de Modelo
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class AtributoPropriedade : System.Attribute
    {
        /// <summary>
        /// Campo de descrição da propriedade
        /// </summary>
        public string Caption;

        /// <summary>
        /// Nome da coluna no banco de dados
        /// </summary>
        public string NomeColuna;

        /// <summary>
        /// Tamanho do campo para MaxLen
        /// </summary>
        public int Tamanho;

        /// <summary>
        /// propriedade para definir se campo é chave na tabela
        /// </summary>
        public bool IsChave;

        /// <summary>
        /// Exibe a propriedade no grid.
        /// </summary>
        public bool OcultaGrid;

        /// <summary>
        /// Define a ordem da propriedade no grid
        /// </summary>
        public int OrdemGrid;
    }
}
