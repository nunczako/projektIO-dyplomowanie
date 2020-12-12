using dyplomowanie.DiplomaProcess;
using dyplomowanie.DiplomaProcess.DiplomaFiles;
using dyplomowanie.DiplomaProcess.Users;
using System;

namespace dyplomowanie
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WIRTUALNY DZIEKANAT\nWITAMY!\n");
            //stworzenie studentow oraz pracownikow Wydzialu
            Student student1 = new Student("Kamil", "Pietrzyk", "kpietrzyk@student.agh.edu.pl", "strongPassword1", "Zarzadzania");
            Student student2 = new Student("Piotr", "Pamula", "ppamula@student.agh.edu.pl", "strongPassword2", "Zarzadzania");
            Doctor doc1 = new Doctor("Andrzej", "Wojtowicz", "awojtowicz@agh.edu.pl", "strongPassword3", "Zarzadzania");
            Doctor doc2 = new Doctor("Marcin", "Wolak", "mwolak@agh.edu.pl", "strongPassword4", "Zarzadzania");


            //dodawanie przez doktorów swoich maili do listy kontaktów z doktorami; jeden przypadek błędny w celu ukazania działania commandPattern, 
            //gdy doktorzy podadzą błędny mail
            Contacts contacts = new Contacts();
            Admin admin = new Admin();
            AddingContact contact1 = new AddingContact(contacts, "prywatnyaWojtowicz@gmail.com", doc1);
            admin.AddMailToList(contact1);

            AddingContact contact2 = new AddingContact(contacts, "awojtowicz@agh.edu.pl", doc1);
            admin.AddMailToList(contact2);

            //dodanie maila generujące wywołanie wyjątku - zakomentowane, aby program kompilował się w prawidłowy sposób
            //AddingContact contact3 = new AddingContact(contacts, "prywatnymWolak-gmail.com", emp2);
            //admin.AddMailToList(contact3);

            AddingContact contact4 = new AddingContact(contacts, "mwolak@agh.edu.pl", doc2);
            admin.AddMailToList(contact4);
            admin.ExecuteAllEmails();
            contacts.ShowAllMails();

            Console.ReadKey();

            //przydzielenie promotorow do wybranych studentow
            doc1.AddAdvisor(student1);
            doc2.AddAdvisor(student2);

            //przydzielenie recenzentow do wybranych studentow
            doc1.AddReviewer(student2);
            doc2.AddReviewer(student1);

            //stworzenie prac dyplomowych
            Thesis praca1 = new Thesis("Grupowanie druzyn pilkarskich wzgledem prezentowanego stylu gry przy wykorzystaniu analizy skupien", student1);
            Thesis praca2 = new Thesis("Zarządzanie kryzysowe w gminie Kocmyrzów-Luborzyca", student2);

            //sprawdzenie czy tylko przypisany student student moze dodac prace - ukazanie zablokowania dodania pracy przez nieuprawnionego studenta, dla przykladu
            praca1.Upload(student2);
            Console.ReadKey();

            //przypisanie poszczegolnych uzytkownikow do obserwowania prac - wzorzec obserwatora, wysylanie powiadomien
            praca1.RegisterForNotification(student1);
            praca1.RegisterForNotification(doc1);
            praca1.RegisterForNotification(doc2);

            praca2.RegisterForNotification(student2);
            praca2.RegisterForNotification(doc2);
            praca2.RegisterForNotification(doc1);
            Console.ReadKey();

            praca1.Upload(student1);
            praca2.Upload(student2);
            Console.ReadKey();

            praca1.Modify(student1);
            praca2.Modify(student2);

            praca1.ToImprove();
            praca2.ToImprove();

            //wystawienie opinii, recenzji oraz wpisanie raportu antyplagiatowego
            AntiplagarismReport report1 = new AntiplagarismReport(10, "Raport wygenerowany pomyslnie");
            Opinion opinion1 = new Opinion(doc1, praca1, 5.0, "Bardzo dobrze napisana praca.");
            Review review1 = new Review(doc2, praca1, 5.0, "Swietnie sie czytalo te prace, nie mam zadnych uwag.");

            AntiplagarismReport report2 = new AntiplagarismReport(14, "Raport wygenerowany pomyslnie");
            Opinion opinion2 = new Opinion(doc2, praca1, 4.0, "Dobrze napisana praca.");
            Review review2 = new Review(doc2, praca1, 5.0, "Swietnie sie czytalo te prace, nie mam zadnych uwag.");


            praca1.AddAntiPlagarismReport(report1);
            praca1.ConfirmedByAdvisor();
            praca1.AddOpinion(opinion1);
            praca1.AddReview(review1);
            double ocena1 = praca1.CalculateMark(praca1.Status, praca1.Review.Mark, praca1.Opinion.Mark);
            Console.WriteLine($"Finalna ocena pracy uwzględniając recenzję oraz opinię wynosi: {ocena1}");
            Console.ReadKey();
            praca2.AddAntiPlagarismReport(report2);
            praca2.ConfirmedByAdvisor();
            praca2.AddOpinion(opinion2);
            //wyrejestrowanie z obserwacji przez recenzenta - wystawil on juz recenzje, wiec zdecydowal sie na rezygnacje z obserwacji pracy
            praca2.UnregisterForNotification(doc1);
            praca2.AddReview(review2);
            double ocena2 = praca2.CalculateMark(praca2.Status, praca2.Review.Mark, praca2.Opinion.Mark);
            Console.WriteLine($"Finalna ocena pracy uwzględniając recenzję oraz opinię wynosi: {ocena2}");
            Console.ReadKey();


            //ustalenie terminow obron dla poszczegolnych studentow
            DiplomaDefend defend1 = new DiplomaDefend(doc1, student1, praca1);
            DiplomaDefend defend2 = new DiplomaDefend(doc2, student2, praca2);

            DateTime date1 = new DateTime(2021, 1, 12, 9, 0, 0);
            DateTime date2 = new DateTime(2021, 1, 23, 10, 15, 0);
            Console.WriteLine(defend1.SetDiplomaDefendDate(date1));
            Console.WriteLine(defend2.SetDiplomaDefendDate(date2));

            Console.ReadKey();
        }
    }
}
