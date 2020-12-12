using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.Users
{
    public class Student : User
    {
        public string Faculty { get; protected set; }
        public Student(string firstname, string lastname, string email, string password, string faculty)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            Faculty = faculty;
        }
        public Doctor Advisor { get; protected set; }
        public Doctor Reviewer { get; protected set; }

        //metody nadajace promotora oraz recenzenta
        public void AddAdvisor(Doctor doctor)
        {
            this.Advisor = doctor;
        }

        public void AddReviewer(Doctor doctor)
        {
            this.Reviewer = doctor;
        }
    }
}
