using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MCQuiz
{
    [TestFixture]
    class AnswerTest
    {
        Answer answer1 = new Answer("Meine Antwort", false);
        Answer answer2 = new Answer("Meine Richtige Antwort", true);

        [Test]
        public void AnswerTextTest()
        {
            Assert.AreEqual("Meine Antwort", answer1.GetText());
            Assert.AreEqual("Meine Richtige Antwort", answer2.GetText());
        }

        [Test]
        public void RightAnswerTest()
        {
            Assert.IsTrue(answer2.IsCorrect());
            Assert.IsFalse(answer1.IsCorrect());
        }
    }
}
