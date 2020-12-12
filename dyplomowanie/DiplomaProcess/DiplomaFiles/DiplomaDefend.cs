using dyplomowanie.DiplomaProcess.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.DiplomaFiles
{
    public class DiplomaDefend
    {
        public Doctor Doctor { get; protected set; }
        public Student Student { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public DiplomaDefend(Doctor doctor, Student student, Thesis thesis)
        {
            this.Doctor = doctor;
            this.Student = student;
            this.Thesis = thesis;
        }

        public DateTime SetDiplomaDefendDate(DateTime defendDate)
        {
            //uznano, ze obrona moze sie odbyc najpozniej 90 dni od dnia w ktorym doszlo do jej wpisania
            double result = (defendDate - DateTime.Now).TotalDays;
            if (result >= 0 && result <=90)
            {
                //w przypadku gdy ustalona data obrony wypada w sobote lub niedziele dochodzi do jej przesuniecia na najblizszy poniedzialek
                if (defendDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    defendDate = defendDate.AddDays(2);
                }

                if (defendDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    defendDate = defendDate.AddDays(1);
                }

                Console.WriteLine($"Data obrony dla studenta {this.Student.FirstName} {this.Student.LastName} została ustalona! Obrona odbędzie się:");
            }
            else
            {
                throw new ArgumentOutOfRangeException("defendDate", "Ocena wykracza poza skalę dat obron ustaloną przez Akademię Górniczo-Hutniczą!");
            }
            return defendDate;
        }
    }
}
