using System;

namespace MCQuiz
{
	/// <summary>
	/// This class handles a specific choice for a question
	/// </summary>
	public class Answer
    {
        private string text;
        private bool correct;
        private bool choosen;

        /// <summary>
        /// Constructor for Answer Object
        /// </summary>
        /// <param name="text"></param>
        /// <param name="correct"></param>
        public Answer(string text, bool correct)
        {
            this.text = FormatAnswerString(text);
            this.correct = correct;
            this.choosen = false;
        }

        /// <summary>
        /// Get text of this answer
        /// </summary>
        /// <returns>text</returns>
        public string GetText()
        {
            return this.text;
        }

        /// <summary>
        /// Returns true if this answer was choosen by a user
        /// </summary>
        /// <returns>choosen</returns>
        public bool IsChoosen()
        {
            return this.choosen;
        }

        /// <summary>
        /// Simulate choose by user
        /// </summary>
        public void SetChoosen()
        {
            this.choosen = true;
        }

        /// <summary>
        /// Revert SetChoosen
        /// </summary>
        public void SetUnchoosen()
        {
            this.choosen = false;
        }

        /// <summary>
        /// Returns true if this answer is the correct one for the question
        /// </summary>
        /// <returns>correct</returns>
        public bool IsCorrect()
        {
            return this.correct;
        }

        private string FormatAnswerString(string answerText)
        {
            string output = "";
            string[] textParts = answerText.Split(' ');
            int charcount = 0;
            foreach (var part in textParts)
            {
				if(charcount > 0)
				{
					output += " ";
				}
                output += part;
                charcount += part.Length;
                if (charcount >= 60)
                {
                    output += "\n";
                    charcount = 0;
                }
            }
            return output;
        }
    }
}