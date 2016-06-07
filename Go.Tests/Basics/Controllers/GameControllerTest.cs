using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithms.Rules;
using Go.Basics.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Go.Tests.Basics.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        #region beating

        // TODO place method in special class
        /// <summary>
        /// w . . .
        /// . . . .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            Assert.AreEqual(false, PositionController.MakeMove(context, 0));
        }

        /// <summary>
        /// w b .
        /// b . .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest2()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            PositionController.MakeMove(context, 0);
            PositionController.MakeMove(context, 1);
            PositionController.MakeMove(context, 100);

            Assert.AreEqual(true, PositionController.MakeMove(context, 19));
        }

        /// <summary>
        /// b w .
        /// b . .
        /// . . .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest3()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            PositionController.MakeMove(context, 1);
            PositionController.MakeMove(context, 0);
            PositionController.MakeMove(context, 100);
            PositionController.MakeMove(context, 19);

            Assert.AreEqual(false, PositionController.MakeMove(context, 101));
        }

        /// <summary>
        /// b w .
        /// b b .
        /// . . .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest4()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            PositionController.MakeMove(context, 1);
            PositionController.MakeMove(context, 0);
            PositionController.MakeMove(context, 100);
            PositionController.MakeMove(context, 19);
            PositionController.MakeMove(context, 101);

            Assert.AreEqual(false, PositionController.MakeMove(context, 20));
        }

        /// <summary>
        /// b w b
        /// b b .
        /// . . .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest5()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            PositionController.MakeMove(context, 1);
            PositionController.MakeMove(context, 0);
            PositionController.MakeMove(context, 100);
            PositionController.MakeMove(context, 19);
            PositionController.MakeMove(context, 101);
            PositionController.MakeMove(context, 20);
            PositionController.MakeMove(context, 105);

            Assert.AreEqual(true, PositionController.MakeMove(context, 2));
        }

        /// <summary>
        /// . w b .
        /// b b w .
        /// . . b .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest6()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            PositionController.MakeMove(context, 1);
            PositionController.MakeMove(context, 2);
            PositionController.MakeMove(context, 21);
            PositionController.MakeMove(context, 19);
            PositionController.MakeMove(context, 101);
            PositionController.MakeMove(context, 20);
            PositionController.MakeMove(context, 105);

            Assert.AreEqual(false, PositionController.MakeMove(context, 40));
        }

        /// <summary>
        /// . w b .
        /// b b w b
        /// . . b .
        /// </summary>
        [TestMethod]
        public void PerformBeatingCheckTest7()
        {
            var controller = GameFactory.CreateGameController();
            var context = controller.GameContext;

            PositionController.MakeMove(context, 1);
            PositionController.MakeMove(context, 2);
            PositionController.MakeMove(context, 21);
            PositionController.MakeMove(context, 19);
            PositionController.MakeMove(context, 101);
            PositionController.MakeMove(context, 20);
            PositionController.MakeMove(context, 105);
            PositionController.MakeMove(context, 40);
            PositionController.MakeMove(context, 140);

            Assert.AreEqual(true, PositionController.MakeMove(context, 22));
        }

        #endregion
    }
}
