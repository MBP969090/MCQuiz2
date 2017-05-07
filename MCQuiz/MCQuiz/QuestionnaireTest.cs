using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MCQuiz
{
    [TestFixture]
    class QuestionnaireTest
    {
        Questionnaire q = new Questionnaire(1, "Binnen");

        [SetUp]
        public void SetupQuestionnaire()
        {
            q.AddQuestion(1, "Warum nur?", new List<Dictionary<string, bool>>());
            q.AddQuestion(2, "Warum nicht?", new List<Dictionary<string, bool>>());
            q.AddQuestion(3, "Ja warum eigentlich nicht?", new List<Dictionary<string, bool>>());
        }

        [Test]
        public void GetQuestionTest()
        {
            Assert.AreEqual("Warum nur?", q.GetCurrentQuestion().GetText());
        }

        [Test]
        public void NextQuestionTest()
        {
            Question nextQuestion = q.GetNextQuestion();
            Assert.AreEqual("Warum nicht?", nextQuestion.GetText());
            Question currentQuestion = q.GetCurrentQuestion();
            Assert.AreEqual("Warum nicht?", currentQuestion.GetText());
        }

        [Test]
        public void PreviousQuestionTest()
        {
            Assert.AreEqual("Warum nur?", q.GetPreviousQuestion().GetText());
            q.GetNextQuestion();
            q.GetNextQuestion();
            Assert.AreEqual("Warum nicht?", q.GetPreviousQuestion().GetText());
        }

        [Test]
        public void ConstructorTest()
        {
            Questionnaire q = new Questionnaire(1, "Binnen");
            List<Dictionary<String, bool>> answers = new List<Dictionary<string, bool>>(1);
            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            dict.Add("1", true);
            dict.Add("2", false);
            dict.Add("3", false);
            dict.Add("4", false);
            answers.Add(dict);
            q.AddQuestion(1, "Warum nur?", answers);
            Assert.AreEqual("Warum nur?", q.GetFirstQuestion().GetText());
            Assert.AreEqual("1", q.GetFirstQuestion().GetCorrectAnswer().GetText());
        }
    }
}