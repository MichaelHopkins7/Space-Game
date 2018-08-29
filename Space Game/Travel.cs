using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Travel
    {
        public double distanceTraveled;
        private int tripYears;
        private int tripweeks;
        private int tripDays;
        private int tripHours;
        
        // [Planet#, (0=X, 1=Y, 2=Name Part 1, 3=Name Part 2, 4=Name Part 3, 5=Gold Price, 6=Iron Price, 7=Selenium Price,
        //      8=Platinum, 9=Titanium, 10=Aluminum, 11=Rhodium, 12=Rhuthenium, 13=Iridium, )

        public double[] MakePlanetList(int numPlanets)
        {
            double[,] planetList = new double [numPlanets, 14];
            int counter = 0;
            planetList[0, 0] = 0;
            planetList[0, 1] = 0;
            planetList[0, 3] = 18;
            planetList[0, 4] = 18;
            planetList[0, 5] = 18;
            planetList[0, 6] = 18;
            planetList[0, 7] = 18;
            planetList[0, 8] = 18;
            planetList[0, 9] = 18;
            planetList[0, 10] = 18;
            planetList[0, 11] = 18;
            planetList[0, 12] = 18;
            planetList[0, 13] = 18;

            return planetList[,];
        }

    }
}
