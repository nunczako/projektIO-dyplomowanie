using dyplomowanie.DiplomaProcess.DiplomaFiles;
using dyplomowanie.DiplomaProcess.Interfaces;
using dyplomowanie.DiplomaProcess.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess
{
    //wzorzec obserwatora - klasa definiujaca powiadomienie dla uzytkownika w przypadku aktualizacji statusu
    public class UserNotification : IObserver
    {
        public User UserWithNotifications { get; protected set; }

        public UserNotification(User user)
        {
            UserWithNotifications = user;
        }

        //Wersja PULL
        public void Update(Thesis thesis)
        {
            Console.WriteLine($"Status pracy obserwowanej przez użytkownika o imieniu {this.UserWithNotifications.FirstName}" +
                $" został zaktualizowany. Obecny status obserwowanej pracy to: {thesis.Status}");
        }
    }
}
