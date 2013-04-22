using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P04_Galicic;

namespace P04_Galicic_Tests
{
	[TestClass]
	public class UnitTest1
	{		
		[TestMethod]
		public void playerStartsinRoomZero()
		{
			Room.setupRooms();
			Player player1 = new Player();

			Assert.AreEqual(player1.currentRoom, Room.roomList[0]);
		}

		[TestMethod]
		public void playerMovesToAnotherRoom()
		{
			Room.setupRooms();
			Player player1 = new Player();

			player1.move(Room.roomList[1]);

			Assert.AreEqual(player1.currentRoom, Room.roomList[1]);

		}

		[TestMethod]
		public void roomsAllLinkTogether()
		{
			game.setup();

			for (int i=0; i < Room.roomList.Count; i++)
			{
				Assert.AreEqual(Room.lookupRoom(i).doorNorth, Room.lookupRoom(i - game.width).id);	
				Assert.AreEqual(Room.lookupRoom(i).doorSouth, Room.lookupRoom(i + game.width).id);
				//Assert.AreEqual(Room.lookupRoom(i).door2, Room.lookupRoom(i + 1).id);
				//Assert.AreEqual(Room.lookupRoom(i).door4, Room.lookupRoom(i - 1).id);
			}
		}

		[TestMethod]
		public void wumpusInitializesToRandomRoom()
		{
			game.setup();
			int sum = 0;
			foreach (Room room in Room.roomList)
			{
				sum += room.hasWumpus;
			}
			Assert.AreEqual(1,sum);
		}

		[TestMethod]
		public void wumpusMovesToAdjacentRoom()
		{
			game.setup();
			Wumpus wumpus = new Wumpus();
			int oldRoomID = -1;
			int newRoomID = -1;
			foreach (Room room in Room.roomList)
			{
				if (room.hasWumpus == 1)
					oldRoomID = room.id;
			}

			wumpus.moveRandom();
			wumpus.moveRandom();

			foreach (Room room in Room.roomList)
			{
				if (room.hasWumpus == 1)
					newRoomID = room.id;
			}
			Assert.AreNotEqual(oldRoomID, newRoomID);

		}
	}
}
