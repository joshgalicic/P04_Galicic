using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Galicic
{
	public class Room
	{
		public Room()
		{
		}
		public Room(int x, int y)
		{
			positionX = x;
			positionY = y;
		}

		private int positionX;
		private int positionY;

		bool hasWumpus;
		bool hasPit;
	}
}
