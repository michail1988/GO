using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Basics;
using Go.Infrastructure.App;

namespace Go.Algorithms.Rules
{
    public static class GameFactory
    {
        public static void NewGame()
        {
            AppManager.GameController.GameContext = CreateGameContext();
        }

        public static GameController CreateGameController(String position = null)
        {
            var context = CreateGameContext(position);
            return new GameController(context);
        }

        public static GameContext CreateGameContext(String position = null)
        {
            var context = new GameContext(position);

            return context;
        }
    }
}
