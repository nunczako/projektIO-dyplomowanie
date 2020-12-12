using dyplomowanie.DiplomaProcess.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.DiplomaFiles
{
    public class Opinion
    {
        public Doctor Advisor { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public double Mark { get; protected set; }
        public string OpinionText { get; protected set; }

        //sprawdzanie czy opinia wykracza poza skale 2-5 czy nie
        public Opinion(Doctor advisor, Thesis thesis, double mark, string opiniontext)
        {
            if (mark<2 || mark>5) 
            { 
                throw new ArgumentOutOfRangeException("mark", "Ocena wykracza poza skalę ustaloną przez Akademię Górniczo-Hutniczą!"); 
            }
            else
            {
                Advisor = advisor;
                Thesis = thesis;
                Mark = mark;
                OpinionText = opiniontext;
            }
            
        }
    }
}
