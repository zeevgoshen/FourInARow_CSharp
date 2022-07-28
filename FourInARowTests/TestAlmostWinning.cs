using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FourInARowTests
{
    [TestClass]
    public class TestAlmostWinning
    {
        Board testBoard = new Board(7, 6);
        Player testPlayer;
        Cell testCell1;
        Cell testCell2;
        Cell testCell3;
        Cell testCell4;


        public void TestSetup()
        {
            testPlayer = new Player();

            Game.CurrentPlayer = testPlayer;
            Game.CurrentPlayer.Symbol = "X";
        }

        [TestMethod]
        public void Test_Horizontal_Not_Winning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(0, 1);
            testCell2 = new Cell(0, 2);
            testCell3 = new Cell(1, 3);
            testCell4 = new Cell(0, 4);

            testBoard.SetCellOnBoard(testCell1);
            testBoard.SetCellOnBoard(testCell2);
            testBoard.SetCellOnBoard(testCell3);
            testBoard.SetCellOnBoard(testCell4);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void Test_Vertical_Not_Winning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(1, 0);
            testCell2 = new Cell(2, 0);
            testCell3 = new Cell(5, 0);
            testCell4 = new Cell(4, 0);

            testBoard.SetCellOnBoard(testCell1);
            testBoard.SetCellOnBoard(testCell2);
            testBoard.SetCellOnBoard(testCell3);
            testBoard.SetCellOnBoard(testCell4);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void Test_AscendingDiagonal_Not_Winning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(0, 0);
            testCell2 = new Cell(1, 1);
            testCell3 = new Cell(2, 1);
            testCell4 = new Cell(3, 3);

            testBoard.SetCellOnBoard(testCell1);
            testBoard.SetCellOnBoard(testCell2);
            testBoard.SetCellOnBoard(testCell3);
            testBoard.SetCellOnBoard(testCell4);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void Test_DescendingDiagonal_Not_Winning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(3, 3);
            testCell2 = new Cell(2, 1);
            testCell3 = new Cell(1, 1);
            testCell4 = new Cell(0, 0);

            testBoard.SetCellOnBoard(testCell1);
            testBoard.SetCellOnBoard(testCell2);
            testBoard.SetCellOnBoard(testCell3);
            testBoard.SetCellOnBoard(testCell4);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard);

            Assert.AreEqual(res, false);
        }
    }
}