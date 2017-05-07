using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCQuiz
{
    /// <summary>
    /// This Class represents a questionnaire with multiple question objects
    /// </summary>
    public class Questionnaire
    {
        private List<Question> questions = new List<Question>();
        private int id;
        private int question_pointer;
        private string type;

        /// <summary>
        /// Constructor for questionnaire object
        /// </summary>
        /// <param name="id"></param>
        public Questionnaire(int id, string type)
        {
            this.id = id;
            this.question_pointer = 0;
            this.type = type;
        }

        public string GetQuestionnaireType()
        {
            return this.type;
        }

        /// <summary>
        /// Adds a new question to questionnaire
        /// </summary>
        /// <param name="id"></param>
        /// <param name="text"></param>
        /// <param name="answers"></param>
        public void AddQuestion(int id, string text, List<Dictionary<string, bool>> answers)
        {
            List<Answer> answer_list = new List<Answer>();
            foreach (var item in answers)
            {
                foreach (var item_part in item)
                {
                    Answer answer = new Answer(item_part.Key, item_part.Value);
                    answer_list.Add(answer);
                }
            }
            Question question = new Question(id, text, answer_list);
            this.questions.Add(question);
        }

        /// <summary>
        /// Get all questions as array
        /// </summary>
        /// <returns>questions</returns>
        public List<Question> GetQuestions()
        {
            return this.questions;
        }

        /// <summary>
        /// Get question_id'th answer of this question if exists
        /// else return null
        /// </summary>
        /// <param name="question_id"></param>
        /// <returns></returns>
        public Question GetQuestion(int question_id)
        {
            foreach (Question q in this.questions)
            {
                if (q.GetId() == question_id)
                {
                    return q;
                }
            }
            return null;
        }

        /// <summary>
        /// ToString method for question object
        /// returns formated string with questions and answers
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";
            foreach (Question question in this.questions)
            {
                output += question.ToString() + "\n";
            }
            return output;
        }

        /// <summary>
        /// Get current question object
        /// </summary>
        /// <returns></returns>
        public Question GetCurrentQuestion()
        {
            return this.questions[question_pointer];
        }

        /// <summary>
        /// Get first question of this questionnaire
        /// sets pointer to zero
        /// </summary>
        /// <returns>question</returns>
        public Question GetFirstQuestion()
        {
            this.question_pointer = 0;
            return this.questions[0];
        }

        /// <summary>
        /// Get next question in questionnaire after current if exists
        /// else return null
        /// increment question_pointer
        /// </summary>
        /// <returns>question</returns>
        public Question GetNextQuestion()
        {
            if (question_pointer < QuestionCount() - 1)
            {
                return this.questions[++question_pointer];
            }
            return null;
        }

        /// <summary>
        /// Get previous question in questionnaire before current if exists
        /// else return null
        /// decrement question_pointer
        /// </summary>
        /// <returns>question</returns>
        public Question GetPreviousQuestion()
        {
            if (question_pointer > 0)
            {
                return this.questions[--question_pointer];
            }
            return null;
        }

        /// <summary>
        /// Get sum of all questions in this questionnaire
        /// </summary>
        /// <returns>sum</returns>
        private int QuestionCount()
        {
            return this.questions.Count;
        }

        /// <summary>
        /// Get percent of correct answers in this questionare
        /// </summary>
        /// <returns>percentage of correct answers</returns>
        public double Evaluate()
        {
            return 100 * (double)CountCorrectAnswers() / QuestionCount();
        }

        /// <summary>
        /// Get evaluation string for output
        /// </summary>
        /// <returns>output</returns>
        public string GetEvaluateString()
        {
            return CountCorrectAnswers() + " von " + QuestionCount() + " Fragen sind richtig!";
        }

        /// <summary>
        /// Get sum of all correct answers in this questionnaire
        /// </summary>
        /// <returns>sum</returns>
        private int CountCorrectAnswers()
        {
            int correct_answers = 0;
            foreach (Question question in this.questions)
            {
                if (question.IsRight())
                {
                    correct_answers++;
                }
            }

            return correct_answers;
        }

        /// <summary>
        /// Get sum of all wrong answers in this questionnaire
        /// </summary>
        /// <returns>sum</returns>
        private List<Question> GetWrongAnswers()
        {
            List<Question> questions = new List<Question>();
            foreach (Question question in this.questions)
            {
                if (!question.IsRight())
                {
                    questions.Add(question);
                }
            }
            return questions;
        }

        /// <summary>
        /// Get formated string with:
        /// all wrong answered questions
        /// selected answer
        /// correct answer
        /// </summary>
        /// <returns>output</returns>
        public string GetWrongAnswerString()
        {
            string output = "";
            List<Question> questions = GetWrongAnswers();
            foreach (Question question in questions)
            {
                output += "#" + question.GetId() + ": " + question.GetText() + "\r\n";
                if (question.GetSelectedAnswer() != null)
                {
                    output += "Deine Antwort: \t" + question.GetSelectedAnswer().GetText() + "\r\n";
                }

                if (question.GetCorrectAnswer() != null)
                {
                    output += "Richtig: \t\t" + question.GetCorrectAnswer().GetText() + "\r\n";
                }

                output += "\r\n";
            }
            return output;
        }

        public int GetID()
        {
            return this.id;
        }

    }
}
