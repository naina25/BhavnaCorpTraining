using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturing
{
    public interface Icar
    {
        public void repairingCost(int cost);
        public int ManpowerCostCal(int manpowerCostPerPart);
    }
}
