using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P04_Galicic;

namespace P04_Galicic_Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void roomHasFourNullDoorsAtStart()
		{
			Room room = new Room();
			Assert.AreEqual(-1, room.door1);
			Assert.AreEqual(-1, room.door2);
			Assert.AreEqual(-1, room.door3);
			Assert.AreEqual(-1, room.door4);

			//Assert.AreEqual(true,test.truth());
		}
		
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
			Room.setupRooms();
			Room.scrambleLinks();

			foreach (Room room in Room.roomList)
			{
				Assert.AreNotEqual(room.door1, -1);
				
				Assert.AreNotEqual(room.door2, -1);
				Assert.AreNotEqual(room.door3, -1);
				Assert.AreNotEqual(room.door4, -1);

			}
		}
	}
}
