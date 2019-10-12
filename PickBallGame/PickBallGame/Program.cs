using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickBallGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] game = new int[] { 0, 3, 4, 6 };
            PrintGame(game);
            while(true)
            {
                HumanMove(game);
                PrintGame(game);
                if(Has0Ball(game))
                {
                    Console.WriteLine("You Lose!");
                    break;
                }
                Console.WriteLine("Computer turn");
                ComputerMove(game);
                PrintGame(game);
                if(Has0Ball(game))
                {
                    Console.WriteLine("You Win!");
                    break;
                }
            }
        }

        public static void HumanMove(int[] game)
        {
            Console.Write("Which group do you choose? ");
            int group = int.Parse(Console.ReadLine());
            Console.Write("How many balls will you pick?");
            int balls = int.Parse(Console.ReadLine());
            PickBalls(game, group, balls);
        }

        public static void ComputerMove(int[] game)
        {
            if(Has1Group(game))
            {
                int g = 0;
                Get1Group(game, out g);
                if (game[g] > 1)
                    PickBalls(game, g, game[g] - 1);
                else
                    PickBalls(game, g, 1);
            }
            else if (Has2Groups(game))
            {
                int a = 0, b = 0;
                Get2Groups(game, out a, out b);
                if (game[a] == 1)
                    PickBalls(game, b, game[b]);
                else if (game[b] == 1)
                    PickBalls(game, a, game[a]);
                else if (game[a] > game[b])
                    PickBalls(game, a, game[a] - game[b]);
                else if (game[b] > game[a])
                    PickBalls(game, b, game[b] - game[a]);
                else
                    PickBalls(game, a, 1);
            }
            else
            {
                Random rand = new Random();
                int group = rand.Next(1, 3);
                int balls = rand.Next(1, game[group]);
                PickBalls(game, group, balls);
                Console.WriteLine("Computer picked group " + group + ", " + balls +" balls");
            }
        }

        public static void PrintGame(int[] game)
        {
            Console.Write("Group 1: ");
            for (int i = 0; i < game[1]; i++)
                Console.Write("0 ");
            Console.WriteLine();
            Console.Write("Group 2: ");
            for (int i = 0; i < game[2]; i++)
                Console.Write("0 ");
            Console.WriteLine();
            Console.Write("Group 3: ");
            for (int i = 0; i < game[3]; i++)
                Console.Write("0 ");
            Console.WriteLine();
        }

        public static void PickBalls(int[] game, int group, int balls)
        {
            game[group] -= balls;
        }

        public static bool Has0Ball(int[] game)
        {
            return game[1] == 0 && game[2] == 0 && game[3] == 0;
        }

        public static bool Has1Group(int[] game)
        {
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
                return true;
            if (game[1] == 0 && game[2] > 0 && game[3] == 0)
                return true;
            if (game[1] == 0 && game[2] == 0 && game[3] > 0)
                return true;
            return false;
        }

        //if there is 1 group has ball, get that group's name

        public static void Get1Group(int[] game, out int g)
        {
            g = 0;
            if (game[1] > 0 && game[2] == 0 && game[3] == 0)
                g = 1;
            if (game[1] == 0 && game[2] > 0 && game[3] == 0)
                g = 2;
            if (game[1] == 0 && game[2] == 0 && game[3] > 0)
                g = 3;
        }

        public static bool Has2Groups(int[] game)
        {
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
                return true;
            if (game[1] > 0 && game[2] == 0 && game[3] > 0)
                return true;
            if (game[1] == 0 && game[2] > 0 && game[3] > 0)
                return true;
            return false;
        }

        public static void Get2Groups(int[] game, out int a, out int b)
        {
            a = b = 0;
            if (game[1] > 0 && game[2] > 0 && game[3] == 0)
            {
                a = 1;
                b = 2;
            }
            if (game[1] > 0 && game[2] == 0 && game[3] > 0)
            {
                a = 1;
                b = 3;
            }
            if (game[1] == 0 && game[2] > 0 && game[3] > 0)
            {
                a = 2;
                b = 3;
            }
        }

        public static bool Has3Groups(int[] game)
        {
            return game[1] > 0 && game[2] > 0 && game[3] > 0;
        }


    }
}
