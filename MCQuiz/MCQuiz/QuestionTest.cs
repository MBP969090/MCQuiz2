using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MCQuiz
{
    class QuestionTest
    {
        Question q = new Question(3, "Was ist eine Grußformel?", new List<Answer> {
            new Answer("Hallo", true),
            new Answer("Tschüss", false),
            new Answer("Bye", false),
            new Answer("Auf Wiedersehen", false)
        });

        [Test]
        public void QuestionIdTest()
        {
            Assert.AreEqual(3, q.GetId());
        }

        [Test]
        public void QuestionTextTest()
        {
            Assert.AreEqual("Was ist eine Grußformel?", q.GetText());
        }

        [Test]
        public void QuestionAnswersTextTest()
        {
            Assert.AreEqual("Hallo", q.GetAnswer(0).GetText());
            Assert.AreEqual("Bye", q.GetAnswer(2).GetText());
        }

        [Test]
        public void QuestionRightAnswerTest()
        {
            Assert.AreEqual("Hallo", q.GetCorrectAnswer().GetText());
        }

        [Test]
        public void QuestionSelectedAnswerTest()
        {
            q.AnswerQuestion(2);
            Assert.AreEqual("Bye", q.GetSelectedAnswer().GetText());
            q.AnswerQuestion(0);
            Assert.AreEqual("Hallo", q.GetSelectedAnswer().GetText());
        }
    }
}
