using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //change the title of the console
            Console.Title = "Trivia Game!";

            //The logic for your trivia game happens here
            List<Trivia> AllQuestions = GetTriviaList();

            //make a random number generator to select questions
            Random rng = new Random();
            //declare variables for the number of correct and incorrect answers
            int correct = 0;
            int incorrect = 0;

            //Call the greet function
            Greet();

            //Loop to play the game
            while (correct < 20 && incorrect < 5)
            {
                //generate a random number
                int randQuestion = rng.Next(AllQuestions.Count);

                //Tell the user the category
                Console.WriteLine("\nThe category is " + AllQuestions[randQuestion].Category + ":");

                //output a question for test purposes
                Console.WriteLine(AllQuestions[randQuestion].Question + "\n");

                //take user input
                string input = Console.ReadLine();

                //check if the user is correct
                if (Standardize(input) == Standardize(AllQuestions[randQuestion].Answer))
                {
                    //the user is correct
                    Console.WriteLine("You are correct!\n\n");
                    correct++;
                }
                else
                {
                    //the user is wrong
                    Console.WriteLine("You are wrong!\nThe correct answer is " + AllQuestions[randQuestion].Answer + ".\n\n");
                    incorrect++;
                }

                //check if the user has won or lost
                if (correct >= 20)
                {
                    //the user won
                    Console.WriteLine("\n\n\nYou have won, good job.");
                }
                else if (incorrect >= 5)
                {
                    //the user lost
                    Console.WriteLine("\n\n\nYou have lost.");
                }
                else
                {

                }
            }

            //keep the console open
            Console.ReadKey();
        }


        //This functions gets the full list of trivia questions from the Trivia.txt document
        static List<Trivia> GetTriviaList()
        {
            //Get Contents from the file.  Remove the special char "\r".  Split on each line.  Convert to a list.
            List<string> contents = File.ReadAllText("trivia.txt").Replace("\r", "").Split('\n').ToList();

            //Each item in list "contents" is now one line of the Trivia.txt document.
            
            //make a new list to return all trivia questions
            List<Trivia> returnList = new List<Trivia>();
            // TODO: go through each line in contents of the trivia file and make a trivia object.
            //       add it to our return list.
            // Example: Trivia newTrivia = new Trivia("what is my name?*question");
            returnList.AddRange(contents.Select(x => new Trivia(x)));
            //Return the full list of trivia questions
            return returnList;
        }

        //Greet the user
        static void Greet()
        {
            //welcome and give instructions to the user
            Console.WriteLine(@"Welcome to the Trivia Game!
You will be asked questions and will need to type in answers.
The game will end when you have answered 20 questions right or five wrong.
");
        }

        static string Standardize(string input)
        {
            //standardize inputs and answers
            input = input.ToLower().Replace("\'", "");
            return input;
        }
    }
}
