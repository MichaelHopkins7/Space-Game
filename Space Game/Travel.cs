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
        public int years;
        public int weeks;
        public int days;
        public int hours;

        public Travel(double distance, int years, int weeks, int days, int hours)
        {
            this.distanceTraveled = distance;
            this.years = years;
            this.weeks = weeks;
            this.days = days;
            this.hours = hours;
        }




    }
}
