using System;
using Go.Log;
using Go.Basics.Helpers;

namespace Go.Log
{
	public class LogFormatter
	{
		public LogFormatter()
		{
		}


		#region Methods

	public string Log(MoveInfo logInfo)
	{
		if (logInfo != null) 
		{
				if (logInfo.Text != null)
				{
					return logInfo.Text;
				}

				String log = PositionHelper.MoveDescription(logInfo.MoveIndex);

				if (logInfo.Evaluation != null)
				{
					log += " Ocena=" + logInfo.Evaluation;
				}

				return log;
		}

			return "";
	}

    #endregion
	}

	
}
