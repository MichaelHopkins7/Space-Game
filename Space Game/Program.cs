using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            double startShipMCargoSpace = 6; // Setting ship max cargo capacities
            double shipAMCargo = 8;
            double shipBMCargo = 10;
            double shipCMCargo = 12;

            double shipCargoCurrent = 0; // variable for Cargo in ship now
            double currentShipMCargo = startShipMCargoSpace; //sets cargo capacity to start

            int creditsNow = 100; //creates value for storing currency amount and sets initial currency. Whole credits only.
            int purchasePrice = 0; //sets up value to use for purchases

            int startShipMSpeed = 4; // Setting ship max speeds
            int shipAMSpeed = 6;
            int shipBMSpeed = 7;
            int shipCMSpeed = 9;
            int requestedWF = 0; //requested speed in warp
            double formulaSpeed = 0; //will be used to store speed in lightyears from formula
            
            requestedWF = int.Parse(Console.ReadLine());

            double WarpSpeed(requestedWF, formulaSpeed)
            {
                double warpFactor = requestedWF; 
                formulaSpeed = warpFactor^(10/3.0) + (10 - warpFactor) ^ (-11 / 3.0);
                return formulaSpeed;
            }
        }

        
    }
}
