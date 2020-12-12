using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using dyplomowanie;
using dyplomowanie.DiplomaProcess;
using dyplomowanie.DiplomaProcess.Users;

namespace UnitTests
{
    //testowanie formatu e-maila
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void IsFormatOfEmailOk()

        {
            bool expected = true;
            Contacts c = new Contacts();
            string e = "testowymail@agh.edu.pl";
            Doctor d = new Doctor("Testowy", "Doktor", e, "haslo1", "Zarzadzania");
            var testClass = new AddingContact(c, e, d);

            bool actual = testClass.IsValidEmail(e);

            Assert.AreEqual(expected, actual);
        }

        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsFormatOfEmailBad()
        {
            Contacts c = new Contacts();
            string e = "testowymailagh.edu.pl";
            Doctor d = new Doctor("Testowy", "Doktor", e, "haslo1", "Zarzadzania");
            var testClass = new AddingContact(c, e, d);

            bool actual = testClass.IsValidEmail(e);
        }
    }
}
