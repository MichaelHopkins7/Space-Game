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

            Ship myShip;
            myShip = new Ship(3, 12, 6, 10, 10); // set ship speed, cargo slots, slot size, fuel tank, and fuel
            Travel myUniverse;
            myUniverse = new Travel(200, 0);
            Player_Stats player;
            player = new Player_Stats(100, 0, 0, 0, 0, 0);
            int[] prices = new int[10];
            Trading makeMoney = new Trading(prices, 0);
            bool isGameOver = false; //if a game end triggers this will be changed to true
            int input; //Useful for when we want input
            

            Console.WriteLine("The Space Game");
            Console.WriteLine("After a lifetime of wandering between planets you have finally decided to pursue your fortune in the interplanetary trade industry.");
            Console.WriteLine("With Earth being your new home you have decided that the best trading planets for your success will be The Great Planet and Alpha Centauri.");
            System.Threading.Thread.Sleep(6000);
            Console.Clear();
            Console.WriteLine("With your life savings(100 credits) and a brand new ship you head out to make your fortune. ");
            Console.WriteLine("Welcome to the beginning of your space trading adventure.");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("Rules for the game:");
            Console.WriteLine("You will have 40 years to acquire as much wealth as possible and become the greatest trader of all time.");
            Console.WriteLine("Trade Routes: Plan appropriate and ensure that you find the best routes for moving around the galaxy.");
            Console.WriteLine("Time: This is your greatest enemy, learn to manipulate it to give you the advantage.");
            Console.WriteLine("Game Over Criteria: The game will end if you lose all of your fortune, quit the game, or you survive to 40 years.");
            System.Threading.Thread.Sleep(8000);
            Console.Clear();

            do
            {
                
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Trade");
                    Console.WriteLine("2. Travel");
                    Console.WriteLine("3. Check Status");
                    Console.WriteLine("0. Quit");
                    input = Utility.GetInt(3);
                    switch (input)
                    {
                        case 1:
                        {
                            
                            makeMoney.NewTrade(myUniverse, player, myShip);
                            break;
                        }
                        case 2:
                        {
                            myUniverse.MovingTo(myShip, player, makeMoney);
                            break;
                        }
                        case 3:
                        {
                            player.Status(myUniverse, myShip);
                            break;
                        }
                        case 0:
                        {
                            isGameOver = true;
                            break;
                        }

                    }
                isGameOver |= Utility.CheckGameOver(myShip, myUniverse, player);
            }
            while (!isGameOver);

            player.Status(myUniverse, myShip);
            
        }
        
        
    }


    
}

    


