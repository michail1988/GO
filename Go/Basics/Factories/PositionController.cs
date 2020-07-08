using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Algorithms;
using Go.Basics.Common;
using Go.Basics.Helpers;

namespace Go.Basics.Factories
{
    public static class PositionController
    {
        public static bool MakeMove(PositionContext position, int index)
        {
            Field field = position.GetField(index);
            position.Fields[index].FieldState = position.Move;

            // if the positionContext is the main game context
            // (the move occurs)
            // actualize the game info
            if (position is GameContext)
            {
                (position as GameContext).ActualizeContextAfterMove(index);
            }

            manageChains(position, field);

            position.NextTurn();
            bool isBeating = executeBeating(position);
            

            return isBeating;
        }

        #region Private fields

        private static void manageChains(PositionContext gameContext, Field field)
        {
            bool connected = checkChains(field, gameContext);

            if (connected == false)
            {
                Chain chain = new Chain(field);
                field.ConnectToChain(chain);
                gameContext.Chains.Add(chain);
            }            
        }

        private static bool checkChains(Field field, PositionContext gameContext)
        {
            checkRelation(field, gameContext.GetLeft(field.GetIndex()), gameContext);
            checkRelation(field, gameContext.GetRight(field.GetIndex()), gameContext);
            checkRelation(field, gameContext.GetUpper(field.GetIndex()), gameContext);
            checkRelation(field, gameContext.GetLower(field.GetIndex()), gameContext);

            return field.IsChained;
        }

        private static void checkRelation(Field field, Field neighbour, PositionContext gameContext)
        {
            if (neighbour != null && PositionHelper.AreFriends(field, neighbour))
            {
                connectChains(field, neighbour, gameContext);
            }
        }

        private static void connectChains(Field field, Field neighbour, PositionContext gameContext)
        {
            // it's not already connected
            if (field.Chain == neighbour.Chain)
            {
                return;
            }

            // it's not already chained with another field
            if (field.Chain == null)
            {
                neighbour.Chain.AddPawn(field);
                field.ConnectToChain(neighbour.Chain);
            }
            
            else
            {
                foreach(var p in field.Chain.Pawns) 
                {
                    //NPE on Chain
                    neighbour.Chain.AddPawn(p);
                }

                gameContext.Chains.Remove(field.Chain);
                field.ConnectToChain(neighbour.Chain);
            }
        }

        private static bool executeBeating(PositionContext position)
        {
            checkSurroundingFields(position);

            if (checkBeating(position)) 
            {
                beatStones(position);
                return true;
                //this.RaiseRefreshViewEvent();
            }

            return false;
        }

        private static void checkSurroundingFields(PositionContext position)
        {
            foreach (var chain in position.Chains)
            {
                chain.SurroundingEmptyFields.Clear();

                foreach (var pawn in chain.Pawns)
                {
                    checkIfEmptyAndManageChain(chain, position.GetLeft(pawn.GetIndex()));
                    checkIfEmptyAndManageChain(chain, position.GetRight(pawn.GetIndex()));
                    checkIfEmptyAndManageChain(chain, position.GetLower(pawn.GetIndex()));
                    checkIfEmptyAndManageChain(chain, position.GetUpper(pawn.GetIndex()));
                }
            }
        }

        private static void checkIfEmptyAndManageChain(Chain chain, Field neighbour)
        {
            if (neighbour != null && neighbour.FieldState == States.Empty)
            {
                if (chain.SurroundingEmptyFields.Contains(neighbour.GetIndex()) == false)
                {
                    chain.SurroundingEmptyFields.Add(neighbour.GetIndex());
                }
            }
        }

        private static bool checkBeating(PositionContext position)
        {
            // TODO move is already turned to the next player although checking is performing
            foreach (var c in position.Chains.Where(x => x.Color == position.Move))
            {
                if (c.Beated)
                {
                    return true;
                }
            }

            return false;
        }

        private static void beatStones(PositionContext position)
        {
            foreach (var c in position.Chains)
            {
                if (c.Beated && c.Color == position.Move)
                {
                    foreach (var p in c.Pawns)
                    {
                        scorePoint(position, p);
                        p.FieldState = States.Empty;
                    }

                    c.Pawns.Clear();
                }
            }

            position.Chains.RemoveAll(x => x.Pawns.Count == 0);
        }

        private static void scorePoint(PositionContext position, Field beatedStone)
        {
            if (beatedStone.FieldState == States.Black)
            {
                position.WhitePoints++;
            }

            if (beatedStone.FieldState == States.White)
            {
                position.BlackPoints++;
            }
        }

        #endregion
    }
}
