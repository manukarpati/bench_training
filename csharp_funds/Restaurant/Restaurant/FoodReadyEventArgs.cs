using System;
using System.Collections.Generic;
using System.Text;

namespace Epam.Mep.Restaurant
{
    public class FoodReadyEventArgs : EventArgs
    {
        public IFood Food { get; set; }
    }
}
