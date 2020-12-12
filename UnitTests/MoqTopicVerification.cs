using dyplomowanie.DiplomaProcess.DiplomaFiles;
using dyplomowanie.DiplomaProcess.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class MoqTopicVerification
    {
        //testowanie Moq
        //nalezy pamietac o zmianie isCorrect w klasie Thesis

        //moq pełni tu rolę mocka - wykorzystanie metody verify w celu sprawdzenia, czy dana metoda zostanie wykorzystana
        [TestMethod]
        public void WasTopicCheckedOnce()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Thesis(mock.Object);

            bool actual = TestClass.IsTopicCorrectOrNot("Testowy temat");

            mock.Verify(x => x.IsTopicCorrect("Testowy temat"), Times.Once);

        }

        //moq pełni tu rolę stuba 
        [TestMethod]
        public void IsTopicGood()
        {
            var mock = new Mock<IValidator>();
            mock.Setup(x => x.IsTopicCorrect("Dobry temat pracy")).Returns(true);

            var TestClass = new Thesis(mock.Object);

            bool actual = TestClass.IsTopicCorrectOrNot("Dobry temat pracy");

            var expected = true;

            Assert.AreEqual(expected, actual);

        }
        //moq pełni tu rolę dummy - tworzony jest obiekt mock, ale nie robi się na nim żadnej operacji
        [TestMethod]
        public void EmptyTopic()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Thesis(mock.Object);

            bool actual = TestClass.IsTopicCorrectOrNot("");

            var expected = false;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ForbiddenWordInTopic()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Thesis(mock.Object);

            bool actual = TestClass.IsTopicCorrectOrNot("Temat zawierajacy slowo pomidor");

            var expected = false;

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void TestingWorksOnlyOnce()
        {
            var mock = new Mock<IValidator>();

            var TestClass = new Thesis(mock.Object);

            TestClass.IsTopicCorrectOrNot("Test tematu");

            mock.Verify(x => x.IsTopicCorrect("Test tematu"), Times.Exactly(1));

        }
    }
}
