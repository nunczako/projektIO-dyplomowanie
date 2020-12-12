using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dyplomowanie;
using dyplomowanie.DiplomaProcess;
using dyplomowanie.DiplomaProcess.Users;
using dyplomowanie.DiplomaProcess.DiplomaFiles;

namespace UnitTests
{
    //testy w poblizu granic - testowanie wpisanych ocen
    [TestClass]
    public class MarksTests
    {
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(2)]

        [DataTestMethod]

        public void MarksTestsWorkingReview(int mark)

        {
            Doctor d = new Doctor("Testowy", "Doktor", "testowyMail@agh.edu.pl", "123456", "Zarzadzania");
            Student s = new Student("Imie", "Nazwisko", "mail@agh.edu.pl", "123456", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            Review r = new Review(d, t, mark, "opinia");

            var actual = r.Mark;
            var expected = mark;


            Assert.AreEqual(expected, actual);

        }

        //spodziewany wyjatek - niedozwolone oceny
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(7)]
        [DataRow(22)]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BadMarksReview(int mark)
        {
            Doctor d = new Doctor("Testowy", "Doktor", "testowyMail@agh.edu.pl", "123456", "Zarzadzania");
            Student s = new Student("Imie", "Nazwisko", "mail@agh.edu.pl", "123456", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            Review r = new Review(d, t, mark, "opinia");

            var actual = r.Mark;
            var expected = mark;


            Assert.AreEqual(expected, actual);
        }

        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]

        [DataTestMethod]

        public void MarksTestsWorkingOpinion(int mark)

        {
            Doctor d = new Doctor("Testowy", "Doktor", "testowyMail@agh.edu.pl", "123456", "Zarzadzania");
            Student s = new Student("Imie", "Nazwisko", "mail@agh.edu.pl", "123456", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            Opinion o = new Opinion(d, t, mark, "opinia");

            var actual = o.Mark;
            var expected = mark;


            Assert.AreEqual(expected, actual);

        }


        //spodziewany wyjatek - niedozwolone oceny
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(77)]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BadMarksOpinion(int mark)
        {
            Doctor d = new Doctor("Testowy", "Doktor", "testowyMail@agh.edu.pl", "123456", "Zarzadzania");
            Student s = new Student("Imie", "Nazwisko", "mail@agh.edu.pl", "123456", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            Opinion o = new Opinion(d, t, mark, "opinia");

            var actual = o.Mark;
            var expected = mark;


            Assert.AreEqual(expected, actual);
        }
    }
}
