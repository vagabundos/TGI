﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Usuario
	{
		#region Propriedades
		public string Codigo { get; set; }
		public string Nome { get; set; }
		public string Senha { get; set; }
		public DateTime dtCadastro { get; set; }
		public DateTime dtInativacao { get; set; }
		#endregion

		#region Construtores
		public Usuario()
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
