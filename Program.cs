using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {

            //Welcome the user
            Console.WriteLine("Welcome to Rock Paper Scissors me timbers. The only Pirate themed Rock paper scissors game on the seven seas. Arrgghhhh");

            //Create a new instance of HumanPlayer
            HumanPlayer humanPlayer = new HumanPlayer();
            bool keepPlaying = true;
            while (keepPlaying)
            {
                //Prompt user for type of opponent
                Console.WriteLine("Would you like to play against RockLee or MarlonRando?");
                string opponent = Console.ReadLine().ToLower().Trim();

                if (opponent == "rocklee" || opponent == "r")
                {
                    RockPlayer rockOpponent = new RockPlayer();
                    humanPlayer.PlayRockPlayer(humanPlayer, rockOpponent);
                }
                else if (opponent == "marlonrando" || opponent == "m" || opponent.Contains("marlon") || opponent.Contains("rando"))
                {
                    RandomPlayer randomOpponent = new RandomPlayer();
                    humanPlayer.PlayRandomPlayer(humanPlayer, randomOpponent);
                }
                else
                {
                    Console.WriteLine("not an option");
                }

                Console.WriteLine("You won " + humanPlayer.Wins + " time(s)");
                Console.WriteLine("You lost " + humanPlayer.Losses + " time(s)");

                Console.WriteLine("Keep playing? Enter yes or no");
                string getContinue = Console.ReadLine().ToLower().Trim();
                if (getContinue == "yes" || getContinue == "y")
                {
                    keepPlaying = true;
                }
                else if (getContinue == "no" || getContinue == "n")
                {
                    //keepPlaying = false;
                    break;
                }
            }

            Console.WriteLine("Thanks for playing, matey!");

        }

        #region roshambo
        public enum Roshambo
        {
            rock,
            paper,
            scissors
        }
        #endregion roshambo

        public abstract class Player
        {
            public string Name { get; set; }
            public Roshambo RPS { get; set; }
            public int Wins { get; set; }
            public int Losses { get; set; }

            public abstract Roshambo GenerateRoshambo();
        }

        public class RockPlayer : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                return Roshambo.rock;
            }
        }

        public class RandomPlayer : Player
        {
            public override Roshambo GenerateRoshambo()
            {
                Random rnd = new Random();
                int number = rnd.Next(3);
                RPS = (Roshambo)number;
                return RPS;
            }
        }

        public class HumanPlayer : Player
        {
            public HumanPlayer()
            {
                Console.WriteLine("Enter your name");
                Name = Console.ReadLine();
            }

            public override Roshambo GenerateRoshambo()
            {
                Console.WriteLine("Enter your roshambo choice");
                string input = Console.ReadLine();

                if (input.ToLower().Trim() == "rock" || input.ToLower().Trim() == "r")
                {
                    RPS = Roshambo.rock;
                }
                else if (input.ToLower().Trim() == "paper" || input.ToLower().Trim() == "p")
                {
                    RPS = Roshambo.paper;
                }
                else if (input.ToLower().Trim() == "scissors" || input.ToLower().Trim() == "s")
                {
                    RPS = Roshambo.scissors;
                }
                else
                {
                    Console.WriteLine("Exception: wrong input");
                }
                return RPS;
            }

            public void PlayRandomPlayer(HumanPlayer humanPlayer, RandomPlayer opponent)
            {
                string yourRPS = humanPlayer.GenerateRoshambo().ToString();
                string opponentRPS = opponent.GenerateRoshambo().ToString();
                //int wins;
                //int loses;
                if (yourRPS == opponentRPS)
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("Draw!");
                }
                //winning scenarios
                else if (yourRPS == "rock" && opponentRPS == "scissors" || yourRPS == "scissors" && opponentRPS == "paper" || yourRPS == "paper" && opponentRPS == "rock")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You win!");
                    humanPlayer.Wins++;
                }
                else //losing scenarios
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You lose!");
                    humanPlayer.Losses++;
                }
            }

            public void PlayRockPlayer(HumanPlayer humanPlayer, RockPlayer RockLee)
            {
                string yourRPS = humanPlayer.GenerateRoshambo().ToString();
                string opponentRPS = RockLee.GenerateRoshambo().ToString();
                if (yourRPS == opponentRPS)
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("Draw!");
                }
                else if (yourRPS == "paper")
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You win!");
                    humanPlayer.Wins++;
                }
                else
                {
                    Console.WriteLine($"{humanPlayer.Name} Played {yourRPS}");
                    Console.WriteLine($"Opponent Played {opponentRPS}");
                    Console.WriteLine("You lose!");
                    humanPlayer.Losses++;
                }
            }
        }

    }
}