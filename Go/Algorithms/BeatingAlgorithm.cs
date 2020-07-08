using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Go.Infrastructure.Core;

using Go.Algorithm.Rules;
using Go.Basics.Common;
using Go.Infrastructure.Settings;
using Go.Basics.Factories;
using Go.Basics.Helpers;
using Go.Log;

namespace Go.Algorithms
{
    public class BeatingAlgorithm : Algorithm
    {
        #region Fields

        private Random random;

        private int computedVariation;

        #endregion

        #region Constructors

        public BeatingAlgorithm(GameContext context)
            : base(context)
        {
            this.random = new Random();
        }

        #endregion

        #region Methods

        public override MoveCandidate Play()
        {
            States move = this.gameContext.Move;

            List<int> candidates = FindCandidates(this.gameContext);

            ConsoleLogger.Log("------------------------------------------------------");
            computedVariation = 0;
            List<MoveCandidate> moveCandidates = new List<MoveCandidate>();
            foreach (int i in candidates)
            {
                moveCandidates.Add(analyze(0, i, this.gameContext));
                /*
                PositionContext posContext = PositionContextFactory.CreatePositionContext(this.gameContext);
                PositionController.MakeMove(posContext, i);
 
                // keeping posContext everywhere is too much
                // perhaps string-representation is better (position context creation cost?)
                MoveCandidate candidate = new MoveCandidate(i, posContext);
                candidate.Evaluation = evaluate(posContext);

                moveCandidates.Add(candidate);
                 * */
            }

            var bestCandidate = getBest(moveCandidates, move);
            ConsoleLogger.Log("Wybrano: " + bestCandidate.FieldToMove + " Ocena " + bestCandidate.Evaluation);
            ConsoleLogger.Log("Przeliczono: " + computedVariation);

            return bestCandidate;
        }

        private MoveCandidate analyze(int depth, int field, PositionContext position)
        {
            ConsoleLogger.LogDepth(depth);
            ConsoleLogger.LogMove(position);
            if (depth == Settings.MaxDepth)
            {
                MoveCandidate candidate = new MoveCandidate(field, position);
                PositionController.MakeMove(position, field);
                candidate.Evaluation = evaluate(position);
                ConsoleLogger.Log(candidate.Evaluation.ToString());
                computedVariation++;
                return candidate;
            }

            States move = position.Move;

            List<int> candidates = FindCandidates(position);
            if (candidates.Count == 0)
            {
                ConsoleLogger.Log("! nie znaleziono ruchow kandydatow!");
            }

            ConsoleLogger.Log("Ilość kandydatów: " + candidates.Count);

            List<MoveCandidate> moveCandidates = new List<MoveCandidate>();
            foreach (var i in candidates)
            {
                PositionContext newPosition = PositionContextFactory.CreatePositionContext(position);
                PositionController.MakeMove(newPosition, i);
                MoveCandidate candidate = analyze(depth + 1, i, newPosition);
                moveCandidates.Add(candidate);
            }

            var bestCandidate = getBest(moveCandidates, move);
            ConsoleLogger.Log("Z " + candidates.Count + " wariantow wybrano: " + bestCandidate.Evaluation.ToString());
            return bestCandidate;
        }

        /// <summary>
        /// </summary>
        /// <param name="positionContext"></param>
        /// <returns></returns>
        private List<int> FindCandidates(PositionContext positionContext)
        {
            List<int> candidates = new List<int> ();

            List<Chain> chainsToBeat = new List<Chain>();

            int biggestSizeToBeat = 0;
            Chain biggestToBeat = null;
            // find chain to beat
            foreach (var chain in positionContext.Chains.Where(x => x.Color != positionContext.Move && !x.Beated))
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

            /*
            // TODO defence by beating
            if (biggestSizeToBeat > 0 && biggestSizeToBeat >= biggestLost)
            {
                //return biggestToBeat.SurroundingEmptyFields.First();
            }
            else
            {
                if (biggestLost > 0)
                {
                    //return biggestChainToLost.SurroundingEmptyFields.First();
                }

            }

            // TODO assert is not deadly move
            if (biggestLost > 0)
            {
                // TODO has surrounding empty spaces/ could be connected to another chain without self-killing
                //this.gameContext.GetField(biggestChainToLost.SurroundingEmptyFields.First()).
                //return biggestChainToLost.SurroundingEmptyFields.First();
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

            // todo
            if (biggestSizeToSurround > 0)
            {
                return biggest.SurroundingEmptyFields.First();
            }

            int dimension = (int)Settings.BoardSize;
            // TODO
            // very, very stupid clause
            while (true)
            {
                int fieldIndex = this.randomNumber(0, dimension * dimension - 1);

                if (positionContext.GetField(fieldIndex).FieldState.Equals(States.Empty))
                {
                    return fieldIndex;
                }
            }
             * * */

            if (chainsToBeat.Count > 0)
            {
                chainsToBeat.OrderByDescending(x => x.Count);
            }

            if (chainsToDefend.Count > 0)
            {
                chainsToDefend.OrderByDescending(x => x.Count);
            }

            candidates.AddRange(chainsToBeat.Select(x=>x.SurroundingEmptyFields.First()));
            candidates.AddRange(chainsToDefend.Select(x => x.SurroundingEmptyFields.First()));

            if (candidates.Count == 0)
            {
                // find biggest chain and try to 
                Chain biggest = AlgorithmHelper.GetBiggestUnbeatenChain(positionContext);

                if (biggest != null)
                {
                    candidates.AddRange(biggest.SurroundingEmptyFields);
                }
            }

            if (candidates.Count == 0)
            {
                //TODO Michal to jest blad petli powyzej~!

            }

                return candidates;
        }

        

        #endregion

        #region Private methods

        private int randomNumber(int min, int max)
        {
            return this.random.Next(min, max);
        }

        private MoveCandidate getBest(List<MoveCandidate> candidates, States move)
        {
            double bestEval;
            if (move.Equals(States.White))
            {
                bestEval = candidates.Max(x => x.Evaluation);
            }
            else
            {
                bestEval = candidates.Min(x => x.Evaluation);
            }

            return candidates.Where(x => x.Evaluation == bestEval).First();
        }

        /// <summary>
        /// Gets the current position evaluation.
        /// </summary>
        /// <returns>The position computer's evaluation.</returns>
        private double evaluate(PositionContext posContext)
        {
            return posContext.WhitePoints - posContext.BlackPoints;
        }

        #endregion
    }
}
