using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaGame
{
    class Trivia
    {
        //TODO: Fill out the Trivia Object
        
        //The Trivia Object will have 2 properties
        // at a minimum, Question and Answer
        private string _question;

        public string Question
        {
            //question property
            get { return _question; }
            set { _question = value; }
        }

        private string _answer;

        public string Answer
        {
            //answer property
            get { return _answer; }
            set { _answer = value; }
        }

        private string _category;

        public string Category
        {
            //category property
            get { return _category; }
            set { _category = value; }
        }

        //The Constructor for the Trivia object will
        // accept only 1 string parameter.  You will
        // split the question from the answer in your
        // constructor and assign them to the Question
        // and Answer properties

        public Trivia(string input)
        {
            //check to see if input has a :
            if (input.Contains(':'))
            {
                //it does, split and set category equal to everything before the :
                this.Category =  input.Split(':').First().ToString();
                //set input to be input with the category removed
                input = input.Split(':').Last().ToString();
            }
            else
            {
                //it does not, set category to unknown
                this.Category = "UNKNOWN";
            }

            //split on * to get question and answer
            this.Question = input.Split('*').First().ToString();
            this.Answer = input.Split('*').Last().ToString();
        }


    }
}
