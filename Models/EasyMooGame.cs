using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Models
{
    public class EasyMooGame : MooGame, IMooGame
    {
        public int GoalLength { get; set; }
        public int MaxRange { get; set; }

        public string CreateGoal(int goalLength, int maxRange)
        {
            SetMaxRange();
            Random randomGenerator = new Random();
            string goal = "";

            while (goal.Length < goalLength)
            {
                int randomDigit = randomGenerator.Next(maxRange);
                if (!goal.Contains("" + randomDigit))
                {
                    goal += randomDigit;
                }
            }
            Console.WriteLine($"Goal is {goal}");
            this.Goal = goal;
            return goal;
        }

        public string GetUserGuess()
        {
            string guess = "";
            bool isValidGuess = false;
            while (!isValidGuess)
            {
                Console.WriteLine("Enter guess");
                guess = Console.ReadLine();
                if (guess.Length == this.Goal.Length)
                {
                    isValidGuess = true;
                }
                else
                {
                    isValidGuess = false;
                    Console.WriteLine($"Invalid guess. Digits in the guess should be {this.GoalLength}");
                }
            }
            this.Guess = guess;
            return guess;
        }
        public string CheckBullsCows(string goal, string guess)
        {
            string outputBC = "";
            string matchedNumbers = "";
            bool matchFound;

            for (int i = 0; i < guess.Length; i++)
            {
                matchFound = false;

                for (int j = 0; j < goal.Length; j++)
                {
                    if (guess[i] == goal[j])
                    {
                        if (!matchedNumbers.Contains(guess[i]))
                        {
                            matchedNumbers += goal[j];
                            matchFound = true;
                            if (i == j)
                            {
                                outputBC += "B";
                            }
                            else
                            {
                                outputBC += "C";
                            }
                        }
                    }
                }
                if (!matchFound)
                {
                    outputBC += ",";
                }
            }
            return outputBC;
        }

        public int CountAttempts(string goal)
        {
            int attempts = 0;
            string targetRequired = this.TargetBulls;
            string bbcc = "";
            string guess = "";

            while (bbcc != targetRequired)
            {
                attempts++;
                guess = GetUserGuess();
                bbcc = CheckBullsCows(goal, guess);
                Console.WriteLine("\n" + bbcc + "\n");
            }
            this.NoOfGuesses = attempts;
            return attempts;
        }
        public void SetMaxGoalLength()
        {
            this.MaxGoalLength = 5;
        }
        public void SetMaxRange()
        {
            this.MaxRange = 10;
        }
        public string CreateBullsString(int goalLength)
        {
            string targetBullString = "";
            for (int i = 0; i < goalLength; i++)
            {
                targetBullString += "B";
            }
            this.TargetBulls = targetBullString;
            return targetBullString;
        }
        public int GetGoalLength()
        {
            SetMaxGoalLength();
            Console.WriteLine($"Enter goal length you want.Max goal length allowed is {this.MaxGoalLength}:\n");
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

                if ((userSelectedInteger <= this.MaxGoalLength))
                {
                    isInvalidInput = false;
                }
                else
                {
                    isInvalidInput = true;
                    Console.WriteLine("Invalid input");
                }
            }
            this.GoalLength = userSelectedInteger;
            CreateBullsString(this.GoalLength);
            return userSelectedInteger;
        }

        public void GetPlayerName(string userName)
        {
            this.PlayerName = userName;
        }
        public void UpdateResults()
        {
            playerData.SaveGameData(PlayerName, NoOfGuesses);
            playerData.ShowTopList();
        }

        public void SetGameType()
        {
            this.GameType = "Easy";
        }
    }
}
