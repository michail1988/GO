using System;
using Go.Algorithms;
using Go.Basics.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Tests
{
    [TestClass]
    public class PositionHelperTest
    {
        #region strings decoding

        [TestMethod]
        public void ListPositionFirstRowTest()
        {
            Assert.AreEqual(PositionHelper.ListPosition('A', 19), 0);
            Assert.AreEqual(PositionHelper.ListPosition('B', 19), 1);
            Assert.AreEqual(PositionHelper.ListPosition('C', 19), 2);
            Assert.AreEqual(PositionHelper.ListPosition('D', 19), 3);
            Assert.AreEqual(PositionHelper.ListPosition('E', 19), 4);
            Assert.AreEqual(PositionHelper.ListPosition('F', 19), 5);
            Assert.AreEqual(PositionHelper.ListPosition('G', 19), 6);
            Assert.AreEqual(PositionHelper.ListPosition('H', 19), 7);
            Assert.AreEqual(PositionHelper.ListPosition('I', 19), 8);
            Assert.AreEqual(PositionHelper.ListPosition('J', 19), 9);
            Assert.AreEqual(PositionHelper.ListPosition('K', 19), 10);
            Assert.AreEqual(PositionHelper.ListPosition('L', 19), 11);
            Assert.AreEqual(PositionHelper.ListPosition('M', 19), 12);
            Assert.AreEqual(PositionHelper.ListPosition('N', 19), 13);
            Assert.AreEqual(PositionHelper.ListPosition('O', 19), 14);
            Assert.AreEqual(PositionHelper.ListPosition('P', 19), 15);
            Assert.AreEqual(PositionHelper.ListPosition('Q', 19), 16);
            Assert.AreEqual(PositionHelper.ListPosition('R', 19), 17);
            Assert.AreEqual(PositionHelper.ListPosition('S', 19), 18);
        }

        [TestMethod]
        public void ListPositionFirstRowSmallLettersTest()
        {
            Assert.AreEqual(PositionHelper.ListPosition('a', 19), 0);
            Assert.AreEqual(PositionHelper.ListPosition('b', 19), 1);
            Assert.AreEqual(PositionHelper.ListPosition('c', 19), 2);
            Assert.AreEqual(PositionHelper.ListPosition('d', 19), 3);
            Assert.AreEqual(PositionHelper.ListPosition('e', 19), 4);
            Assert.AreEqual(PositionHelper.ListPosition('f', 19), 5);
            Assert.AreEqual(PositionHelper.ListPosition('g', 19), 6);
            Assert.AreEqual(PositionHelper.ListPosition('h', 19), 7);
            Assert.AreEqual(PositionHelper.ListPosition('i', 19), 8);
            Assert.AreEqual(PositionHelper.ListPosition('j', 19), 9);
            Assert.AreEqual(PositionHelper.ListPosition('k', 19), 10);
            Assert.AreEqual(PositionHelper.ListPosition('l', 19), 11);
            Assert.AreEqual(PositionHelper.ListPosition('m', 19), 12);
            Assert.AreEqual(PositionHelper.ListPosition('n', 19), 13);
            Assert.AreEqual(PositionHelper.ListPosition('o', 19), 14);
            Assert.AreEqual(PositionHelper.ListPosition('p', 19), 15);
            Assert.AreEqual(PositionHelper.ListPosition('q', 19), 16);
            Assert.AreEqual(PositionHelper.ListPosition('r', 19), 17);
            Assert.AreEqual(PositionHelper.ListPosition('s', 19), 18);
        }

        [TestMethod]
        public void ListPositionSecondRowTest()
        {
            Assert.AreEqual(PositionHelper.ListPosition('a', 18), 19);
            Assert.AreEqual(PositionHelper.ListPosition('b', 18), 20);
            Assert.AreEqual(PositionHelper.ListPosition('c', 18), 21);
            Assert.AreEqual(PositionHelper.ListPosition('d', 18), 22);
            Assert.AreEqual(PositionHelper.ListPosition('e', 18), 23);
            Assert.AreEqual(PositionHelper.ListPosition('f', 18), 24);
            Assert.AreEqual(PositionHelper.ListPosition('g', 18), 25);
            Assert.AreEqual(PositionHelper.ListPosition('h', 18), 26);
            Assert.AreEqual(PositionHelper.ListPosition('i', 18), 27);
            Assert.AreEqual(PositionHelper.ListPosition('j', 18), 28);
            Assert.AreEqual(PositionHelper.ListPosition('k', 18), 29);
            Assert.AreEqual(PositionHelper.ListPosition('l', 18), 30);
            Assert.AreEqual(PositionHelper.ListPosition('m', 18), 31);
            Assert.AreEqual(PositionHelper.ListPosition('n', 18), 32);
            Assert.AreEqual(PositionHelper.ListPosition('o', 18), 33);
            Assert.AreEqual(PositionHelper.ListPosition('p', 18), 34);
            Assert.AreEqual(PositionHelper.ListPosition('q', 18), 35);
            Assert.AreEqual(PositionHelper.ListPosition('r', 18), 36);
            Assert.AreEqual(PositionHelper.ListPosition('s', 18), 37);
        }

        [TestMethod]
        public void ListPositionLastRowTest()
        {
            Assert.AreEqual(PositionHelper.ListPosition('a', 1), 342);
            Assert.AreEqual(PositionHelper.ListPosition('b', 1), 343);
            Assert.AreEqual(PositionHelper.ListPosition('c', 1), 344);
            Assert.AreEqual(PositionHelper.ListPosition('d', 1), 345);
            Assert.AreEqual(PositionHelper.ListPosition('e', 1), 346);
            Assert.AreEqual(PositionHelper.ListPosition('f', 1), 347);
            Assert.AreEqual(PositionHelper.ListPosition('g', 1), 348);
            Assert.AreEqual(PositionHelper.ListPosition('h', 1), 349);
            Assert.AreEqual(PositionHelper.ListPosition('i', 1), 350);
            Assert.AreEqual(PositionHelper.ListPosition('j', 1), 351);
            Assert.AreEqual(PositionHelper.ListPosition('k', 1), 352);
            Assert.AreEqual(PositionHelper.ListPosition('l', 1), 353);
            Assert.AreEqual(PositionHelper.ListPosition('m', 1), 354);
            Assert.AreEqual(PositionHelper.ListPosition('n', 1), 355);
            Assert.AreEqual(PositionHelper.ListPosition('o', 1), 356);
            Assert.AreEqual(PositionHelper.ListPosition('p', 1), 357);
            Assert.AreEqual(PositionHelper.ListPosition('q', 1), 358);
            Assert.AreEqual(PositionHelper.ListPosition('r', 1), 359);
            Assert.AreEqual(PositionHelper.ListPosition('s', 1), 360);
        }

        [TestMethod]
        public void EncodeStringPositionTest1()
        {
            String position = "wb";

            var gameContext = new GameContext(position);
            var resultString = PositionHelper.EncodeStringPosition(gameContext);

            Assert.AreEqual(position, resultString);
        }

        [TestMethod]
        public void EncodeStringPositionTest2()
        {
            String position = "w1b2w1b1w3bb5wb";

            var gameContext = new GameContext(position);
            var resultString = PositionHelper.EncodeStringPosition(gameContext);

            Assert.AreEqual(position, resultString);
        }

        [TestMethod]
        public void EncodeStringPositionTest3()
        {
            String position = "w1b20w1b1w3bb5wb";

            var gameContext = new GameContext(position);
            var resultString = PositionHelper.EncodeStringPosition(gameContext);

            Assert.AreEqual(position, resultString);
        }

        [TestMethod]
        public void EncodeStringPositionTest4()
        {
            String position = "";

            var gameContext = new GameContext(position);
            var resultString = PositionHelper.EncodeStringPosition(gameContext);

            Assert.AreEqual(position, resultString);
        }

        [TestMethod]
        public void EncodeStringPositionTest5()
        {
            String position = "26";

            var gameContext = new GameContext(position);
            var resultString = PositionHelper.EncodeStringPosition(gameContext);

            Assert.AreEqual(position, resultString);
        }

        // Depends of the context behaviour
        [TestMethod]
        public void EncodeStringPositionTest6()
        {
            String position = null;

            var gameContext = new GameContext(position);
            var resultString = PositionHelper.EncodeStringPosition(gameContext);

            Assert.AreEqual("361", resultString);
        }

        #endregion

        #region Encoding list index to square coordinates

        [TestMethod]
        public void A19Test()
        {
            Assert.AreEqual("A19", PositionHelper.MoveDescription(0));
        }

        [TestMethod]
        public void B19Test()
        {
            Assert.AreEqual("B19", PositionHelper.MoveDescription(1));
        }

        [TestMethod]
        public void C19Test()
        {
            Assert.AreEqual("C19", PositionHelper.MoveDescription(2));
        }

        [TestMethod]
        public void D19Test()
        {
            Assert.AreEqual("D19", PositionHelper.MoveDescription(3));
        }

        [TestMethod]
        public void A18Test()
        {
            Assert.AreEqual("A18", PositionHelper.MoveDescription(19));
        }

        [TestMethod]
        public void B18Test()
        {
            Assert.AreEqual("B18", PositionHelper.MoveDescription(20));
        }

        #endregion
    }
}
