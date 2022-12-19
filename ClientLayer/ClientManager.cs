using Microsoft.Extensions.DependencyInjection;
using MooGame.GameFactory;
using MooGame.Interfaces;
using MooGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.ClientLayer
{
    public static class ClientManager
    {
        public static void StartGame(IServiceProvider serviceProvider)
        {
            bool playOn = true;
            string playerName = AskPlayerName();

            while (playOn)
            {
                DisplayGameMenu();
                string userSelection = GetUserSelection();

                var gameManager = serviceProvider.GetRequiredService<GameManager>();
                var mooGame = gameManager.CreateMooGame(userSelection);
                //EasyMooGame mooGame = new EasyMooGame();

                mooGame.GetPlayerName(playerName);
                mooGame.GetGoalLength();
                int goalLength = mooGame.GoalLength;
                mooGame.SetMaxRange();
                int maxLength = mooGame.MaxRange;

                string goal = mooGame.CreateGoal(goalLength, maxLength);
                int attempts = mooGame.CountAttempts(goal);
                mooGame.UpdateResults();

                Console.WriteLine("Correct, You made " + attempts + " attempts in this game");
                Console.Write("Do you want to continue? (y/n): ");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }

        public static string AskPlayerName()
        {
            Console.WriteLine("Welcome to MooGame");
            Console.WriteLine("Enter player name");
            string playerName = Console.ReadLine();
            return playerName;
        }

        public static void DisplayGameMenu()
        {
            Console.WriteLine("------New Game------\n");
            Console.WriteLine("Select any game from below. Selection can be made using game number");
            Console.WriteLine("1. Easy Moo Game. (Numbers will not repeat)");
            Console.WriteLine("2. Difficult Moo Game. (Numbers will repeat)");
        }

        public static string GetUserSelection()
        {
            string userSelection = "";
            int userSelectedInteger = 0;
            bool isInvalidInput = true;

            while (isInvalidInput)
            {
                userSelection = Console.ReadLine();
                try
                {
                    userSelectedInteger = Int32.Parse(userSelection);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only integer inputs are allowed");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input");
                }

                if ((userSelectedInteger == 1) || (userSelectedInteger == 2))
                {
                    isInvalidInput = false;
                }
                else
                {
                    isInvalidInput = true;
                    Console.WriteLine("Invalid input");
                }
            }
            return userSelection;
        }





    }
}
