using dyplomowanie.DiplomaProcess.DiplomaFiles;
using dyplomowanie.DiplomaProcess.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class DiplomaTest
    {
        //klasa testowa do punktu 3, który opisany jest w wordzie - testy pokrycia instrukcji, gałęzi, warunków
        [DataRow(Status.Ready, 4, 4, 4)]
        [DataRow(Status.Ready, 2, 4, 2)]
        [DataRow(Status.AddedOpinion, 3, 4, 0)]
        [DataRow(Status.AddedOpinion, 4, 4, 0)]
        [DataRow(Status.Ready, 5, 5, 5)]
        [DataTestMethod]
        public void FinalMarkTest(Status status, int reviewMark, int opinionMark, int expectedResult)
        {
            Student s = new Student("Imie", "Nazwisko", "mail@agh.edu.pl", "123456", "Zarzadzania");
            var testClass = new Thesis("Przykladowy temat", s);
            var actual = testClass.CalculateMark(status, reviewMark, opinionMark);
            var expected = expectedResult;


            Assert.AreEqual(expected, actual);
        }
    }

}
