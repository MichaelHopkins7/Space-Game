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
        private int tripWeeks;
        private int tripDays;
        private int tripHours;
        private double[,] Universe;
        private int numberOfPlanets;
        public int planetNum;

        // [Planet#, (0=X, 1=Y, 2=Name Part 1, 3=Name Part 2, 4=Name Part 3, 5=0 for pricing 6=Gold Price, 7=Iron Price, 8=Selenium Price,
        //      9=Platinum, 10=Titanium, 11=Aluminum, 12=Rhodium, 13=Rhuthenium, 14=Iridium, )
        
        public Travel(int numPlanets, int years, int weeks, int days, int hours, int startingPlanet) //your universe and trips
        {
            this.distanceTraveled = 0; //sets up trip variables
            this.tripYears = years;
            this.tripWeeks = weeks;
            this.tripDays = days;
            this.tripHours = hours;
            this.numberOfPlanets = numPlanets; //lets this keep track of how many planets you made
            this.Universe = BigBang(numPlanets); // makes the universe
            this.planetNum = startingPlanet; //notes where you started/are, may make starting away from earth a thing in the future
        }

        public void ShowPlanetName(int planetNum) //displays a planet's name
        {
            Console.WriteLine($"{Universe[planetNum, 2]}{Universe[planetNum, 3]}{Universe[planetNum, 4]}");
        }

        public void WhereCanMove(int planetNum, int fuel, double[] Universe) //finds out where you can go and shows it
        {
            for (int counter = 0; counter < numberOfPlanets; counter++)
            {
                
            }
        }

        private double distance(int planetNum, int destPlanet, double[,] Universe)
        {
            double between = 0;
            double atX = Universe[planetNum, 0]; //starting point X
            double atY = Universe[planetNum, 1]; //starting point Y
            double thereX = Universe[destPlanet, 0]; //going to X
            double thereY = Universe[destPlanet, 1]; //going to X

            return between;
        }

        private double[,] BigBang(int numPlanets) //creates Earth and the specified number of planets randomly
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
            return planetList;
        }
        
        public string GetPlanetName(int planetNum, double[,] planetList)
        {
            string seg1 = "";
            string seg2 = "";
            string seg3 = "";
            switch (planetList[planetNum, 2])
            {
                case 1:
                    seg1 = "Mac";
                    break;
                case 2:
                    seg1 = "Try";
                    break;
                case 3:
                    seg1 = "Sel";
                    break;
                case 4:
                    seg1 = "Dar";
                    break;
                case 5:
                    seg1 = "Kel";
                    break;
                case 6:
                    seg1 = "Dre";
                    break;
                case 7:
                    seg1 = "Nak";
                    break;
                case 8:
                    seg1 = "Rol";
                    break;
                case 9:
                    seg1 = "Van";
                    break;
                case 10:
                    seg1 = "Sa";
                    break;
                case 11:
                    seg1 = "To";
                    break;
                case 12:
                    seg1 = "Fra";
                    break;
                case 13:
                    seg1 = "Gel";
                    break;
                case 14:
                    seg1 = "Ja";
                    break;
                case 15:
                    seg1 = "Ae";
                    break;
                case 16:
                    seg1 = "Quo";
                    break;
                case 17:
                    seg1 = "Pra";
                    break;
                case 18:
                    seg1 = "Ea";
                    break;
                case 19:
                    seg1 = "Ti";
                    break;
                case 20:
                    seg1 = "Ju";
                    break;
                case 21:
                    seg1 = "Sat";
                    break;
                case 22:
                    seg1 = "Ns";
                    break;
                case 23:
                    seg1 = "Ero";
                    break;
                case 24:
                    seg1 = "All";
                    break;
                case 25:
                    seg1 = "Isn";
                    break;
            }
            switch (planetList[planetNum, 3])
            {
                case 1:
                    seg2 = "gol";
                    break;
                case 2:
                    seg2 = "nan";
                    break;
                case 3:
                    seg2 = "mar";
                    break;
                case 4:
                    seg2 = "lel";
                    break;
                case 5:
                    seg2 = "den";
                    break;
                case 6:
                    seg2 = "sal";
                    break;
                case 7:
                    seg2 = "sid";
                    break;
                case 8:
                    seg2 = "jyr";
                    break;
                case 9:
                    seg2 = "red";
                    break;
                case 10:
                    seg2 = "no";
                    break;
                case 11:
                    seg2 = "ke";
                    break;
                case 12:
                    seg2 = "woe";
                    break;
                case 13:
                    seg2 = "bon";
                    break;
                case 14:
                    seg2 = "pre";
                    break;
                case 15:
                    seg2 = "oni";
                    break;
                case 16:
                    seg2 = "zio";
                    break;
                case 17:
                    seg2 = "vem";
                    break;
                case 18:
                    seg2 = "rt";
                    break;
                case 19:
                    seg2 = "ta";
                    break;
                case 20:
                    seg2 = "pi";
                    break;
                case 21:
                    seg2 = "urn";
                    break;
                case 22:
                    seg2 = "are";
                    break;
                case 23:
                    seg2 = "san";
                    break;
                case 24:
                    seg2 = "plu";
                    break;
                case 25:
                    seg2 = "tap";
                    break;
            }
            switch (planetList[planetNum, 4])
            {
                case 1:
                    seg3 = "sar";
                    break;
                case 2:
                    seg3 = "key";
                    break;
                case 3:
                    seg3 = "gre";
                    break;
                case 4:
                    seg3 = "neh";
                    break;
                case 5:
                    seg3 = "rak";
                    break;
                case 6:
                    seg3 = "ren";
                    break;
                case 7:
                    seg3 = "try";
                    break;
                case 8:
                    seg3 = "del";
                    break;
                case 9:
                    seg3 = "lev";
                    break;
                case 10:
                    seg3 = "ry";
                    break;
                case 11:
                    seg3 = "diee";
                    break;
                case 12:
                    seg3 = "que";
                    break;
                case 13:
                    seg3 = "xie";
                    break;
                case 14:
                    seg3 = "de";
                    break;
                case 15:
                    seg3 = "c";
                    break;
                case 16:
                    seg3 = "poc";
                    break;
                case 17:
                    seg3 = "za";
                    break;
                case 18:
                    seg3 = "h";
                    break;
                case 19:
                    seg3 = "n";
                    break;
                case 20:
                    seg3 = "ter";
                    break;
                case 21:
                    seg3 = "moo";
                    break;
                case 22:
                    seg3 = "num";
                    break;
                case 23:
                    seg3 = "dsm";
                    break;
                case 24:
                    seg3 = "to";
                    break;
                case 25:
                    seg3 = "lan";
                    break;
            }
            return seg1 + seg2 + seg3;
        }
    }
}
