﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using FourInARowModel;
using FourInARowModel.src.logic;

namespace FourInARowTests
{
    [TestClass]
    public class TestAlmostWinning
    {
        Board testBoard = new Board(7, 6);
        GameState testState;
        Player testPlayer;
        Cell testCell1;
        Cell testCell2;
        Cell testCell3;
        Cell testCell4;


        public void TestSetup()
        {
            testPlayer = new Player();
            testState = new GameState();

            testState.CurrentPlayer = testPlayer;
            testState.CurrentPlayer.Symbol = "X";

        }

        [TestMethod]
        public void Test_HorizontalWinning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(0, 1);
            testCell2 = new Cell(0, 2);
            testCell3 = new Cell(1, 3);
            testCell4 = new Cell(0, 4);

            testBoard.SetCellOnBoard(testCell1, testState);
            testBoard.SetCellOnBoard(testCell2, testState);
            testBoard.SetCellOnBoard(testCell3, testState);
            testBoard.SetCellOnBoard(testCell4, testState);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard, testState);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void Test_VerticalWinning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(1, 0);
            testCell2 = new Cell(2, 0);
            testCell3 = new Cell(5, 0);
            testCell4 = new Cell(4, 0);

            testBoard.SetCellOnBoard(testCell1, testState);
            testBoard.SetCellOnBoard(testCell2, testState);
            testBoard.SetCellOnBoard(testCell3, testState);
            testBoard.SetCellOnBoard(testCell4, testState);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard, testState);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void Test_AscendingDiagonalWinning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(0, 0);
            testCell2 = new Cell(1, 1);
            testCell3 = new Cell(2, 1);
            testCell4 = new Cell(3, 3);

            testBoard.SetCellOnBoard(testCell1, testState);
            testBoard.SetCellOnBoard(testCell2, testState);
            testBoard.SetCellOnBoard(testCell3, testState);
            testBoard.SetCellOnBoard(testCell4, testState);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard, testState);

            Assert.AreEqual(res, false);
        }

        [TestMethod]
        public void Test_DescendingDiagonalWinning()
        {
            TestSetup();

            // x is height, y is width
            testCell1 = new Cell(3, 3);
            testCell2 = new Cell(2, 1);
            testCell3 = new Cell(1, 1);
            testCell4 = new Cell(0, 0);

            testBoard.SetCellOnBoard(testCell1, testState);
            testBoard.SetCellOnBoard(testCell2, testState);
            testBoard.SetCellOnBoard(testCell3, testState);
            testBoard.SetCellOnBoard(testCell4, testState);

            WinCheck testWin = new WinCheck();

            bool res = testWin.SearchWins(testBoard, testState);

            Assert.AreEqual(res, false);
        }
    }
}