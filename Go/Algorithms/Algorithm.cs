using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Algorithms
{
    abstract public class Algorithm : IAlgorithm
    {
        #region Fields

        protected GameContext gameContext;

        #endregion

        #region Constructors

        public Algorithm(GameContext context)
        {
            this.gameContext = context;
        }

        #endregion

        #region Methods

        public abstract int Play();

        #endregion
    }
}
