using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P04_Galicic;

namespace P04_Galicic_Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Wumpus test = new Wumpus();

			Assert.AreEqual(true,test.truth());
		}
	}
}
