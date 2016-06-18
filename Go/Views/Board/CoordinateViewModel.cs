using Go.Infrastructure.Settings;
using Go.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Go.Views.Board
{
    public class CoordinateViewModel : BaseViewModel
    {
        public CoordinateViewModel(String description)
        {
            this.Description = description;
        }

        public String Description { get; private set; }

        public int FieldSize
        {
            get
            {
                if (Settings.BoardSize == BoardSizes.Board_19_19)
                {
                    return 40;
                }

                if (Settings.BoardSize == BoardSizes.Board_10_10)
                {
                    return 75;
                }

                return 40;
            }
        }
    }
}
