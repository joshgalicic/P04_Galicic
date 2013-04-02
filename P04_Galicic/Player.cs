using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Galicic
{
	public class Player
	{
		public Player()
		{
			currentRoom = Room.roomList[0];
		}

		public Room currentRoom;
	
		public void move(Room room)
		{

			currentRoom = room;
		}
	}

}
