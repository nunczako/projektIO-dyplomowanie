using dyplomowanie.DiplomaProcess.DiplomaFiles;
using dyplomowanie.DiplomaProcess.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class DateOfDefendTests
    {
        //testy - koncepcja klas rownowaznosci
        //dzialajaca data obrony
        [TestMethod]
        public void DateOfDefendWorking()
        {
            DateTime eventTime = new DateTime(2021, 01, 01);
            Student s = new Student("Imie", "Nazwisko", "mail@student.agh.edu.pl", "123456", "Zarzadzania");
            Doctor d = new Doctor("Testowy", "Doktor", "mail@agh.edu.pl", "haslo1", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            var testClass = new DiplomaDefend(d, s, t);
            var actual = testClass.SetDiplomaDefendDate(eventTime);
            var expected = eventTime;


            Assert.AreEqual(expected, actual);
        }

        //sprawdzanie wyjatku - data z przeszlosci
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateOfDefendFromPast()
        {
            DateTime eventTime = new DateTime(2020, 11, 11);
            Student s = new Student("Imie", "Nazwisko", "mail@student.agh.edu.pl", "123456", "Zarzadzania");
            Doctor d = new Doctor("Testowy", "Doktor", "mail@agh.edu.pl", "haslo1", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            var testClass = new DiplomaDefend(d, s, t);
            var actual = testClass.SetDiplomaDefendDate(eventTime);
        }

        //sprawdzanie wyjatku - data poza dozwolonym zakresem
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DateOfDefendMoreThan90Days()
        {
            DateTime eventTime = new DateTime(2024, 12, 12);
            Student s = new Student("Imie", "Nazwisko", "mail@student.agh.edu.pl", "123456", "Zarzadzania");
            Doctor d = new Doctor("Testowy", "Doktor", "mail@agh.edu.pl", "haslo1", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            var testClass = new DiplomaDefend(d, s, t);
            var actual = testClass.SetDiplomaDefendDate(eventTime);
        }

        //sprawdzanie soboty z dozwolonego zakresu
        [TestMethod]
        public void CheckingWorkingSaturday()
        {
            DateTime eventTime = new DateTime(2021, 1, 2);
            Student s = new Student("Imie", "Nazwisko", "mail@student.agh.edu.pl", "123456", "Zarzadzania");
            Doctor d = new Doctor("Testowy", "Doktor", "mail@agh.edu.pl", "haslo1", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            var testClass = new DiplomaDefend(d, s, t);
            var actual = testClass.SetDiplomaDefendDate(eventTime);

            var expected = eventTime.AddDays(2);


            Assert.AreEqual(expected, actual);
        }

        //sprawdzanie niedzieli z dozwolonego zakresu
        [TestMethod]
        public void CheckingWorkingSunday()
        {
            DateTime eventTime = new DateTime(2021, 1, 3);
            Student s = new Student("Imie", "Nazwisko", "mail@student.agh.edu.pl", "123456", "Zarzadzania");
            Doctor d = new Doctor("Testowy", "Doktor", "mail@agh.edu.pl", "haslo1", "Zarzadzania");
            Thesis t = new Thesis("Przykladowy temat", s);
            var testClass = new DiplomaDefend(d, s, t);
            var actual = testClass.SetDiplomaDefendDate(eventTime);

            var expected = eventTime.AddDays(1);


            Assert.AreEqual(expected, actual);
        }
    }

}
