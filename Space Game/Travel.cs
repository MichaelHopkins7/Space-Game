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
        
        // [Planet#, (0=X, 1=Y, 2=Name Part 1, 3=Name Part 2, 4=Name Part 3, 5=0 for pricing 6=Gold Price, 7=Iron Price, 8=Selenium Price,
        //      9=Platinum, 10=Titanium, 11=Aluminum, 12=Rhodium, 13=Rhuthenium, 14=Iridium, )

        public static double[,] MakePlanetList(int numPlanets)
        {
            Random rnd = new Random();
            Random rndDouble = new Random();
            double[,] planetList = new double[numPlanets, 15];
            planetList[0, 0] = 0;
            planetList[0, 1] = 0;
            planetList[0, 2] = 18;
            planetList[0, 3] = 18;
            planetList[0, 4] = 18;
            planetList[0, 5] = 0;
            planetList[0, 6] = 9;
            planetList[0, 7] = 1;
            planetList[0, 8] = 6;
            planetList[0, 9] = 10;
            planetList[0, 10] = 5;
            planetList[0, 11] = 2;
            planetList[0, 12] = 12;
            planetList[0, 13] = 8;
            planetList[0, 14] = 7;
            for (int counter =1; counter < numPlanets; counter++)
            {
                planetList[counter, 0] = Math.Round(rndDouble.NextDouble(), 1) + rnd.Next(-50, 50);
                planetList[counter, 1] = Math.Round(rndDouble.NextDouble(), 1) + rnd.Next(-50, 50);
                planetList[counter, 2] = rnd.Next(1, 25);
                planetList[counter, 3] = rnd.Next(1, 25);
                planetList[counter, 4] = rnd.Next(1, 25);
                planetList[counter, 5] = 0;
                planetList[counter, 6] = rnd.Next(3,15);
                planetList[counter, 7] = rnd.Next(3, 15);
                planetList[counter, 8] = rnd.Next(3, 15);
                planetList[counter, 9] = rnd.Next(3, 15);
                planetList[counter, 10] = rnd.Next(3, 15);
                planetList[counter, 11] = rnd.Next(3, 15);
                planetList[counter, 12] = rnd.Next(3, 15);
                planetList[counter, 13] = rnd.Next(3, 15);
                planetList[counter, 14] = rnd.Next(3, 15);
            }
            return planetList[,];
        }

    }
}
