using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Universal_Tools
    {

        public Universal_Tools()
        {
        }

        public int GetInt(int maxNum)
        {
            int value;
            string input = Console.ReadLine();
            do
            {
                if (int.TryParse(input, out value))
                {
                    if (value > maxNum || value < 0)
                    {
                        Console.WriteLine($"Please enter a valid integer equal to or less than {maxNum}.");
                    }
                    else
                    {
                        return value;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the number of your choice");
                    input = Console.ReadLine();
                }
            }
            while (false);
            return value;
        }
    }
}
