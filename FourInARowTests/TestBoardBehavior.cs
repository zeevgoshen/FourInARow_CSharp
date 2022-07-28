using FourInARowModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourInARowTests
{
    [TestClass]
    public class TestBoardBehavior
    {
        Board testBoard = new Board(6, 7);
        
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(6, testBoard.theGrid.GetLength(0));
            Assert.AreEqual(7, testBoard.theGrid.GetLength(1));
        }
    }
}
