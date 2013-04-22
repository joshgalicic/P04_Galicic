using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P04_Galicic
{
	public partial class Form1 : Form
	{
		private List<System.Windows.Forms.RichTextBox> Rooms;
		private bool arrow;

		public Form1()
		{
			InitializeComponent();
			Rooms = new List<RichTextBox>();

			initializeRoomList();
			updateRoomBoxes();

			foreach (Room room in Room.roomList)
			{
				infoBox.Text += room.id + " Initialized\n";
			}

			infoBox.Text += "Wumpus started in room " + game.wumpus.currentRoom.id + "\n";
			
			foreach (Room room in Room.roomList)
			{
				if (room.hasPit)
					infoBox.Text += "Pit is in room " + room.id + "\n";
			}

			infoBox.Text += "Player started in room " + game.player.currentRoom.id + "\n";

			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void room1_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnSouth_Click(object sender, EventArgs e)
		{
			if (arrow)
				fireArrow(2);
			else
			{
				game.wumpus.moveRandom();
				game.player.moveSouth();
				infoBox.Text += game.player.ToString();
				infoBox.Text += game.wumpus.ToString();
				updateRoomBoxes();
				updatePlayerInfo();
			}
		}

		private void btnNorth_Click(object sender, EventArgs e)
		{
			if (arrow)
				fireArrow(0);
			else
			{
				game.wumpus.moveRandom();
				game.player.moveNorth();
				infoBox.Text += game.player.ToString();
				infoBox.Text += game.wumpus.ToString();
				updateRoomBoxes();
				updatePlayerInfo();
			}

		}

		private void btnEast_Click(object sender, EventArgs e)
		{
			if (arrow)
				fireArrow(1);
			else
			{
				game.wumpus.moveRandom();
				game.player.moveEast();
				infoBox.Text += game.player.ToString();
				infoBox.Text += game.wumpus.ToString();
				updateRoomBoxes();
				updatePlayerInfo();
			}

		}

		private void btnWest_Click(object sender, EventArgs e)
		{
			if (arrow)
				fireArrow(3);
			else
			{
				game.wumpus.moveRandom();
				game.player.moveWest();
				infoBox.Text += game.player.ToString();
				infoBox.Text += game.wumpus.ToString();
				updateRoomBoxes();
				updatePlayerInfo();
			}

		}

		private void updateRoomBoxes()
		{
			int i = 0;
			foreach (RichTextBox room in Rooms)
			{
				room.Clear();
				if (Room.lookupRoom(i).hasPit)
					room.Text += "P ";
				if (Room.lookupRoom(i) == game.wumpus.currentRoom)
					room.Text += "W ";
				if (Room.lookupRoom(i).smells)
					room.Text += "S ";
				if (Room.lookupRoom(i).breeze)
					room.Text += "B ";
			 
				if (Room.lookupRoom(i) == game.player.currentRoom)
					room.Text += "X ";
				i++;
			}

		}

		private void updatePlayerInfo()
		{
			playerStatus.Clear();
			if (game.player.currentRoom.hasPit)
				MessageBox.Show("You died in a pit!");
			if (game.player.currentRoom == game.wumpus.currentRoom)
				MessageBox.Show("You have been eaten!");
			if (game.player.currentRoom.smells)
				playerStatus.Text += "This room smells weird!\n";
			if (game.player.currentRoom.breeze)
				playerStatus.Text += "I feel a breeze...\n";
		}

		private void initializeRoomList()
		{
			Rooms.Add(room0);
			Rooms.Add(room1);
			Rooms.Add(room2);
			Rooms.Add(room3);
			Rooms.Add(room4);
			Rooms.Add(room5);
			Rooms.Add(room6);
			Rooms.Add(room7);
			Rooms.Add(room8);
			Rooms.Add(room9);
			Rooms.Add(room10);
			Rooms.Add(room11);
			Rooms.Add(room12);
			Rooms.Add(room13);
			Rooms.Add(room14);
			Rooms.Add(room15);

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void richTextBox1_TextChanged_1(object sender, EventArgs e)
		{

		}

		private void btnShoot_Click(object sender, EventArgs e)
		{
			playerStatus.Clear();
			playerStatus.Text = "Choose which direction to fire!\n";
			arrow = true;
		}

		private void fireArrow(int direction)
		{
			switch (direction)
				{
					case 0: 
						if (Room.lookupRoom(game.player.currentRoom.doorNorth) == game.wumpus.currentRoom)
							MessageBox.Show("You Killed the wumpus!");
						else
							MessageBox.Show("You have failed to kill the wumpus.");
						break;
					case 1:
						if (Room.lookupRoom(game.player.currentRoom.doorEast) == game.wumpus.currentRoom)
							MessageBox.Show("You Killed the wumpus!");
						else
							MessageBox.Show("You have failed to kill the wumpus.");
						break;
					case 2:
						if (Room.lookupRoom(game.player.currentRoom.doorSouth) == game.wumpus.currentRoom)
							MessageBox.Show("You Killed the wumpus!");
						else
							MessageBox.Show("You have failed to kill the wumpus.");
						break;
					case 3:
						if (Room.lookupRoom(game.player.currentRoom.doorWest) == game.wumpus.currentRoom)
							MessageBox.Show("You Killed the wumpus!");
						else
							MessageBox.Show("You have failed to kill the wumpus.");
						break;
					default:
						MessageBox.Show("You have failed to kill the wumpus.");
						break;
				}			
			

		}
	}
}
