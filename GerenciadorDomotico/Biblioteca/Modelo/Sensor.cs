using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelo
{
	public class Sensor
	{
		#region Propriedades
		string Codigo { get; set; }
		string Descricao { get; set; }
		TipoSensor Tipo { get; set; }
		int Piso { get; set; }
		int PosicaoX { get; set; }
		int PosicaoY { get; set; }
		#endregion

		#region Construtores
		public Sensor()
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
