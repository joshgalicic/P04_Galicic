using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04_Galicic
{
	public class Wumpus
	{

		public Room currentRoom;

		public Wumpus()
		{
			do
			{
				Random value = new Random();
				int randomNum = value.Next(1, game.width * game.height);
				//Room.lookupRoom(randomNum).hasWumpus = true;
				currentRoom = Room.lookupRoom(randomNum);
			} while (currentRoom.hasPit == true);
		}

		public void moveRandom()
		{
			Random value = new Random();
			int randomNum = value.Next(1, 10);
				switch (randomNum)
				{
					case 1:	move(Room.lookupRoom(currentRoom.doorNorth));
						break;
					case 2: move(Room.lookupRoom(currentRoom.doorEast));
						break;
					case 3: move(Room.lookupRoom(currentRoom.doorSouth));
						break;
					case 4: move(Room.lookupRoom(currentRoom.doorWest));
						break;
					default:
						break;
				}			
		}

		public void move(Room room)
		{
			clearSmell();
			currentRoom = room;
			setSmell();
		}

		public void setSmell()
		{
			Room.lookupRoom(currentRoom.doorEast).setSmell();
			Room.lookupRoom(currentRoom.doorSouth).setSmell();
			Room.lookupRoom(currentRoom.doorWest).setSmell();
			Room.lookupRoom(currentRoom.doorNorth).setSmell();
		}

		public void clearSmell()
		{
			Room.lookupRoom(currentRoom.doorEast).clearSmell();
			Room.lookupRoom(currentRoom.doorSouth).clearSmell();
			Room.lookupRoom(currentRoom.doorWest).clearSmell();
			Room.lookupRoom(currentRoom.doorNorth).clearSmell();
		}

		public override string ToString()
		{
			return "Wumpus is in room " + currentRoom.id + "\n";
		}


	}
}
