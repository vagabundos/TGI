using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
	public class Piso
	{
		#region Propriedades
        string Codigo { get; set; }
		string Descricao { get; set; }
		byte[] imagem { get; set; }
		#endregion

		#region Construtores
		public Piso()
		{
		}
		#endregion
	}
}
