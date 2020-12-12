using dyplomowanie.DiplomaProcess.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.DiplomaFiles
{
    public class Review
    {
        public Doctor Reviewer { get; protected set; }
        public Thesis Thesis { get; protected set; }
        public double Mark { get; protected set; }
        public string ReviewText { get; protected set; }

        //sprawdzanie czy opinia wykracza poza skale 2-5 czy nie
        public Review(Doctor reviewer, Thesis thesis, double mark, string reviewtext)
        {
            if (mark < 2 || mark > 5)
            {
                throw new ArgumentOutOfRangeException("mark", "Ocena wykracza poza skalę ustaloną przez Akademię Górniczo-Hutniczą!");
            }
            else
            {
                Reviewer = reviewer;
                Thesis = thesis;
                Mark = mark;
                ReviewText = reviewtext;
            }
        }
    }
}
