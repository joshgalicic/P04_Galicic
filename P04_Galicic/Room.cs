using System;
using System.Collections.Generic;

namespace P04_Galicic
{
	public class Room
	{
		public static List<Room> roomList = new List<Room>();

		private bool hasPit;

		private bool hasWumpus;

		private int positionX;

		private int positionY;

		public Room()
		{
			roomList.Add(this);
			door1 = -1;
			door2 = -1;
			door3 = -1;
			door4 = -1;
		}

		public int door1 { get; set; }

		public int door2 { get; set; }

		public int door3 { get; set; }

		public int door4 { get; set; }

		public static void scrambleLinks()
		{
			throw new NotImplementedException();
		}

		public static void setupRooms()
		{
			roomList.Add(new Room());
			roomList.Add(new Room());
			roomList.Add(new Room());
			roomList.Add(new Room());
			roomList.Add(new Room());
		}
	}
}