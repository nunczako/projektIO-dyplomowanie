using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.DiplomaFiles
{
    public class AntiplagarismReport
    {
        public int PlagarismPercentage { get; protected set; }
        public string Text { get; protected set; }
        public AntiplagarismReport(int plagarismpercentage, string text)
        {
            this.PlagarismPercentage = plagarismpercentage;
            this.Text = text;
        }
    }
}
