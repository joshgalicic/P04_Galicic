using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Galicic
{
	public class Player
	{
		public bool dead;

		public Player()
		{
			currentRoom = Room.roomList[0];
			dead = false;
		}

		public Room currentRoom;
	
		public void move(Room room)
		{
			currentRoom = room;

			if (currentRoom.hasPit == true)
				dead = true;
			else if (currentRoom == game.wumpus.currentRoom)
				dead = true;
		}

		public void moveNorth()
		{
			move(Room.lookupRoom(currentRoom.doorNorth));
			
		}
		public void moveSouth()
		{
			move(Room.lookupRoom(currentRoom.doorSouth));
		}
		public void moveEast()
		{
			move(Room.lookupRoom(currentRoom.doorEast));
		}
		public void moveWest()
		{
			move(Room.lookupRoom(currentRoom.doorWest));
		}
		public override string ToString()
		{
			return "Player is in room " + currentRoom.id + ". is dead? " + dead + "\n";
		}

	}

}
