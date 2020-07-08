using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Basics.Common;
using Go.Infrastructure.Settings;

namespace Go.Algorithms
{
    public class SimpleBeatingAlgorithm : Algorithm
    {
        #region Fields

        private Random random;

        private int computedVariation;

        #endregion

        #region Constructors

        public SimpleBeatingAlgorithm(GameContext context)
            : base(context)
        {
            this.random = new Random();
        }

        #endregion

        #region Methods

        public override MoveCandidate Play()
        {
            return FindCandidate(this.gameContext);
        }

        /// <summary>
        /// </summary>
        /// <param name="positionContext"></param>
        /// <returns></returns>
        private MoveCandidate FindCandidate(PositionContext positionContext)
        {
            List<int> candidates = new List<int> ();

            List<Chain> chainsToBeat = new List<Chain>();

            int biggestSizeToBeat = 0;
            Chain biggestToBeat = null;
            // find chain to beat
            foreach (var chain in positionContext.Chains.Where(x => x.Color != positionContext.Move))
            {
                if (chain.SurroundingEmptyFields.Count == 1)
                {
                    chainsToBeat.Add(chain);
                    if (chain.Count > biggestSizeToBeat)
                    {
                        biggestSizeToBeat = chain.Count;
                        biggestToBeat = chain;
                    }
                }
            }

            // try to defend
            List<Chain> chainsToDefend = new List<Chain>();
            
            int biggestLost = 0;
            Chain biggestChainToLost = null;
            foreach (var chain in positionContext.Chains.Where(x => x.Color == positionContext.Move))
            {
                if (chain.SurroundingEmptyFields.Count == 1)
                {
                    chainsToDefend.Add(chain);
                    if (chain.Count > biggestLost)
                    {
                        biggestLost = chain.Count;
                        biggestChainToLost = chain;
                    }
                }
            }

            
            // TODO defence by beating
            if (biggestSizeToBeat > 0 && biggestSizeToBeat >= biggestLost)
            {
                return new MoveCandidate(biggestToBeat.SurroundingEmptyFields.First());
            }
            else
            {
                if (biggestLost > 0)
                {
                    return new MoveCandidate(biggestChainToLost.SurroundingEmptyFields.First());
                }

            }

            // TODO assert is not deadly move
            if (biggestLost > 0)
            {
                // TODO has surrounding empty spaces/ could be connected to another chain without self-killing
                //this.gameContext.GetField(biggestChainToLost.SurroundingEmptyFields.First()).
                return new MoveCandidate(biggestChainToLost.SurroundingEmptyFields.First());
            }
             

            // find biggest chain and try to surround
            int biggestSizeToSurround = 0;
            Chain biggest = null;
            foreach (var chain in positionContext.Chains.Where(x => x.Color != positionContext.Move))
            {
                if (chain.Count > biggestSizeToSurround)
                {
                    biggestSizeToSurround = chain.Count;
                    biggest = chain;
                }
            }

            // TODO
            if (biggestSizeToSurround > 0)
            {
                return new MoveCandidate(biggest.SurroundingEmptyFields.First());
            }

            int dimension = (int)Settings.BoardSize;
            // TODO
            // very, very stupid clause
            while (true)
            {
                int fieldIndex = this.randomNumber(0, dimension * dimension - 1);

                if (positionContext.GetField(fieldIndex).FieldState.Equals(States.Empty))
                {
                    return new MoveCandidate(fieldIndex);
                }
            }

            // TODO
            return new MoveCandidate(4);
        }

        #endregion

        #region Private methods

        private int randomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }

        #endregion
    }
}
