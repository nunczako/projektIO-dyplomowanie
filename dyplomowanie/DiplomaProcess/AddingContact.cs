using dyplomowanie.DiplomaProcess.Interfaces;
using dyplomowanie.DiplomaProcess.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace dyplomowanie.DiplomaProcess
{
    public class AddingContact : ICommand
    {
        private Contacts _contacts;
        private string _mail;
        private Doctor _doctor;
        public AddingContact(Contacts contacts, string mail, Doctor doctor)
        {
            this._contacts = contacts;
            this._mail = mail;
            this._doctor = doctor;
        }

        //metoda sprawdzajaca format e-maila - poprawny format xyz@xyz.com
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                throw new ArgumentException("Format w jakim zostal podany mail jest niepoprawny!");
            }
        }

        //dodawanie emailow do tablicy kontaktow z doktorami - jezeli forma maila sie nie zgadza, to nie zostanie on dodany
        public void Execute()
        {
            bool isMailGood = IsValidEmail(this._mail);
            if (isMailGood != false)
            {
                this._contacts.AddContact(_mail, _doctor);
            }
            else
            {
                Console.WriteLine("E-mail nie moze zostac dodany do bazy kontaktow! \nProsze podac e-mail w poprawnej formie!");
            }
        }
    }
}
