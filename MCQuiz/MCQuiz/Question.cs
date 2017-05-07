using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MCQuiz
{
    /// <summary>
    /// This class handles a specific question object
    /// which contains multiple answers
    /// </summary>
    public class Question
    {
        private string text;
        private List<Answer> answers;
        private int id;
        private string picture_location;

        /// <summary>
        /// Constructor for Question
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="answers"></param>
        public Question(int id, string text, List<Answer> answers)
        {
            Match regex = Regex.Match(text, "(.*){\\\\Binnen\\\\(.*)}");
            if (regex.Value != "")
            {
                this.text = regex.Groups[1].Value;
                this.picture_location = "..\\..\\Binnen" + @"\" + regex.Groups[2].Value;
            }
            else
            {
                this.text = text;
                this.picture_location = "";
            }
            this.answers = answers;
            this.id = id;
        }

        /// <summary>
        /// ToString method for Question object
        /// </summary>
        /// <returns>output</returns>
        public override string ToString()
        {
            string output = "";
            output = this.id + ": " + this.text;
            int answer_id = 1;
            foreach (Answer answer in this.answers)
            {
                output += "\n\t#" + answer_id++ + ": " + answer.GetText() + "(Ausgewählt: " + answer.IsChoosen() + ") " + answer.IsCorrect();
            }
            output += "\nAuswertung: " + (IsRight() ? 1 : 0);
            return output;
        }

        /// <summary>
        /// Sets the number'th answer to choosen
        /// Unsets all others
        /// </summary>
        /// <param name="number"></param>
        /// <returns>success</returns>
        public bool AnswerQuestion(int number)
        {
            try
            {
                for (int i = 0; i < this.answers.Count; i++)
                {
                    if (i == number)
                    {
                        this.answers[i].SetChoosen();
                    }
                    else
                    {
                        this.answers[i].SetUnchoosen();
                    }
                }
                return true;
            }
            catch (ArgumentOutOfRangeException e)
            {
                return false;
            }
        }

        /// <summary>
        /// This id represents Id from Database
        /// </summary>
        /// <returns>id</returns>
        internal int GetId()
        {
            return this.id;
        }

        /// <summary>
        /// return true if the choosen answer was right
        /// else false
        /// </summary>
        /// <returns></returns>
        public bool IsRight()
        {
            bool correct = false;
            foreach (Answer answer in answers)
            {
                if (answer.IsCorrect() && answer.IsChoosen())
                {
                    correct = true;
                }
            }
            return correct;
        }

        /// <summary>
        /// get i'th answer
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Answer GetAnswer(int i)
        {
            return this.answers[i];
        }

        /// <summary>
        /// return question text
        /// </summary>
        /// <returns>text</returns>
        public string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// return link of picture
        /// </summary>
        /// <returns></returns>
        public string GetPictureLocation()
        {
            return this.picture_location;
        }

        /// <summary>
        /// return choosen answer object if exists
        /// else null
        /// </summary>
        /// <returns>answer</returns>
        public Answer GetSelectedAnswer()
        {
            foreach (Answer answer in this.answers)
            {
                if (answer.IsChoosen())
                {
                    return answer;
                }
            }
            return null;
        }

        /// <summary>
        /// return correct answer object if exists
        /// else null
        /// </summary>
        /// <returns></returns>
        public Answer GetCorrectAnswer()
        {
            foreach (Answer answer in this.answers)
            {
                if (answer.IsCorrect())
                {
                    return answer;
                }
            }
            return null;
        }
    }
}
