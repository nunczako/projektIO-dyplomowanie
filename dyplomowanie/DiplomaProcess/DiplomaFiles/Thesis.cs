using dyplomowanie.DiplomaProcess.Interfaces;
using dyplomowanie.DiplomaProcess.Users;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dyplomowanie.DiplomaProcess.DiplomaFiles
{

    public class Thesis : Subject
    {
        //gettery może otrzymać osoba mająca dostęp do klasy, settery tylko w zakresie klasy bądź też klas dziedziczących
        public string Topic { get; protected set; }
        public Student Student { get; protected set; }
        private Status _status;
        public AntiplagarismReport AntiPlagarismReport { get; protected set; }
        public Opinion Opinion { get; protected set; }
        public Review Review { get; protected set; }
        public List<UserNotification> Observers = new List<UserNotification>();

        private IValidator _validator;

        public Thesis(IValidator validator)
        {
            this._validator = validator;
        }

        //konstruktor sprawdzajacy temat - temat nie moze zawierac zakazanych slow ani byc pustym stringiem
        public Thesis(string topic, Student student)
        {
            if (IsTopicCorrectOrNot(topic) == false)
                throw new ArgumentException("Wpisany temat pracy nie może zostać zaakceptowany, gdyż nie spełnia postawionych norm!");
            else
            {
                Topic = topic;
                Student = student;
                Status = Status.NotUploaded;
            }
        }

        public Status Status
        {
            get { return this._status; }
            set
            {
                this._status = value;
                Notify();
            }
        }

        //wzorzec obserwatora - rejestracja do powiadomien
        protected override void Notify()
        {
            foreach (IObserver observer in this._observers)
            {
                observer.Update(this);
            }
        }

        //wzorzec obserwatora - rejestracja na powiadomienia
        public void RegisterForNotification(User user)
        {
            UserNotification observer = new UserNotification(user);
            this.Observers.Add(observer);
            this.Attach(observer);

            Console.WriteLine("{0} {1} dostaje od teraz notyfikacje o pracy dyplomowej {2}", user.FirstName, user.LastName, this.Topic);

        }

        //wzorzec obserwatora - rezygnacja z otrzymywania powiadomień
        public void UnregisterForNotification(User user)
        {

            List<UserNotification> ObserversToRemoveFromList = new List<UserNotification>();

            foreach (UserNotification observer in Observers)
            {
                if (observer.UserWithNotifications == user)
                {
                    ObserversToRemoveFromList.Add(observer);
                    this.Detach(observer);
                }
            }

            if (ObserversToRemoveFromList.Any())
            {
                Observers.RemoveAll(item => ObserversToRemoveFromList.Contains(item));
                Console.WriteLine("{0} {1} juz nie dostaje od teraz notyfikacji o pracy dyplomowej {2}", user.FirstName, user.LastName, this.Topic);
            }
            else
                Console.WriteLine("Uzytkownika {0} {1} nie ma na liscie osob otrzymujacych powiadomienia o pracy dyplomowej {2}", user.FirstName, user.LastName, this.Topic);
        }

        //metody zmieniające stan pracy
        public void Upload(Student student)
        {
            if (student == this.Student)
            {
                Console.WriteLine("Pierwsze wrzucenie pracy do systemu!");
                this.Status = Status.Uploaded;
            }
            else
                Console.WriteLine("Brak uprawnien");

        }

        //klasa do modyfikacji pracy dyplomowej - weryfikuje czy student który chce dodać zmodyfikowaną pracę to ten sam student, co autor pracy
        public void Modify(Student student)
        {
            if (student == this.Student)
            {
                Console.WriteLine("Modyfikacja pracy dyplomowej!");
                this.Status = Status.Modified;
            }
            else
                Console.WriteLine("Brak uprawnien");
        }

        public void ToImprove()
        {
            Console.WriteLine("Praca do poprawy!");
            this.Status = Status.ToImprove;
        }
        public void AddAntiPlagarismReport(AntiplagarismReport antiplagarismReport)
        {
            Console.WriteLine("Dodano raport antyplagiatowy!");
            this.AntiPlagarismReport = antiplagarismReport;
            this.Status = Status.GeneratedAntiplagarismReport;
        }

        public void ConfirmedByAdvisor()
        {
            Console.WriteLine("Raport antyplagiatowy zostal zaakceptowany przez promotora!");
            this.Status = Status.AntiplagiarismReportConfirmed;
        }
        public void AddOpinion(Opinion opinion)
        {
            Console.WriteLine("Dodano opinie!");
            this.Opinion = opinion;
            this.Status = Status.AddedOpinion;
        }

        public void AddReview(Review review)
        {
            Console.WriteLine("Dodano recenzje!");
            this.Review = review;
            this.Status = Status.Ready;
        }

        //klasa wyliczająca ostateczną ocenę - sprawdza status pracy i weryfikuje, czy recenzja bądź opinia zawierają ocenę negatywną
        public double CalculateMark(Status status, double reviewMark, double opinionMark)
        {
            double finalMark;
            if (status != Status.Ready)
            {
                finalMark = 0;
            }
            else
            {
                if (reviewMark == 2 || opinionMark == 2)
                {
                    finalMark = 2;
                }
                else
                {
                    finalMark = (reviewMark + opinionMark) / 2;
                }
            }
            return finalMark;
        }

        //klasa do sprawdzania, czy temat nie zawiera zakazanych slow
        public bool IsTopicCorrectOrNot(string topic)
        {
            IValidator validator = new TopicValidator();
            bool isCorrect = validator.IsTopicCorrect(topic);

            //aby przetestowac za pomoca Moq - odkomentowac te linie
            //bool isCorrect = this._validator.IsTopicCorrect(topic);

            //gdy temat jest nieprawidlowy - zwracane jest false
            if (isCorrect == false || topic == "")
                return false;
            else
                return true;
        }
    }
}
