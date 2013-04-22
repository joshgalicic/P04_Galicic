using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Galicic
{
	public static class game
	{
		public static int height = 4;
		public static int width = 4;

		public static Wumpus wumpus;
		public static Player player;

		public static void setup()
		{
			Room.setupRooms();
			Room.setPit();
			wumpus = new Wumpus();
			player = new Player();
			initializeRandomDoor();

		}

		private static void initializeRandomDoor()
		{
			Random value = new Random();
			int randomNum = value.Next(1, game.width * game.height);

			Room.lookupRoom(randomNum).doorNorth = value.Next(1, game.width * game.height);
		}

		public static int mod(int x, int m) // Proper Modulus function
		{
			return (x % m + m) % m;
		}
	}

}
