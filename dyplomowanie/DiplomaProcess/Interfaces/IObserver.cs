using dyplomowanie.DiplomaProcess.DiplomaFiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.Interfaces
{
    //interfejs - wzorzec obserwatora
    public interface IObserver
    {
        void Update(Thesis thesis);
    }
}
