using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Go.Algorithms;
using Go.Basics.Common;
using System.Collections.ObjectModel;

namespace Go.Basics.Factories
{
    /// <summary>
    /// Creates complete copy of the position.
    /// </summary>
    public static class PositionContextFactory
    {
        public static PositionContext CreatePositionContext(PositionContext context)
        {
            // TODO do it better
            var clonedFields = new ObservableCollection<Field> (context.Fields.Select(field => (Field)field.Clone()));

            var clonedChains = new List<Chain>();

            
            foreach (var c in context.Chains) 
            {
                var numbers = new List<int>();
                c.Pawns.ForEach(x => numbers.Add(x.GetIndex()));
                
                var fieldsToConnect = new List<Field>();
                foreach (var i in numbers)
                {
                    fieldsToConnect.Add(clonedFields[i]);

                }

                var chainClone = new Chain(fieldsToConnect);
                chainClone.SurroundingEmptyFields.AddRange(c.SurroundingEmptyFields);
                foreach (var i in numbers)
                {
                    clonedFields[i].Chain = chainClone;
                }

                clonedChains.Add(chainClone);
            }

            var posContext = new PositionContext(clonedFields, clonedChains, context.Move);
            posContext.WhitePoints = context.WhitePoints;
            posContext.BlackPoints = context.BlackPoints;

            return posContext;
        }
    }
}
