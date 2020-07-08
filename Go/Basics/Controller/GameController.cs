using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;
using Go.Algorithms;
using Go.Basics.Common;
using Go.Basics.Factories;
using Go.Basics.Helpers;
using Go.Infrastructure.Events;
using Go.Infrastructure.Log;
using Go.Infrastructure.Settings;
using Go.Log;

namespace Go.Basics
{
    /// <summary>
    /// The main application controller.
    /// Serves all the events and realizes through PositionController moves.
    /// </summary>
    public class GameController
    {
        #region Fields

        public GameContext gameContext;

        private IAlgorithm algorithm;

        #endregion

        #region Constructors

        public GameController(GameContext gameContext)
        {
            this.gameContext = gameContext;
            setAlgorithm(gameContext);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Indicates who has the turn.
        /// </summary>
        public States Move
        {
            get
            {
                return this.GameContext.Move;
            }
        }

        /// <summary>
        /// Gets game context.
        /// </summary>
        public GameContext GameContext
        {
            get
            {
                return this.gameContext;
            }

            set
            {
                this.gameContext = value;
                // TODO refresh by property/ another places!
                setAlgorithm(gameContext);
                this.RaiseNewGameEvent();
            }
        }

        #endregion

        #region Methods

        public void MakeMove(int index)
        {
            // TODO Validation
            // if the pawn is placed on the deadly square

            if (ValidationHelper.IsValid(this.GameContext, index) == false)
            {
                // never occurs TODO
                return;
            }
            
            PositionController.MakeMove(this.GameContext, index);            

            // TODO delays game
            this.RaiseRefreshViewEvent();

            // TODO Temporarily so
            if (Settings.PlayingWithComputer)
            {
                this.makeComputerMove();
            }            
        }

        private void makeComputerMove()
        {
            MoveCandidate moveCandidate = this.algorithm.Play();

            MoveInfo logInfo = new MoveInfo(moveCandidate.FieldToMove, moveCandidate.Evaluation);
            this.gameContext.Info = logInfo;


            // TODO Validation
            // if the pawn is placed on the deadly square

            if (ValidationHelper.IsValid(this.GameContext, moveCandidate.FieldToMove) == false)
            {
                // never occurs TODO
                return;
            }

            PositionController.MakeMove(this.GameContext, moveCandidate.FieldToMove);


            // TODO delays game
            this.RaiseRefreshViewEvent();
        }

        private void setAlgorithm(GameContext gameContext)
        {
            switch (Settings.Algorithm)
            {
                case AlgorithmEnum.MinMax:
                    this.algorithm = new BeatingAlgorithm(gameContext);
                    break;
                case AlgorithmEnum.Random:
                    this.algorithm = new RandomAlgorithm(gameContext);
                    break;
                case AlgorithmEnum.SimpleBeating:
                    this.algorithm = new SimpleBeatingAlgorithm(gameContext);
                    break;
                default:
                    // TODO Exception
                    break;
            }
        }

        #endregion

        #region Events

        public delegate void RefreshDelegate(object oSender, PositionChangedArgs oEventArgs);

        public event RefreshDelegate RefreshViewEvent;

        private void RaiseRefreshViewEvent()
        {
            if (null != this.RefreshViewEvent)
            {
                this.RefreshViewEvent(this, new PositionChangedArgs());
            }
        }

        public delegate void NewGameDelegate(object sender, PositionChangedArgs args);

        public event NewGameDelegate NewGameEvent;

        private void RaiseNewGameEvent()
        {
            if (this.NewGameEvent != null)
            {
                this.NewGameEvent(this, new PositionChangedArgs());
            }
        }

        #endregion
    }
}
