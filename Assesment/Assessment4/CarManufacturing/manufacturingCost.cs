using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturing
{
    public class manufacturingCost:Icar
    {
        public int totalPartsCost;
        public int totalManpowerCost;
        public int totalManufactureCost;

        public int ManpowerCostCal(int manpowerCostPerPart)
        {
            return (totalManpowerCost + manpowerCostPerPart);
        }

        //interface implementation
        public void repairingCost(int cost)
        {
            Console.WriteLine("Total cost of car repairing would be: " + cost);
        }
    }
}
