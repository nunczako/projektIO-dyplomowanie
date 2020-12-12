using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess.Interfaces
{
    //interfejs - wzorzec polecenia
    public interface ICommand
    {
        void Execute();
    }
}
