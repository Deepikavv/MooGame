using MooGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Models
{
    public class DifficultMooGame : MooGame, IMooGame
    {
        public int GoalLength { get; set; }
        public int MaxRange { get; set; }
        // Creates string with repeated numbers
        public string CreateGoal(int goalLength, int maxRange)
        {
            SetMaxRange();
            Random randomGenerator = new();
            string goal = "";

            while (goal.Length < goalLength)
            {
                int randomDigit = randomGenerator.Next(maxRange);
                goal += randomDigit;
            }
            Console.WriteLine($"Goal is {goal}");
            this.Goal = goal;
            return goal;
        }

        public string GetUserGuess()
        {
            string? guess = "";
            bool isValidGuess = false;
            while (!isValidGuess)
            {
                guess = Console.ReadLine();
                if (guess!.Length == this.Goal!.Length)
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

        // Allows checking of repeated characters of a string
        public string CheckBullsCows(string goal, string guess)
        {
            string outputBC = "";
            string checkedChars = "";
            int charGoalCount = 0;
            int checkedCharCount = 0;
            for (int i = 0; i < guess.Length; i++)
            {
                char goalChar = goal[i];
                char guessChar = guess[i];
                charGoalCount = goal.Count(x => x == guessChar);

                if (guessChar == goalChar)
                {
                    checkedChars += guessChar;
                    outputBC += "B";
                    checkedCharCount = checkedChars.Count(x => x == guessChar);

                    if (checkedCharCount > charGoalCount)
                    {
                        int indexToModify = checkedChars.IndexOf(guessChar);
                        outputBC = outputBC.Remove(indexToModify, 1);
                        outputBC = outputBC.Insert(indexToModify, ",");
                    }
                }
                else if (goal.IndexOf(guessChar) != -1)
                {
                    checkedChars += guessChar;
                    if (checkedChars.Count(x => x == guessChar) > charGoalCount)
                    {
                        outputBC += ",";
                    }
                    else
                    {
                        outputBC += "C";
                    }
                }
                else
                {
                    outputBC += ",";
                    checkedChars += guessChar;
                }
            }
            return outputBC;
        }
        public int CountAttempts(string goal)
        {
            int attempts = 0;
            string targetRequired = this.TargetBulls!;
            string bbcc = "";
            string guess;
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

        public void UpdateResults()
        {
            playerData.SaveGameData(PlayerName!, NoOfGuesses);
            playerData.ShowTopList();
        }

        public void SetMaxGoalLength()
        {
            this.MaxGoalLength = 9;
        }
        public void SetMaxRange()
        {
            this.MaxRange = 6;
        }

        public void GetPlayerName(string userName)
        {
            this.PlayerName = userName;
        }

        public int GetGoalLength()
        {
            SetMaxGoalLength();
            Console.WriteLine($"Enter goal length you want. Max goal length allowed is {this.MaxGoalLength}:\n");
            string? userSelection;
            int userSelectedInteger = 0;
            bool isInvalidInput = true;
            while (isInvalidInput)
            {
                userSelection = Console.ReadLine();
                try
                {
                    userSelectedInteger = Int32.Parse(userSelection!);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only integer inputs are allowed");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Invalid input");
                }

                if ((userSelectedInteger <= this.MaxGoalLength) && (userSelectedInteger > 0))
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

        public void SetGameType()
        {
            this.GameType = "Difficult";
        }
    }
}
