    using System;

namespace SondaProject.Models
{
    public class Sonda
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CoordX { get; set; }
		public int CoordY { get; set; }
        public char Direction { get; set;}
    }
}
