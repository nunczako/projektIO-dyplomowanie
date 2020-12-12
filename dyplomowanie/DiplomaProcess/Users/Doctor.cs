using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.Users
{
    public class Doctor : User
    {
        public string Faculty { get; protected set; }
        public Doctor(string firstname, string lastname, string email, string password, string faculty)
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Password = password;
            Faculty = faculty;
        }

        public List<Student> AdvisorOfStudents = new List<Student>();
        public List<Student> ReviewerOfStudents = new List<Student>();

        //metody dodajace doktora jako promotora albo recenzenta
        public void AddAdvisor(Student student)
        {
            student.AddAdvisor(this);
            this.AdvisorOfStudents.Add(student);
        }

        public void AddReviewer(Student student)
        {
            student.AddReviewer(this);
            this.ReviewerOfStudents.Add(student);
        }
    }
}
