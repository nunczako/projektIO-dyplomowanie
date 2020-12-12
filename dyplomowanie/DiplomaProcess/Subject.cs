using dyplomowanie.DiplomaProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dyplomowanie.DiplomaProcess
{
    //wzorzec obserwatora - przypisywanie, rezygnacja z obserwacji, powiadamianie
    public abstract class Subject
    {
        protected List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver obs)
        {
            this._observers.Add(obs);
        }

        public void Detach(IObserver obs)
        {
            this._observers.Remove(obs);
        }

        abstract protected void Notify();
    }
}
