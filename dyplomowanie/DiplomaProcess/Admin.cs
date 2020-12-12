using dyplomowanie.DiplomaProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess
{
    //admin strony - wzorzec polecenia, dodawanie maila do listy, dodawanie wszystkich maili
    public class Admin
    {
        private List<ICommand> _emailsList = new List<ICommand>();
        public void AddMailToList(ICommand email)
        {
            this._emailsList.Add(email);
        }

        public void ExecuteAllEmails()
        {
            foreach (ICommand email in this._emailsList)
            {
                email.Execute();
            }
            this._emailsList.Clear();
        }
    }
}
