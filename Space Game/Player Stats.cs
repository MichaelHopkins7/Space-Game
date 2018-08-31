using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Player_Stats
    {
        private int money; //for playercash
        private int years; //for total travel time
        private int weeks;
        private int days;
        private int hours;
        private double distance; //how far you've come

        public Player_Stats(int money, int years, int weeks, int days, int hours, int distance)
        {
            this.money = money;
            this.years = years;
            this.weeks = weeks;
            this.days = days;
            this.hours = hours;
            this.distance = distance;
        }

        public int SMoney()
        {
            return money;
        }
        
        public int SYears()
        {
            return years;
        }

        public void ChangeMoney(int change)
        {
            money += (change);
        }

        public void Status(Travel myUniverse, Ship myShip)
        {
            Console.WriteLine($"You are on {myUniverse.GetPlanetName()}.");
            Console.WriteLine("You have been traveling for:");
            Console.WriteLine($"Years:{years}");
            Console.WriteLine($"Weeks:{weeks}");
            Console.WriteLine($"Days:{days}");
            Console.WriteLine($"Hours:{hours}/n");

            Console.WriteLine($"You traveled {distance} lightyears!/n");

            Console.WriteLine($"You have {money} credits./n");
            Console.WriteLine($"Your ship has {myShip.Fuel()} fuel in a fule container that can hold {myShip.FuelTank()} units of fuel.");
            Console.WriteLine($"It hase a max speed of warp {myShip.Speed()}.");
            Console.WriteLine($"And it has {myShip.CargoSlots()} slots of cargo space that hold {myShip.SlotSize()} units of cargo./n");
            Console.WriteLine("Inside of which is:");
            Utility.ShowCargoInv(myShip);
        }

        public void addTime(int tripYears, int tripWeeks, int tripDays, int tripHours) //adding trip to total time
        {
            bool isGood = false;
            years += tripYears;
            weeks += tripWeeks;
            days += tripDays;
            hours += tripHours;

            do // calculates adjustments to values due to totals crossing threshhold to next value and checks 40Year end.
            {
                isGood = false;
                if (weeks >= 53)
                {
                    weeks -= 53;
                    ++years;
                    days += 6;
                }
                else if (days >= 7)
                {
                    days -= 7;
                    ++weeks;
                }
                else if (hours > 24)
                {
                    hours -= 24;
                    ++days;
                }
                else
                {
                    isGood = true;
                }
            }
            while (!isGood);
        }
    }
}
