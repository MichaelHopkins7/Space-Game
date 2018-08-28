using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Ship
    {
        private int speed;
        private int slots;
        private int slotCapacity;

        public Ship(int warpSpeed, int shipSlots, int shipSlotCapacity)
        {
            this.speed = warpSpeed;
            this.slots = shipSlots;
            this.slotCapacity = shipSlotCapacity;
        }

        public int Speed()
        {
            return speed;
        }

        public int cargoSlots()
        {
            return slots;
        }

        public int slotSize()
        {
            return slotCapacity;
        }

        private void ShipUpgrade(int choice)
        {
            switch (choice)
            {
                case 1:
                    speed += 1;
                    break;
                case 2:
                    slotCapacity += 2;
                    break;
                case 3:
                    speed = 4;
                    slots = 16;
                    break;
                case 4:
                    speed = 6;
                    slots = 20;
                    slotCapacity = 10;
                    break;
                case 5:
                    speed = 8;
                    slots = 24;
                    break;
            }
        }


    }
}
