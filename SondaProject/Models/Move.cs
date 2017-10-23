using System;

namespace SondaProject.Models
{
	public class Move
	{
		public long Id { get; set; }
		public string Moves { get; set; }
		public int CoordX { get; set; }
		public int CoordY { get; set; }
		public char Direction { get; set; }
	}
}
