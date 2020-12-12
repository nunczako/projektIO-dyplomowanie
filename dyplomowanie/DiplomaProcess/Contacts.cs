using dyplomowanie.DiplomaProcess.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie
{
    //wzorzec polecenia - dodawanie poszczegolnych kontaktow od doktorow, wyswietlanie wszystkich e-maili
    public class Contacts
    {
        private List<string> _mailsList = new List<string>();

        public void AddContact(string mail, Doctor doctor)
        {
            string toAdd = $"Imię: {doctor.FirstName}\n" +$"Nazwisko: {doctor.LastName}\n" +$"E-mail: {mail}\n";
            _mailsList.Add(toAdd);
        }

        public void ShowAllMails()
        {
            Console.WriteLine("Lista maili do podanych doktorow w celach kontaktowych:");
            foreach (string mail in _mailsList)
            {
                Console.WriteLine(mail);
            }
        }
    }
}
