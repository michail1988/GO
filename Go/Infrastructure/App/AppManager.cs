using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithms.Rules;
using Go.Basics;

namespace Go.Infrastructure.App
{
    public static class AppManager
    {
        static AppManager()
        {
            GameController = GameFactory.CreateGameController();
        }

        public static GameController GameController;
    }
}
