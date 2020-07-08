using System;
using Go.Helpers;

//TODO Michal Go.Infrastructure.Log
namespace Go.Log
{
    //TODO Michal to jest MoveInfo
	public class MoveInfo : NotificationObject
	{
        #region Fields

        private String text;

        //TODO Michal czy to nie powinien byc float?
        private double? evaluation;

        private int moveIndex;

        #endregion

        #region Ctor
        public MoveInfo(String text)
		{
            this.text = text;
		}

        public MoveInfo(String text, double evaluation)
        {
            this.text = text;
            this.evaluation = evaluation;
        }

        public MoveInfo(int moveIndex, double evaluation)
        {
            this.moveIndex = moveIndex;
            this.evaluation = evaluation;
        }

        #endregion

        #region Properties

        public String Text
        {
            get
            {
                return this.text;
            }
        }

        public double? Evaluation
        {
            get
            {
                return this.evaluation;
            }
        }

        public int MoveIndex
        {
            get
            {
                return this.moveIndex;
            }
        }

        #endregion
    }
}
