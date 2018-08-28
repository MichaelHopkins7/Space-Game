using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game
{
    class Ship
    {
        private int speed = 3;
        private int slots  = 6;
        private int slotCapacity = 6;
        private bool speedUp = true;
        private bool capacityUp = true;

        public Ship()
        {
            this.speed = 3;
            this.slots = 12;
            this.slotCapacity = 6;
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

        public void ShipUpgrade(int choice)
        {
            switch (choice)
            {
                case 1:
                    speed += 2;
                    speedUp = true;
                    break;
                case 2:
                    slotCapacity += 2;
                    capacityUp = true;
                    break;
                case 3:
                    speed = 4;
                    slots = 16;
                    speedUp = false;
                    capacityUp = false;
                    break;
                case 4:
                    speed = 6;
                    slots = 20;
                    slotCapacity = 10;
                    speedUp = false;
                    capacityUp = false;
                    break;
                case 5:
                    speed = 8;
                    slots = 24;
                    speedUp = false;
                    capacityUp = false;
                    break;
            }
        }
    }
}
