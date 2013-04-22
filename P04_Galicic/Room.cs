using System;
using System.Collections.Generic;

namespace P04_Galicic
{
	public class Room
	{
		public static List<Room> roomList = new List<Room>();

		public bool hasPit;

		public bool smells;

		public bool breeze;

		public int id { get; set; }

		public Room()
		{
			id = roomList.Count;
			int currentRow = id / game.width;

			doorEast = ((id + 1) % game.width) + currentRow*game.width;

			doorWest = game.mod(id-1,game.width) + currentRow * game.width;
			
			doorSouth = (id + game.width) % (game.width * game.height);

			doorNorth = game.mod(id - game.width,game.width * game.height);			
		}

		public Room(int zero)
		{
			id = -1;
			doorNorth = -1;
			doorEast = -1;
			doorSouth = -1;
			doorWest = -1;
		}

		public int doorNorth { get; set; }

		public int doorEast { get; set; }

		public int doorSouth { get; set; }

		public int doorWest { get; set; }

		public static Room lookupRoom(int num)
		{
			try
			{
				return roomList[num];
			}
			catch (Exception)
			{
				Room nullRoom = new Room(0);

				return nullRoom;
			}
		}

		public static void setupRooms()
		{
			for (int i = 0; i < game.width * game.height; i++)
			{
				roomList.Add(new Room());
			}
		}

		public static void setPit()
		{
			Random value = new Random();
			int randomNum = value.Next(1, game.width * game.height);
			Room.lookupRoom(randomNum).hasPit = true;

			Room.lookupRoom(Room.lookupRoom(randomNum).doorEast).breeze = true;
			Room.lookupRoom(Room.lookupRoom(randomNum).doorNorth).breeze = true;
			Room.lookupRoom(Room.lookupRoom(randomNum).doorWest).breeze = true;
			Room.lookupRoom(Room.lookupRoom(randomNum).doorSouth).breeze = true;
		}

		public void setSmell()
		{
			smells = true;
			lookupRoom(doorEast).smells = true;
			lookupRoom(doorNorth).smells = true;
			lookupRoom(doorSouth).smells = true;
			lookupRoom(doorWest).smells = true;
		}

		public void clearSmell()
		{
			smells = false;
			lookupRoom(doorEast).smells = false;
			lookupRoom(doorNorth).smells = false;
			lookupRoom(doorSouth).smells = false;
			lookupRoom(doorWest).smells = false;
		}
		public override string ToString()
		{
			return id.ToString();
		}

	}
}