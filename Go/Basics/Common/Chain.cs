using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Go.Algorithm.Rules;

namespace Go.Basics.Common
{
    public class Chain : ICloneable
    {
        public Chain(Field field)
        {
            Pawns = new List<Field>();
            Color = field.FieldState;
            AddPawn(field);

            this.SurroundingEmptyFields = new List<int>();
        }

        public Chain(List<Field> fields)
        {
            Pawns = fields;
            Color = fields.First().FieldState;

            this.SurroundingEmptyFields = new List<int>();
        }

        /// <summary>
        /// Holds all connected pawns.
        /// </summary>
        public List<Field> Pawns;

        public States Color;

        // TODO delete
        private bool temporary;
        
        public bool Beated
        {
            get
            {
                return this.SurroundingEmptyFields.Count == 0;
            }
        }

        /// <summary>
        /// Holds all numbers of the empty
        /// fields around the chain.
        /// </summary>
        public List<int> SurroundingEmptyFields;

        public void AddPawn(Field field)
        {
            Pawns.Add(field);
        }

        public int Count
        {
            get
            {
                return Pawns.Count;
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
