using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourInARowTests
{
    [TestClass]
    public class TestBoardBehavior
    {
        Board testBoard = new Board(6, 7);
        Player testPlayer;
        Cell testCell;

        public void TestSetup()
        {
            testPlayer = new Player();

            Game.CurrentPlayer = testPlayer;
            Game.CurrentPlayer.Symbol = "X";
        }

        [TestMethod]
        public void Test_FindNextLocationInColumn_EmptyColumn()
        {
            // Total number of lines is 6 (0-5, zero based)
            // 5 is the most bottom line

            int columnNumber = 0;
            int freeSpot = testBoard.getVacantLine(columnNumber);

            Assert.AreEqual(5, freeSpot);
        }

        [TestMethod]
        public void Test_FindNextLocationInColumn_NoneEmptyColumn()
        {
            // Total number of lines is 6 (0-5, zero based)
            // 5 is the most bottom line, so if we put a piece in column 0,
            // we should get 4 as the next free spot in column 0 when we
            // put another piece

            TestSetup();

            testCell = new Cell(5, 4);
            testBoard.SetCellOnBoard(testCell);

            int freeSpot = testBoard.getVacantLine(testCell.ColumnNumber);

            Assert.AreEqual(4, freeSpot);
        }
    }
}