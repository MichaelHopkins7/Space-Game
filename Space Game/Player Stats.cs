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
        


        public void Status()
        {
            Console.WriteLine("You have been traveling for:");
            Console.WriteLine($"Years:{years}");
            Console.WriteLine($"Weeks:{weeks}");
            Console.WriteLine($"Days:{days}");
            Console.WriteLine($"Hours:{hours}");

            Console.WriteLine($"You traveled {distance} lightyears!");

            Console.WriteLine($"You have {money} credits.");
        }

    }
}
