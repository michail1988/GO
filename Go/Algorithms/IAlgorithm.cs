using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Go.Basics.Common;

namespace Go.Algorithms
{
    public interface IAlgorithm
    {
        /// <summary>
        /// Returns the field's number to put the stone.
        /// </summary>
        /// <returns>The number of a field.</returns>
        MoveCandidate Play();
    }
}
